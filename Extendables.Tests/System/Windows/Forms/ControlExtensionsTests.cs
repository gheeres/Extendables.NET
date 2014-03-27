using System.Windows.Forms;
using NUnit.Framework;

namespace Extendables.Tests.Windows.Forms
{
  [TestFixture]
  class ControlExtensionsTests
  {
    [SetUp]
    public void Initialize()
    {
    }

    [Test]
    public void RunOnUiThreadWithNullControlDoesNothing()
    {
      Control control = null;
      
      control.RunOnUiThread(() => {
        Assert.Fail("The code should not run on a null control UI thread.");
      });
      Assert.Pass();
    }
  }
}
