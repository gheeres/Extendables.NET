using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace System.Drawing.Imaging
{
  public static class ImageExtensions
  {
    /// <summary>The default colors considered to be whitespace.</summary>
    public static readonly Color[] DefaultWhitespaceColors = { Color.White, Color.Transparent };

    /// <summary>
    /// Gets all of the pixels in the image into a two dimensional array of colors.
    /// </summary>
    /// <param name="image">The image to retrieve the pixels from.</param>
    /// <returns>A two dimensional array of pixel colors.</returns>
    private static Color[,] GetPixels(this Image image)
    {
      if (image == null) return (null);
      PixelFormat inputFormat = image.PixelFormat;
      if (inputFormat.Is48Bit() || (inputFormat.Is64Bit())) throw(new ArgumentException(String.Format("The pixel format '{0}' for the image is not supported.", inputFormat)));

      int width = image.Width;
      int height = image.Height;
      Color[,] pixels = new Color[image.Width, image.Height];

      Bitmap bitmap = image as Bitmap ?? new Bitmap(image);
      BitmapData data = null;
      try {
        // We will force the bitmap data to be 32 bit regardless of the input or output format
        PixelFormat dataFormat = PixelFormat.Format32bppArgb;
        int offset = dataFormat.GetBytesPerPixel();

        data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, dataFormat);
        Parallel.For(0, height, y => {
          // Work with one row of the image
          byte[] row = new byte[data.Stride];
          Marshal.Copy(data.Scan0 + y * data.Stride, row, 0, data.Stride);
          for (int x = 0; x < width; x++) {
            pixels[x, y] = Color.FromArgb(row[(x*offset)+3], row[(x*offset)+2], row[(x*offset)+1], row[(x*offset)]);
          }
        });
      }
      finally {
        bitmap.UnlockBits(data);
      }
      return (pixels);
    }

    /// <summary>
    /// Get the bounding rectangle for the specified image that does not contain whitespace
    /// colors.
    /// </summary>
    /// <param name="image">The image to get the whitespace bounding rectangle for.</param>
    /// <param name="colors">The enumeration of colors to be treated as whitespace.</param>
    /// <returns>The bounding rectangle that of non whitespace colors.</returns>
    public static Rectangle GetWhitespaceBoundingRectangle(this Image image, IEnumerable<Color> colors = null)
    {
      if (image == null) return (Rectangle.Empty);
      return (GetWhitespaceBoundingRectangle(GetPixels(image), colors ?? DefaultWhitespaceColors));
    }

    /// <summary>
    /// Get the bounding rectangle for the specified two dimensional array of pixels that does
    /// not contain whitespace colors.
    /// </summary>
    /// <param name="pixels">The two dimensional array of pixels to inspect.</param>
    /// <param name="colors">The enumeration of colors to be treated as whitespace.</param>
    /// <returns>The bounding rectangle that of non whitespace colors.</returns>
    private static Rectangle GetWhitespaceBoundingRectangle(Color[,] pixels, IEnumerable<Color> colors = null)
    {
      int width = pixels.GetLength(0);
      int height = pixels.GetLength(1);
      int? x1 = null, y1 = null, x2 = null, y2 = null;

      // Run the top / left and bottom / right scans in parallel.
      Parallel.Invoke(
        // Start scanning X (left to right, top to bottom)
        () => {
          for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
              if (!IsWhitespace(pixels[x, y], colors ?? DefaultWhitespaceColors)) {
                if (x1 == null) x1 = x;
                else x2 = x;
              }
            }
          }
        },
        // Start scanning Y (right to left, bottom to top)
        () => {
          for (int y = height - 1; y >= 0; y--) {
            for (int x = width - 1; x >= 0; x--) {
              if (!IsWhitespace(pixels[x, y], colors ?? DefaultWhitespaceColors)) {
                if (y2 == null) y2 = y;
                else y1 = y;
              }
            }
          }
        }
      );

      if ((x1 == null) && (y1 == null) && (x2 == null) && (y2 == null)) return (Rectangle.Empty);
      return (new Rectangle(x1 ?? 0, y1 ?? 0,
                           (x2 ?? width) - (x1 ?? 0) + 1,
                           (y2 ?? height) - (y1 ?? 0) + 1));
    }

    /// <summary>
    /// Crops whitespace of the specified colors from the perimeter of the image.
    /// </summary>
    /// <param name="image">The image to crop or remove blank space from.</param>
    /// <param name="colors">The enumeration of colors to be treated as whitespace.</param>
    /// <returns>The newly cropped image. The original image is not modified but a copy is returned.</returns>
    public static Image CropWhitespace(this Image image, IEnumerable<Color> colors = null)
    {
      if (image == null) return (null);
      int width = image.Width;
      int height = image.Height;
      PixelFormat format = image.PixelFormat;

      Rectangle crop = GetWhitespaceBoundingRectangle(image, colors ?? DefaultWhitespaceColors);

      // Copy the original image into a new image.
      Bitmap bitmap = image as Bitmap ?? new Bitmap(image);
      Bitmap croppedBitmap = new Bitmap(crop.Width, crop.Height, format);
      if (format.IsIndexed()) croppedBitmap.Palette = bitmap.Palette;

      BitmapData data = null;
      BitmapData croppedData = null;
      // We will force the bitmap data to be 32 bit regardless of the input or output format
      PixelFormat dataFormat = PixelFormat.Format32bppArgb; 
      try {
        data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, dataFormat);
        croppedData = croppedBitmap.LockBits(new Rectangle(0, 0, croppedBitmap.Width, croppedBitmap.Height), ImageLockMode.WriteOnly, dataFormat);
        byte[] raw = new byte[croppedData.Stride * crop.Height];

        int offset = crop.X * (dataFormat.GetBitsPerPixel() / 8);
        // Copy each row, skipping over the right pixels that are being cropped.
        Parallel.For(0, crop.Height, y => {
          Marshal.Copy(data.Scan0 + ((y + crop.Y) * data.Stride) + offset, raw, y * croppedData.Stride, croppedData.Stride);
        });

        Marshal.Copy(raw, 0, croppedData.Scan0, raw.Length);
      }
      finally {
        bitmap.UnlockBits(data);
        croppedBitmap.UnlockBits(croppedData);
      }
      return (croppedBitmap);
    }

    /// <summary>
    /// Checks to see if the specified color is contained in the defined list of whitespace colors.
    /// </summary>
    /// <param name="pixel">The pixel to inspect.</param>
    /// <param name="colors">The colors that are considered to be whitespace.</param>
    /// <returns>True if the color is within the specified whitespace.</returns>
    private static bool IsWhitespace(Color pixel, IEnumerable<Color> colors = null)
    {
      return ((colors ?? DefaultWhitespaceColors).Any(c => c.ToArgb() == pixel.ToArgb()));
    }
  }
}