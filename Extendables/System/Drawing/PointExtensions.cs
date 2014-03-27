// ReSharper disable once CheckNamespace
namespace System.Drawing
{
  /// <summary>
  /// Extension methods for the <see cref="Point"/> class.
  /// </summary>
  public static class PointExtensions
  {
    /// <summary>
    /// Calculates the X distance between the two points. The value returned can be positive or negative.
    /// </summary>
    /// <param name="start">The starting reference Point.</param>
    /// <param name="end">The distance being calculated.</param>
    /// <returns>The positive or negative distance in the the X coordinate space.</returns>
    public static int DistanceX(this Point start, Point end)
    {
      if ((start.IsEmpty) || (end.IsEmpty)) return (0);
      return (end.X - start.X);
    }

    /// <summary>
    /// Calculates the Y distance between the two points. The value returned can be positive or negative.
    /// </summary>
    /// <param name="start">The starting reference Point.</param>
    /// <param name="end">The distance being calculated.</param>
    /// <returns>The positive or negative distance in the the Y coordinate space.</returns>
    public static int DistanceY(this Point start, Point end)
    {
      if ((start.IsEmpty) || (end.IsEmpty)) return (0);
      return (end.Y - start.Y);
    }

    /// <summary>
    /// Calculates the eclidean distance between the two points.
    /// </summary>
    /// <param name="start">The starting reference Point.</param>
    /// <param name="end">The distance being calculated.</param>
    /// <returns>The distance between the two points.</returns>
    public static double Distance(this Point start, Point end)
    {
      if ((start == Point.Empty) || (end == Point.Empty)) return (0);
      return(Math.Sqrt(Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2)));
    }

    /// <summary>
    /// Get's the bounding rectangle for the two points. 
    /// </summary>
    /// <param name="start">The starting reference point.</param>
    /// <param name="end">The ending reference point.</param>
    /// <returns>The bounding rectangle for the points. If either point is <see cref="Point.Empty"/> then a <see cref="Rectangle.Empty"/> is returned.</returns>
    public static Rectangle GetBoundingRectangle(this Point start, Point end)
    {
      if ((start == Point.Empty) || (end == Point.Empty)) return (Rectangle.Empty);
      return (new Rectangle(Math.Min(start.X, end.X),
                            Math.Min(start.Y, end.Y),
                            Math.Abs(end.X - start.X), 
                            Math.Abs(end.Y - start.Y)));
    }
  }
}