using System.Drawing;
using NUnit.Framework;

namespace Extendables.Tests.System.Drawing
{
  [TestFixture]
  class PointExtensionTests
  {
    [SetUp]
    public void Initialize()
    {
    }

    [Test]
    public void DistanceXWithEmptyStartPointReturns0()
    {
      Point start = Point.Empty;
      Point end = new Point(10, 10);

      Assert.AreEqual(0, start.DistanceX(end));
    }

    [Test]
    public void DistanceXWithEmptyEndPointReturns0()
    {
      Point start = new Point(10, 10);
      Point end = Point.Empty;

      Assert.AreEqual(0, start.DistanceX(end));
    }

    [Test]
    public void DistanceXWithEqualStartXAndEndXPointReturns0()
    {
      Point start = new Point(1, 10);
      Point end = new Point(1, 20);

      Assert.AreEqual(0, start.DistanceX(end));
    }

    [Test]
    public void DistanceXWithStartXLessThanEndXReturnsNegativeValue()
    {
      Point start = new Point(10, 10);
      Point end = new Point(1, 20);

      Assert.AreEqual(-9, start.DistanceX(end));
    }

    [Test]
    public void DistanceXWithStartXGreaterThanEndXReturnsPositiveValue()
    {
      Point start = new Point(1, 10);
      Point end = new Point(10, 20);

      Assert.AreEqual(9, start.DistanceX(end));
    }

    [Test]
    public void DistanceYWithEmptyStartPointReturns0()
    {
      Point start = Point.Empty;
      Point end = new Point(10, 10);

      Assert.AreEqual(0, start.DistanceY(end));
    }

    [Test]
    public void DistanceYWithEmptyEndPointReturns0()
    {
      Point start = new Point(10, 10);
      Point end = Point.Empty;

      Assert.AreEqual(0, start.DistanceY(end));
    }

    [Test]
    public void DistanceYWithEqualStartXAndEndXPointReturns0()
    {
      Point start = new Point(1, 10);
      Point end = new Point(10, 10);

      Assert.AreEqual(0, start.DistanceY(end));
    }

    [Test]
    public void DistanceYWithStartXLessThanEndXReturnsNegativeValue()
    {
      Point start = new Point(10, 40);
      Point end = new Point(1, 20);

      Assert.AreEqual(-20, start.DistanceY(end));
    }

    [Test]
    public void DistanceYWithStartXGreaterThanEndXReturnsPositiveValue()
    {
      Point start = new Point(1, 10);
      Point end = new Point(10, 20);

      Assert.AreEqual(10, start.DistanceY(end));
    }

    [Test]
    public void GetBoundingRectangleWithEmptyStartReturnsEmptyRectangle()
    {
      Point start = Point.Empty;
      Point end = new Point(10, 20);

      Assert.AreEqual(Rectangle.Empty, start.GetBoundingRectangle(end));
    }

    [Test]
    public void GetBoundingRectangleWithEmptyEndReturnsEmptyRectangle()
    {
      Point start = new Point(10, 20);
      Point end = Point.Empty;

      Assert.AreEqual(Rectangle.Empty, start.GetBoundingRectangle(end));
    }

    [Test]
    public void GetBoundingRectangleWithEqualPointReturnsRectangleWithNoWidthOrHeight()
    {
      Point start = new Point(10, 20);
      Point end = new Point(10, 20);
      Rectangle expected = new Rectangle(10, 20, 0, 0);

      Assert.AreEqual(expected, start.GetBoundingRectangle(end));
    }

    [Test]
    public void GetBoundingRectangleWithStartXLessThenEndXReturnsAdjustedRectangle()
    {
      Point start = new Point(10, 20);
      Point end = new Point(5, 25);
      Rectangle expected = new Rectangle(5, 20, 5, 5);

      Assert.AreEqual(expected, start.GetBoundingRectangle(end));
    }

    [Test]
    public void GetBoundingRectangleWithStartYLessThenEndYReturnsAdjustedRectangle()
    {
      Point start = new Point(10, 20);
      Point end = new Point(15, 10);
      Rectangle expected = new Rectangle(10, 10, 5, 10);

      Assert.AreEqual(expected, start.GetBoundingRectangle(end));
    }

    [Test]
    public void DistanceWithEmptyStartReturns0()
    {
      Point start = Point.Empty;
      Point end = new Point(10, 20);

      Assert.AreEqual(0, start.Distance(end));
    }

    [Test]
    public void DistanceWithEmptyEndReturns0()
    {
      Point start = new Point(10, 20);
      Point end = Point.Empty;

      Assert.AreEqual(0, start.Distance(end));
    }

    [Test]
    public void DistanceWithEqualPointsReturns0()
    {
      Point start = new Point(10, 20);
      Point end = new Point(10, 20);

      Assert.AreEqual(0, start.Distance(end));
    }

    [Test]
    public void DistanceReturnsEuclideanDistance()
    {
      // Using a standard 3 / 4 right angle triangle.
      // To give us a nice even return value of 5
      // a^2 + b^2 = c^2 => 9 + 16 = 25
      Point start = new Point(10, 3);
      Point end = new Point(14, 6);

      Assert.AreEqual(5, start.Distance(end));
    }
  }
}
