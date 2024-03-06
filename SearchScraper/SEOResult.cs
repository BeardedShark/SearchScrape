using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchScraper
{
    public class SEOResult
    {
        public int Rank { get; set; }

        public string URL { get; set; }

        public string Phrase { get; set; }

        public string Engine { get; set; }

        public DateTime Scraped { get; set; }
    }
}
