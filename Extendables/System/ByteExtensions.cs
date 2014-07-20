// ReSharper disable once CheckNamespace
namespace System
{
  public static class ByteExtensions
  {
    /// <summary>
    /// Checks to see if the number is odd.
    /// </summary>
    /// <param name="number">The number to inspect.</param>
    /// <returns>True if the number is odd, false if otherwise.</returns>
    public static bool IsOdd(this byte number)
    {
      return (number & 0x01) == 1;
    }

    /// <summary>
    /// Checks to see if the number is odd.
    /// </summary>
    /// <param name="number">The number to inspect.</param>
    /// <returns>True if the number is odd, false if otherwise.</returns>
    public static bool IsEven(this byte number)
    {
      return (number & 0x01) == 0;
    }

    /// <summary>
    /// Checks to see if the number is evenly divisible by the specified divisor.
    /// </summary>
    /// <param name="number">The number to inspect.</param>
    /// <param name="divisor">The number to check to see if it is divisible by.</param>
    /// <returns>True if evenly divisible, false if otherwise.</returns>
    public static bool IsDivisibleBy(this byte number, byte divisor)
    {
      return (number%divisor == 0);
    }
  }
}
