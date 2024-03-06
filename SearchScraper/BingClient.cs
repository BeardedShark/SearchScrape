using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SearchScraper
{
    public class BingClient : ISearchClient
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

            var firstSplit = content.Split("<span class=\"b_icondomian\">").ToList();
            firstSplit.RemoveAt(0);

            foreach (var item in firstSplit)
            {
                var anchor = item.Split("</span>")[0];

                results.Add(anchor);
            }

            return results;
        }
    }
}
