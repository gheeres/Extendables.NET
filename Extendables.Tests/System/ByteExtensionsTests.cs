using System;
using NUnit.Framework;

namespace Extendables.Tests.System
{
  [TestFixture]
  public class ByteExtensionsTests
  {
    [Test]
    public void WhenIsOddWithEvenNumberReturnsFalse()
    {
      const byte value = 2;
      Assert.IsFalse(value.IsOdd());
    }

    [Test]
    public void WhenIsOddWithOddNumberReturnsTrue()
    {
      const byte value = 1;
      Assert.IsTrue(value.IsOdd());
    }

    [Test]
    public void WhenIsEvenWithOddNumberReturnsFalse()
    {
      const byte value = 1;
      Assert.IsFalse(value.IsEven());
    }

    [Test]
    public void WhenIsEvenWithEvenNumberReturnsTrue()
    {
      const byte value = 2;
      Assert.IsTrue(value.IsEven());
    }

    [Test]
    public void WhenIsDivisibleBy3With27ReturnsTrue()
    {
      const byte value = 27;
      const byte divisor = 3;
      Assert.IsTrue(value.IsDivisibleBy(divisor));
    }

    [Test]
    public void WhenIsDivisibleBy3With29ReturnsFalse()
    {
      const byte value = 29;
      const byte divisor = 3;
      Assert.IsFalse(value.IsDivisibleBy(divisor));
    }
  }
}
