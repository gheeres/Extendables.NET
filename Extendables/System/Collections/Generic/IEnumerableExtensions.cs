// ReSharper disable once CheckNamespace
namespace System.Collections.Generic
{
  /// <summary>
  /// Extension methods for the IEnumerable class.
  /// </summary>
  public static class IEnumerableExtensions
  {
    /// <summary>
    /// Performs the specified action on each element of the IEnumerable.
    /// </summary>
    /// <typeparam name="T">The type of the items</typeparam>
    /// <param name="source">The items to interate through.</param>
    /// <param name="action">The Action delegate to perform on each element of the IEnumerable.</param>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
      if (source == null) return;
      foreach (T item in source) {
        action(item);
      }
    }
  }
}
