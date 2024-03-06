using SearchScrapAPI.Infrastructure.Interfaces;
using SearchScraper;

namespace SearchScrapAPI.Infrastructure.Services
{
    public class SEOSearch : ISEOSearch
    {
        public async Task<List<SEOResult>> SearchScrape(string url, string phrase)
        {
            var results = new List<SEOResult>();

            var gSearch = new GoogleClient();
            var gResults = await gSearch.Scrape("https://www.google.co.uk",phrase);

            foreach (var result in gResults)
            {
                if(result.ToLower().Contains(url.ToLower()))
                {
                    var rank = gResults.FindIndex(x => x == result);
                    results.Add(new SEOResult() { Phrase = phrase, Rank = rank + 1, URL = url, Engine = "Google", Scraped = DateTime.Now });
                }
                
            }

            var bSearch = new BingClient();
            var bResults = await bSearch.Scrape("https://www.bing.com",phrase);

            foreach (var result in bResults)
            {
                if (result.ToLower().Contains(url.ToLower()))
                {
                    var rank = bResults.FindIndex(x => x == result);
                    results.Add(new SEOResult() { Phrase = phrase, Rank = rank + 1, URL = url, Engine = "Bing", Scraped = DateTime.Now });
                }

            }

            return results;
        }
    }
}
