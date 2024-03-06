using SearchScrapAPI.Infrastructure.Interfaces;
using SearchScraper;
using System;

namespace SearchScrapAPI.Infrastructure.Services
{
    public class SEOHistoryRepo : ISEOHistoryRepository
    {
        public async Task<List<SEOResult>> GetHistoryForPhrase(string phrase, string url)
        {
            var results = new List<SEOResult>();
            Random random = new Random();

            results.Add(new SEOResult()
            {
                Phrase = phrase,
                Rank = random.Next(1, 100),
                URL = url,
                Engine = "Google",
                Scraped = DateTime.Now.AddDays(random.Next(-28, -1))
            });
            results.Add(new SEOResult()
            {
                Phrase = phrase,
                Rank = random.Next(1, 100),
                URL = url,
                Engine = "Google",
                Scraped = DateTime.Now.AddDays(random.Next(-28, -1))
            });
            results.Add(new SEOResult()
            {
                Phrase = phrase,
                Rank = random.Next(1, 100),
                URL = url,
                Engine = "Bing",
                Scraped = DateTime.Now.AddDays(random.Next(-28, -1))
            });
            results.Add(new SEOResult()
            {
                Phrase = phrase,
                Rank = random.Next(1, 100),
                URL = url,
                Engine = "Bing",
                Scraped = DateTime.Now.AddDays(random.Next(-28, -1))
            });
            results.Add(new SEOResult()
            {
                Phrase = phrase,
                Rank = random.Next(1, 100),
                URL = url,
                Engine = "Google",
                Scraped = DateTime.Now.AddDays(random.Next(-28, -1))
            });

            return results;
        }
    }
}
