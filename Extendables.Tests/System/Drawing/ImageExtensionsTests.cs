using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;

namespace Extendables.Tests.System.Drawing
{
  [TestFixture]
  public class ImageExtensionsTests
  {
    public string _directory = ".";

    [SetUp]
    public void Initialize()
    {
      _directory = Path.GetPathRoot(this.GetType().Assembly.Location);
    }

    /// <summary>
    /// Gets a 10x10 sample bitmap with 2 black pixels at 1,1 & 8,5
    /// </summary>
    /// <returns>A sample image.</returns>
    private Image GetSampleImage(Color fillColor, Action<Bitmap, Graphics> paint = null)
    {
      Bitmap bitmap = new Bitmap(10, 10);
      using (Graphics g = Graphics.FromImage(bitmap)) {
        // By default new image is filled with black.
        if (fillColor != Color.Black) {
          g.FillRectangle(new SolidBrush(fillColor), 0, 0, bitmap.Width, bitmap.Height);
        }

        if (paint != null) paint.Invoke(bitmap, g);
        return (bitmap);
      }
    }

    [Test]
    public void GetWhitespaceBoundingRectangleWith1PixelWhiteImageReturnsEmptyRectangle()
    {
      using (Bitmap bitmap = new Bitmap(1, 1, PixelFormat.Format32bppArgb)) {
        bitmap.SetPixel(0, 0, Color.White);

        Rectangle expected = Rectangle.Empty;
        Rectangle result = bitmap.GetWhitespaceBoundingRectangle();
        
        Assert.AreEqual(Rectangle.Empty, result);
      }
    }

    [Test]
    public void GetWhitespaceBoundingRectangleWithSolidBlackImageReturnsFullRectangle()
    {
      using (Image image = GetSampleImage(Color.Black)) {
        Rectangle expected = new Rectangle(0, 0, 10, 10);
        Rectangle result = image.GetWhitespaceBoundingRectangle();

        Assert.AreEqual(expected, result);
      }
    }

    [Test]
    public void GetWhitespaceBoundingRectangleWithLeftWhitespaceReturnsPartialRectangle()
    {
      using (Image image = GetSampleImage(Color.Black, (bmp, g) => { g.DrawLine(new Pen(Color.White), 0, 0, 0, 9); })) {
        Rectangle expected = new Rectangle(1, 0, 9, 10);
        Rectangle result = image.GetWhitespaceBoundingRectangle();

        Assert.AreEqual(expected, result);
      }
    }

    [Test]
    public void GetWhitespaceBoundingRectangleWithRightWhitespaceReturnsPartialRectangle()
    {
      using (Image image = GetSampleImage(Color.Black, (bmp, g) => { g.DrawLine(new Pen(Color.White), 9, 0, 9, 9); })) {
        Rectangle expected = new Rectangle(0, 0, 9, 10);
        Rectangle result = image.GetWhitespaceBoundingRectangle();

        Assert.AreEqual(expected, result);
      }
    }

    [Test]
    public void GetWhitespaceBoundingRectangleWithTopWhitespaceReturnsPartialRectangle()
    {
      using (Image image = GetSampleImage(Color.Black, (bmp, g) => { g.DrawLine(new Pen(Color.White), 0, 0, 9, 0); })) {
        Rectangle expected = new Rectangle(0, 1, 10, 9);
        Rectangle result = image.GetWhitespaceBoundingRectangle();

        Assert.AreEqual(expected, result);
      }
    }

    [Test]
    public void GetWhitespaceBoundingRectangleWithBottomWhitespaceReturnsPartialRectangle()
    {
      using (Image image = GetSampleImage(Color.Black, (bmp, g) => { g.DrawLine(new Pen(Color.White), 0, 9, 9, 9); })) {
        Rectangle expected = new Rectangle(0, 0, 10, 9);
        Rectangle result = image.GetWhitespaceBoundingRectangle();

        Assert.AreEqual(expected, result);
      }
    }

    [Test]
    public void GetWhitespaceBoundingRectangleWithSurroundingWhitespaceReturnsPartialRectangle()
    {
      using (Image image = GetSampleImage(Color.White, (bmp, g) => { bmp.SetPixel(1, 1, Color.Black);
                                                                     bmp.SetPixel(8, 5, Color.Black); })) {
        Rectangle expected = new Rectangle(1, 1, 8, 5);
        Rectangle result = image.GetWhitespaceBoundingRectangle();
        
        Assert.AreEqual(expected, result);
      }
    }

    [Test]
    public void GetWhitespaceBoundingRectangleWithNullImageReturnsEmptyRectangle()
    {
      Rectangle expected = Rectangle.Empty;
      Rectangle result = ((Image) null).GetWhitespaceBoundingRectangle();
        
      Assert.AreEqual(expected, result);
    }
  }
}
