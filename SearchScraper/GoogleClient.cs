using System.Security.Claims;
using System.Web;

namespace SearchScraper
{
    public class GoogleClient : ISearchClient
    {
        public async Task<List<string>> Scrape(string url, string query)
        {
            var client = new HttpClient();

            var phraseParsed = query.Replace(" ", "+");

            var Path = $"{url}/search?num=100&q={phraseParsed}";

            var response = await client.GetStringAsync(Path);

            if (!string.IsNullOrEmpty(response))
            {
                var content = HttpUtility.HtmlDecode(response);

                var results = SplitResults(content);

                return results;
            }
            else
            {
                return null;
            }
        }

        private List<string> SplitResults(string content)
        {
            var results = new List<string>();

            var firstSplit = content.Split("<div class=\"egMi0 kCrYT\"><a href=\"/url?q=").ToList();
            firstSplit.RemoveAt(0);

            foreach (var item in firstSplit)
            {
                var anchor = item.Split('"')[0];

                results.Add(anchor);
            }

            return results;
        }
    }
}
