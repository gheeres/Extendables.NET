namespace System.Windows.Forms
{
  /// <summary>
  /// Extension methods for the System.Windows.Forms.Control class.
  /// </summary>
  public static class ControlExtensions
  {
    /// <summary>
    /// Ensures that the specified <see cref="Action"/> runs on the UI thread.
    /// </summary>
    /// <param name="control">The control.</param>
    /// <param name="action">The action to execute.</param>
    public static void RunOnUiThread(this Control control, Action action)
    {
      if (control == null) return;
      
      if (control.InvokeRequired) control.Invoke(action);
      else action.Invoke();
    }
  }
}