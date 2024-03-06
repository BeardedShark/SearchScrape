using SearchScraper;

namespace SearchScrapAPI.Infrastructure.Interfaces
{
    public interface ISEOSearch
    {
        public Task<List<SEOResult>> SearchScrape(string url, string phrase);
    }
}
