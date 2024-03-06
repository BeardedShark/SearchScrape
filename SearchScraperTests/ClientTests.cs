using SearchScraper;

namespace SearchScraperTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GoogleTest()
        {
            var sClient = new GoogleClient();


            var res = await sClient.Scrape("https://www.google.co.uk","land registry search");

            Assert.IsNotNull(res);
            Assert.That(res.Where(r => r.Contains("www.infotrack.co.uk")).Count() > 0);
        }

        [Test]
        public async Task BingTest()
        {
            var sClient = new BingClient();


            var res = await sClient.Scrape("https://www.bing.com", "land registry search");

            Console.WriteLine(res.Count);
            Console.WriteLine(res[0]);

            Assert.IsNotNull(res);
            Assert.That(res.Count > 1);
        }
    }
}