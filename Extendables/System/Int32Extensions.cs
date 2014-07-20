// ReSharper disable once CheckNamespace
namespace System
{
  public static class Int32Extensions
  {
    /// <summary>
    /// Checks to see if the number is odd.
    /// </summary>
    /// <param name="number">The number to inspect.</param>
    /// <returns>True if the number is odd, false if otherwise.</returns>
    public static bool IsOdd(this int number)
    {
      return (number & 1) != 0;
    }

    /// <summary>
    /// Checks to see if the number is odd.
    /// </summary>
    /// <param name="number">The number to inspect.</param>
    /// <returns>True if the number is odd, false if otherwise.</returns>
    public static bool IsEven(this int number)
    {
      return (number & 1) == 0;
    }

    /// <summary>
    /// Checks to see if the number is evenly divisible by the specified divisor.
    /// </summary>
    /// <param name="number">The number to inspect.</param>
    /// <param name="divisor">The number to check to see if it is divisible by.</param>
    /// <returns>True if evenly divisible, false if otherwise.</returns>
    public static bool IsDivisibleBy(this int number, int divisor)
    {
      return (number%divisor == 0);
    }
  }
}
