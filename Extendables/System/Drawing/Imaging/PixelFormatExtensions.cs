// ReSharper disable once CheckNamespace
namespace System.Drawing.Imaging
{
  public static class PixelFormatExtensions
  {
    /// <summary>
    /// Checks to see if the PixelFormat is an indexed type.
    /// </summary>
    /// <param name="format">The format to inspect.</param>
    /// <returns>True if indexed, false if otherwise.</returns>
    public static bool IsIndexed(this PixelFormat format)
    {
      return (((int)format & (int)PixelFormat.Indexed) > 0);
    }

    /// <summary>
    /// Checks to see if the PixelFormat has an alpha channnel that are not premultiplied.
    /// </summary>
    /// <param name="format">The format to inspect.</param>
    /// <returns>True if alpha channel is present, false if otherwise.</returns>
    public static bool HasAlpha(this PixelFormat format)
    {
      return (((int)format & (int)PixelFormat.Alpha) > 0);
    }

    /// <summary>
    /// Checks to see if the PixelFormat has premultiplied alpha values.
    /// </summary>
    /// <param name="format">The format to inspect.</param>
    /// <returns>True if PAlpha channel is present, false if otherwise.</returns>
    public static bool HasPAlpha(this PixelFormat format)
    {
      return (((int)format & (int)PixelFormat.PAlpha) > 0);
    }

    /// <summary>
    /// Checks to see if the PixelFormat is 1 bit.
    /// </summary>
    /// <param name="format">The format to inspect.</param>
    /// <returns>True if 1bit format, false if otherwise.</returns>
    public static bool Is1Bit(this PixelFormat format)
    {
      return (format.GetBitsPerPixel() == 1);
    }

    /// <summary>
    /// Checks to see if the PixelFormat is 4 bit.
    /// </summary>
    /// <param name="format">The format to inspect.</param>
    /// <returns>True if 4bit format, false if otherwise.</returns>
    public static bool Is4Bit(this PixelFormat format)
    {
      return (format.GetBitsPerPixel() == 4);
    }

    /// <summary>
    /// Checks to see if the PixelFormat is 8 bit.
    /// </summary>
    /// <param name="format">The format to inspect.</param>
    /// <returns>True if 8bit format, false if otherwise.</returns>
    public static bool Is8Bit(this PixelFormat format)
    {
      return (format.GetBitsPerPixel() == 8);
    }

    /// <summary>
    /// Checks to see if the PixelFormat is 16 bit.
    /// </summary>
    /// <param name="format">The format to inspect.</param>
    /// <returns>True if 16bit format, false if otherwise.</returns>
    public static bool Is16Bit(this PixelFormat format)
    {
      return (format.GetBitsPerPixel() == 16);
    }

    /// <summary>
    /// Checks to see if the PixelFormat is 24 bit.
    /// </summary>
    /// <param name="format">The format to inspect.</param>
    /// <returns>True if 32bit format, false if otherwise.</returns>
    public static bool Is24Bit(this PixelFormat format)
    {
      return (format.GetBitsPerPixel() == 24);
    }

    /// <summary>
    /// Checks to see if the PixelFormat is 32 bit.
    /// </summary>
    /// <param name="format">The format to inspect.</param>
    /// <returns>True if 32bit format, false if otherwise.</returns>
    public static bool Is32Bit(this PixelFormat format)
    {
      return (format.GetBitsPerPixel() == 32);
    }

    /// <summary>
    /// Checks to see if the PixelFormat is 48 bit.
    /// </summary>
    /// <param name="format">The format to inspect.</param>
    /// <returns>True if 48bit format, false if otherwise.</returns>
    public static bool Is48Bit(this PixelFormat format)
    {
      return (format.GetBitsPerPixel() == 48);
    }

    /// <summary>
    /// Checks to see if the PixelFormat is 48 bit.
    /// </summary>
    /// <param name="format">The format to inspect.</param>
    /// <returns>True if 48bit format, false if otherwise.</returns>
    public static bool Is64Bit(this PixelFormat format)
    {
      return (format.GetBitsPerPixel() == 64);
    }

    /// <summary>
    /// Get the number of bits for the specified pixel format.
    /// </summary>
    /// <param name="format">The pixel format to inspect.</param>
    /// <returns>The number of bits per pixel</returns>
    public static int GetBitsPerPixel(this PixelFormat format)
    {
      return (((int)format >> 8) & 0xFF);
      //return (Image.GetPixelFormatSize(format));
    }

    /// <summary>
    /// Get the number of bytes for the specified pixel format.
    /// </summary>
    /// <param name="format">The pixel format to inspect.</param>
    /// <returns>The number of bytes per pixel</returns>
    public static int GetBytesPerPixel(this PixelFormat format)
    {
      return (((int)format >> 11) & 0x1F);
    }
  }
}