using System.Collections.Generic;
using System.IO;
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
    /// Get the bounding rectangle for the specified image that does not contain whitespace
    /// colors.
    /// </summary>
    /// <param name="image">The image to get the whitespace bounding rectangle for.</param>
    /// <param name="colors">The enumeration of colors to be treated as whitespace.</param>
    /// <returns>The bounding rectangle that of non whitespace colors.</returns>
    public static Rectangle GetWhitespaceBoundingRectangle(this Image image, IEnumerable<Color> colors = null)
    {
      if (image == null) return (Rectangle.Empty);

      int width = image.Width;
      int height = image.Height;
      int? x1 = null, y1 = null, x2 = null, y2 = null;

      Bitmap bitmap = image as Bitmap ?? new Bitmap(image);
      BitmapData data = null;
      try {
        // We will force the bitmap data to be 32 bit regardless of the input or output format
        PixelFormat dataFormat = PixelFormat.Format32bppArgb;
        int offset = dataFormat.GetBytesPerPixel();

        object mutex = new object();
        data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, dataFormat);
        Parallel.For(0, height - 1, (y) => {
          byte[] row = new byte[data.Stride];
           Marshal.Copy(data.Scan0 + y * data.Stride, row, 0, data.Stride);
           for (int x = 0; x < width; x++) {
             Color pixel = Color.FromArgb(row[(x * offset) + 3], row[(x * offset) + 2], row[(x * offset) + 1], row[(x * offset)]);
             if (!IsWhitespace(pixel, colors ?? DefaultWhitespaceColors)) {
               lock(mutex) {
                 if ((x1 == null) || (x < x1)) x1 = x;
                 else if ((x2 == null) || (x > x2)) x2 = x;
  
                 if ((y1 == null) || (y < y1)) y1 = y;
                 else if ((y2 == null) || (y > y2)) y2 = y;
               }
             }
           }
        });
      }
      finally {
        bitmap.UnlockBits(data);
      }

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

      // Wrap the original image in a Bitmap if necessary so we can modify it.
      Bitmap bitmap = image as Bitmap ?? new Bitmap(image);
      Bitmap croppedBitmap = new Bitmap(crop.Width, crop.Height, format);
      if (format.IsIndexed()) croppedBitmap.Palette = bitmap.Palette;

      BitmapData data = null;
      BitmapData croppedData = null;
      // We will force the bitmap data to be 32 bit regardless of the input or output format
      const PixelFormat dataFormat = PixelFormat.Format32bppArgb; 
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

    /// <summary>
    /// Returns the byte[] representation of the image.
    /// </summary>
    /// <param name="image">The image to get the byte representation for.</param>
    /// <returns>The encoded byte[] representation of the image.</returns>
    public static byte[] ToArray(this Image image)
    {
      return(ToArray(image, ImageFormat.Png));
    }
    
    /// <summary>
    /// Returns the byte[] representation of the image.
    /// </summary>
    /// <param name="image">The image to get the byte representation for.</param>
    /// <param name="format">The format to encode or save the image in.</param>
    /// <returns>True if the color is within the specified whitespace.</returns>
    public static byte[] ToArray(this Image image, ImageFormat format)
    {
      if (image == null) return (null);

      using (MemoryStream stream = new MemoryStream()) {
        image.Save(stream, format);
        return (stream.ToArray());
      }
    }
  }
}