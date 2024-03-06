using SearchScraper;

namespace SearchScrapAPI.Models.Response
{
    public class SEOResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public List<SEOResult> SEOResults { get; set; }
    }
}
