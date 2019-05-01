using NUnit.Framework;
using Poolman.Repository;
using System.Linq;

namespace Tests
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {

      var dbContext = new CatholicFeedDataContext();

      var feeds = dbContext.RssFeeds.ToList();

      Assert.Pass();
    }
  }
}
