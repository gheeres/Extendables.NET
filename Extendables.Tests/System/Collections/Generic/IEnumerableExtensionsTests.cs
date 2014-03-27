using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Extendables.Tests.System.Collections.Generic
{
  [TestFixture]
  public class IEnumerableExtensionsTests
  {
    [Test]
    public void ForEachWithNullIEnumerableThenNothingHappens()
    {
      IEnumerable<int> items = null;
      items.ForEach((i) => {
        Assert.Fail("Items were executed on an null ForEach enumeration when they should not have.");
      });
      Assert.Pass();
    }

    [Test]
    public void ForEachWithEmptyIEnumerableThenNothingHappens()
    {
      IEnumerable<int> items = new int[0];
      items.ForEach((i) => {
        Assert.Fail("Items were executed on an empty ForEach enumeration when they should not have.");
      });
      Assert.Pass();
    }

    [Test]
    public void ForEachThenEachItemIterated()
    {
      IEnumerable<int> items = new[] { 1, 2, 3, 4, 5 };
      items.ForEach((i) => {
        Assert.Contains(i, items.ToList());
      });
    }

    [Test]
    public void ForEachThenAllItemsIterated()
    {
      int count = 0;
      IEnumerable<int> items = new[] { 1, 2, 3, 4, 5 };
      items.ForEach((i) => {
        count++;
      });
      Assert.AreEqual(items.Count(), count);
    }
  }
}
