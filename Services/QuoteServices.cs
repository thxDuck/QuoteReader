

namespace QuoteReader.Services
{
    public class QuoteService(IHttpService httpService, IHtmlParserService htmlParser, IQuoteExtractor quoteExtractor)
    {
        private readonly IHttpService _httpService = httpService;
        private readonly IHtmlParserService _htmlParser = htmlParser;
        private readonly IQuoteExtractor _quoteExtractor = quoteExtractor;

        public async Task<Quote?> GetQuoteFromWeb(int id)
        {
            try
            {
                var html = await _httpService.FetchQuotePage(id);
                if (html == "")
                {
                    Console.WriteLine("Error when fetching html !");
                    return null;
                }
                var document = await _htmlParser.Parse(html);
                var quote = _quoteExtractor.ExtractQuoteFromDocument(document);

                if (quote == null)
                {
                    Console.WriteLine("Error when parseing HTML");
                    return null;
                }
                return quote;
            }
            catch (Exception exeption)
            {
                Console.WriteLine("Processing failed.");
                Console.WriteLine(exeption.ToString());
                return null;
            }

        }
    }
}