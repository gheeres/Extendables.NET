using System;
using NUnit.Framework;

namespace Extendables.Tests.System
{
  [TestFixture]
  public class Int32ExtensionsTests
  {
    [Test]
    public void WhenIsOddWithEvenNumberReturnsFalse()
    {
      const int value = 2;
      Assert.IsFalse(value.IsOdd());
    }

    [Test]
    public void WhenIsOddWithOddNumberReturnsTrue()
    {
      const int value = 1;
      Assert.IsTrue(value.IsOdd());
    }

    [Test]
    public void WhenIsEvenWithOddNumberReturnsFalse()
    {
      const int value = 1;
      Assert.IsFalse(value.IsEven());
    }

    [Test]
    public void WhenIsEvenWithEvenNumberReturnsTrue()
    {
      const int value = 2;
      Assert.IsTrue(value.IsEven());
    }

    [Test]
    public void WhenIsDivisibleBy3With27ReturnsTrue()
    {
      const int value = 27;
      const int divisor = 3;
      Assert.IsTrue(value.IsDivisibleBy(divisor));
    }

    [Test]
    public void WhenIsDivisibleBy3With29ReturnsFalse()
    {
      const int value = 29;
      const int divisor = 3;
      Assert.IsFalse(value.IsDivisibleBy(divisor));
    }
  }
}
