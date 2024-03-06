using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchScraper
{
    public interface ISearchClient
    {
        public Task<List<string>> Scrape(string url, string query);
    }
}
