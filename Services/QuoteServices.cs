

namespace QuoteReader.Services
{
    public class QuoteService(IHttpService httpService, IHtmlParserService htmlParser, IQuoteExtractor quoteExtractor)
    {
        private readonly IHttpService _httpService = httpService;
        private readonly IHtmlParserService _htmlParser = htmlParser;
        private readonly IQuoteExtractor _quoteExtractor = quoteExtractor;

        public async Task<Quote?> GetQuoteFromWeb(int id)
        {
            var html = await _httpService.FetchQuotePage(id);
            var document = await _htmlParser.Parse(html);

            return _quoteExtractor.ExtractQuoteFromDocument(document);
        }
    }
}