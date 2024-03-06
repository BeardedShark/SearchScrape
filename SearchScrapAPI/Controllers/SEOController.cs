using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchScrapAPI.Infrastructure.Interfaces;
using SearchScrapAPI.Models.Request;
using SearchScrapAPI.Models.Response;
using SearchScraper;
using System.Text;

namespace SearchScrapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SEOController : ControllerBase
    {
        private readonly ISEOSearch _SEOSearch;
        private readonly ISEOHistoryRepository _SEOHistoryRepo;

        public SEOController(ISEOSearch SEO, ISEOHistoryRepository SEOHis)
        {
            _SEOSearch = SEO;
            _SEOHistoryRepo = SEOHis;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(
            "<strong>Healthy</strong>",
            Encoding.UTF8,
            "text/html"
        )
            };
        }

        [HttpPost]
        public async Task<SEOResponse> Post([FromBody]SEORequest req)
        {
            if (!string.IsNullOrEmpty(req.Phrase) && !string.IsNullOrEmpty(req.URL))
            {
                try
                {
                    var response = new SEOResponse();

                    var results = await _SEOSearch.SearchScrape(req.URL, req.Phrase);
                    results.AddRange(await _SEOHistoryRepo.GetHistoryForPhrase(req.URL, req.Phrase));
                    results = results.OrderByDescending(x => x.Scraped).ToList();

                    response.Success = true;
                    response.Message = "success";
                    response.SEOResults = results;

                    return response;
                }
                catch (Exception ex)
                {
                    return new SEOResponse()
                    {
                        Success = false,
                        Message = ex.Message,
                        SEOResults = new List<SEOResult>() {
                        new SEOResult() { Engine = "Engine",
                            Phrase = "Phrase", Rank = 1, URL = "URL" } }
                    };
                }

            }
            else
            {
                return new SEOResponse()
                {
                    Success = true,
                    Message = "",
                    SEOResults = new List<SEOResult>() {
                        new SEOResult() { Engine = "Engine",
                            Phrase = "Phrase", Rank = 1, URL = "URL" } }
                };
            }
        }
    }
}
