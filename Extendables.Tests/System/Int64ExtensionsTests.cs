using System;
using NUnit.Framework;

namespace Extendables.Tests.System
{
  [TestFixture]
  public class Int64ExtensionsTests
  {
    [Test]
    public void WhenIsOddWithEvenNumberReturnsFalse()
    {
      const long value = 2;
      Assert.IsFalse(value.IsOdd());
    }

    [Test]
    public void WhenIsOddWithOddNumberReturnsTrue()
    {
      const long value = 1;
      Assert.IsTrue(value.IsOdd());
    }

    [Test]
    public void WhenIsEvenWithOddNumberReturnsFalse()
    {
      const long value = 1;
      Assert.IsFalse(value.IsEven());
    }

    [Test]
    public void WhenIsEvenWithEvenNumberReturnsTrue()
    {
      const long value = 2;
      Assert.IsTrue(value.IsEven());
    }

    [Test]
    public void WhenIsDivisibleBy3With27ReturnsTrue()
    {
      const long value = 27;
      const long divisor = 3;
      Assert.IsTrue(value.IsDivisibleBy(divisor));
    }

    [Test]
    public void WhenIsDivisibleBy3With29ReturnsFalse()
    {
      const long value = 29;
      const long divisor = 3;
      Assert.IsFalse(value.IsDivisibleBy(divisor));
    }
  }
}
