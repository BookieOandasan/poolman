using NUnit.Framework;
using Poolman.Repository;
using System.Linq;

namespace Tests
{
    public class DailyReadingUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetRssFeeds()
        {

            var dbContext = new CatholicFeedDataContext();

            var feeds = dbContext.RssFeeds.ToList();

            Assert.Pass();
        }

        [Test]
        public void GetRssFeedsCurrentDate()
        {

            var dbContext = new CatholicFeedDataContext();

            var feeds = dbContext.GetRssFeedByCurrentDate("dailyReading").ToList();

            Assert.Pass();
        }
    }
}

