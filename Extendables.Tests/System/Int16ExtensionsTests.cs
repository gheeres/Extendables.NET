using System;
using NUnit.Framework;

namespace Extendables.Tests.System
{
  [TestFixture]
  public class Int16ExtensionsTests
  {
    [Test]
    public void WhenIsOddWithEvenNumberReturnsFalse()
    {
      const short value = 2;
      Assert.IsFalse(value.IsOdd());
    }

    [Test]
    public void WhenIsOddWithOddNumberReturnsTrue()
    {
      const short value = 1;
      Assert.IsTrue(value.IsOdd());
    }

    [Test]
    public void WhenIsEvenWithOddNumberReturnsFalse()
    {
      const short value = 1;
      Assert.IsFalse(value.IsEven());
    }

    [Test]
    public void WhenIsEvenWithEvenNumberReturnsTrue()
    {
      const short value = 2;
      Assert.IsTrue(value.IsEven());
    }

    [Test]
    public void WhenIsDivisibleBy3With27ReturnsTrue()
    {
      const short value = 27;
      const short divisor = 3;
      Assert.IsTrue(value.IsDivisibleBy(divisor));
    }

    [Test]
    public void WhenIsDivisibleBy3With29ReturnsFalse()
    {
      const short value = 29;
      const short divisor = 3;
      Assert.IsFalse(value.IsDivisibleBy(divisor));
    }
  }
}
