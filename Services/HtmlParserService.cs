
using AngleSharp;
using AngleSharp.Dom;
using Mono.TextTemplating;

namespace QuoteReader.Services
{

    public interface IHtmlParserService
    {
        Task<IDocument> Parse(string html);
    }
    
    public class HtmlParserService : IHtmlParserService
    {
        public async Task<IDocument> Parse(string html)
        {
            //Use the default configuration for AngleSharp
            var config = Configuration.Default;

            //Create a new context for evaluating webpages with the given config
            IBrowsingContext context = BrowsingContext.New(config);

            //Just get the DOM representation
            IDocument document = await context.OpenAsync(req => req.Content(html));

            //Serialize it back to the console
            Console.WriteLine(document.DocumentElement.OuterHtml);
            return document;
        }

    }
}