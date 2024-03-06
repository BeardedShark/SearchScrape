using SearchScraper;

namespace SearchScrapAPI.Infrastructure.Interfaces
{
    public interface ISEOHistoryRepository
    {
        public Task<List<SEOResult>> GetHistoryForPhrase(string phrase, string url);
    }
}
