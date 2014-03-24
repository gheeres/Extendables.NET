using System;
using System.Drawing.Imaging;
using NUnit.Framework;

namespace Extendables.Tests.System.Drawing.Imaging
{
  [TestFixture]
  public class PixelFormatExtensionsTests
  {
    [Test]
    public void WhenIsIndexedWithFormat1bppIndexedReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format1bppIndexed;
      Assert.IsTrue(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat4bppIndexedReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format4bppIndexed;
      Assert.IsTrue(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat8bppIndexedReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format8bppIndexed;
      Assert.IsTrue(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat16bppArgb1555ReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format16bppArgb1555;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat16bppRgb555ReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format16bppRgb555;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat16bppRgb565ReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format16bppRgb565;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat16bppGrayScaleReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format16bppGrayScale;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat24bppRgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat32bppArgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format32bppArgb;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat32bppPArgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format32bppPArgb;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat32bppRgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format32bppRgb;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat48bppRgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format48bppRgb;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat64bppArgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format64bppArgb;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithFormat64bppPArgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format64bppPArgb;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenIsIndexedWithCanonicalReturnsFalse()
    {
      PixelFormat format = PixelFormat.Canonical;
      Assert.IsFalse(format.IsIndexed());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat1bppIndexedReturns1()
    {
      PixelFormat format = PixelFormat.Format1bppIndexed;
      Assert.AreEqual(1, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat4bppIndexedReturns4()
    {
      PixelFormat format = PixelFormat.Format4bppIndexed;
      Assert.AreEqual(4, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat8bppIndexedReturns8()
    {
      PixelFormat format = PixelFormat.Format8bppIndexed;
      Assert.AreEqual(8, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat16bppArgb1555Returns16()
    {
      PixelFormat format = PixelFormat.Format16bppArgb1555;
      Assert.AreEqual(16, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat16bppGrayScaleReturns16()
    {
      PixelFormat format = PixelFormat.Format16bppGrayScale;
      Assert.AreEqual(16, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat16bppRgb555Returns16()
    {
      PixelFormat format = PixelFormat.Format16bppRgb555;
      Assert.AreEqual(16, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat16bppRgb565Returns16()
    {
      PixelFormat format = PixelFormat.Format16bppRgb565;
      Assert.AreEqual(16, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat24bppRgbReturns24()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.AreEqual(24, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat32bppArgbReturns32()
    {
      PixelFormat format = PixelFormat.Format32bppArgb;
      Assert.AreEqual(32, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat32bppPArgbReturns32()
    {
      PixelFormat format = PixelFormat.Format32bppPArgb;
      Assert.AreEqual(32, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat32bppRgbReturns32()
    {
      PixelFormat format = PixelFormat.Format32bppRgb;
      Assert.AreEqual(32, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat48bppRgbReturns48()
    {
      PixelFormat format = PixelFormat.Format48bppRgb;
      Assert.AreEqual(48, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat64bppArgbReturns64()
    {
      PixelFormat format = PixelFormat.Format64bppArgb;
      Assert.AreEqual(64, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenGetBitsPerPixelWithFormat64bppPArgbReturns64()
    {
      PixelFormat format = PixelFormat.Format64bppPArgb;
      Assert.AreEqual(64, format.GetBitsPerPixel());
    }

    [Test]
    public void WhenIs1BitWithFormat1bppIndexedReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format1bppIndexed;
      Assert.IsTrue(format.Is1Bit());
    }

    [Test]
    public void WhenIs1BitWithFormat24bppRgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.IsFalse(format.Is1Bit());
    }

    [Test]
    public void WhenIs4BitWithFormat4bppIndexedReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format4bppIndexed;
      Assert.IsTrue(format.Is4Bit());
    }

    [Test]
    public void WhenIs4BitWithFormat24bppRgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.IsFalse(format.Is4Bit());
    }

    [Test]
    public void WhenIs8BitWithFormat8bppIndexedReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format8bppIndexed;
      Assert.IsTrue(format.Is8Bit());
    }

    [Test]
    public void WhenIs8BitWithFormat24bppRgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.IsFalse(format.Is8Bit());
    }

    [Test]
    public void WhenIs16BitWithFormat16bppArgb1555ReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format16bppArgb1555;
      Assert.IsTrue(format.Is16Bit());
    }

    [Test]
    public void WhenIs16BitWithFormat16bppGrayScaleReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format16bppGrayScale;
      Assert.IsTrue(format.Is16Bit());
    }

    [Test]
    public void WhenIs16BitWithFormat16bppRgb555ReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format16bppRgb555;
      Assert.IsTrue(format.Is16Bit());
    }

    [Test]
    public void WhenIs16BitWithFormat16bppRgb565ReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format16bppRgb565;
      Assert.IsTrue(format.Is16Bit());
    }

    [Test]
    public void WhenIs16BitWithFormat24bppRgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.IsFalse(format.Is16Bit());
    }

    [Test]
    public void WhenIs24BitWithFormat24bppRgbReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.IsTrue(format.Is24Bit());
    }

    [Test]
    public void WhenIs24BitWithFormat32bppArgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format32bppArgb;
      Assert.IsFalse(format.Is24Bit());
    }

    [Test]
    public void WhenIs32BitWithFormat32bppArgbReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format32bppArgb;
      Assert.IsTrue(format.Is32Bit());
    }

    [Test]
    public void WhenIs32BitWithFormat32bppPArgbReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format32bppPArgb;
      Assert.IsTrue(format.Is32Bit());
    }

    [Test]
    public void WhenIs32BitWithFormat32bppRgbReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format32bppRgb;
      Assert.IsTrue(format.Is32Bit());
    }

    [Test]
    public void WhenIs32BitWithFormat24bppRgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.IsFalse(format.Is32Bit());
    }

    [Test]
    public void WhenIs48BitWithFormat48bppRgbReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format48bppRgb;
      Assert.IsTrue(format.Is48Bit());
    }

    [Test]
    public void WhenIs48BitWithFormat24bppRgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.IsFalse(format.Is48Bit());
    }

    [Test]
    public void WhenIs64BitWithFormat64bppArgbReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format64bppArgb;
      Assert.IsTrue(format.Is64Bit());
    }

    [Test]
    public void WhenIs64BitWithFormat64bppPArgbReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format64bppPArgb;
      Assert.IsTrue(format.Is64Bit());
    }

    [Test]
    public void WhenIs64BitWithFormat24bppRgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.IsFalse(format.Is64Bit());
    }

    [Test]
    public void WhenHasAlphaWithFormat32bppArgbReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format32bppArgb;
      Assert.IsTrue(format.HasAlpha());
    }

    [Test]
    public void WhenHasAlphaWithFormat16bppArgb1555ReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format16bppArgb1555;
      Assert.IsTrue(format.HasAlpha());
    }

    [Test]
    public void WhenHasAlphaWithFormat64bppArgbReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format64bppArgb;
      Assert.IsTrue(format.HasAlpha());
    }

    [Test]
    public void WhenHasAlphaWithFormat16bppRgb555ReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format16bppRgb555;
      Assert.IsFalse(format.HasAlpha());
    }

    [Test]
    public void WhenHasAlphaWithFormat24bppRgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.IsFalse(format.HasAlpha());
    }

    [Test]
    public void WhenHasPAlphaWithFormat32bppArgbReturnsFalse()
    {
      PixelFormat format = PixelFormat.Format32bppArgb;
      Assert.IsFalse(format.HasPAlpha());
    }

    [Test]
    public void WhenHasPAlphaWithFormat32bppPArgbReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format32bppPArgb;
      Assert.IsTrue(format.HasPAlpha());
    }

    [Test]
    public void WhenHasPAlphaWithFormat64bppPArgbReturnsTrue()
    {
      PixelFormat format = PixelFormat.Format64bppPArgb;
      Assert.IsTrue(format.HasPAlpha());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat1bppIndexedReturns0()
    {
      PixelFormat format = PixelFormat.Format1bppIndexed;
      Assert.AreEqual(0, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat4bppIndexedReturns0()
    {
      PixelFormat format = PixelFormat.Format4bppIndexed;
      Assert.AreEqual(0, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat8bppIndexedReturns1()
    {
      PixelFormat format = PixelFormat.Format8bppIndexed;
      Assert.AreEqual(1, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat16bppArgb1555Returns2()
    {
      PixelFormat format = PixelFormat.Format16bppArgb1555;
      Assert.AreEqual(2, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat16bppGrayScaleReturns2()
    {
      PixelFormat format = PixelFormat.Format16bppGrayScale;
      Assert.AreEqual(2, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat16bppRgb555Returns2()
    {
      PixelFormat format = PixelFormat.Format16bppRgb555;
      Assert.AreEqual(2, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat16bppRgb565Returns2()
    {
      PixelFormat format = PixelFormat.Format16bppRgb565;
      Assert.AreEqual(2, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat24bppRgbReturns3()
    {
      PixelFormat format = PixelFormat.Format24bppRgb;
      Assert.AreEqual(3, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat32bppArgbReturns4()
    {
      PixelFormat format = PixelFormat.Format32bppArgb;
      Assert.AreEqual(4, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat32bppPArgbReturns4()
    {
      PixelFormat format = PixelFormat.Format32bppPArgb;
      Assert.AreEqual(4, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat32bppRgbReturns4()
    {
      PixelFormat format = PixelFormat.Format32bppRgb;
      Assert.AreEqual(4, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat48bppRgbReturns6()
    {
      PixelFormat format = PixelFormat.Format48bppRgb;
      Assert.AreEqual(6, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat64bppArgbReturns8()
    {
      PixelFormat format = PixelFormat.Format64bppArgb;
      Assert.AreEqual(8, format.GetBytesPerPixel());
    }

    [Test]
    public void WhenGetBytesPerPixelWithFormat64bppPArgbReturns8()
    {
      PixelFormat format = PixelFormat.Format64bppPArgb;
      Assert.AreEqual(8, format.GetBytesPerPixel());
    }
  }
}
