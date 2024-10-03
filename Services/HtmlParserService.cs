
using AngleSharp;
using AngleSharp.Dom;

namespace QuoteReader.Services
{
    public class HtmlParserService
    {



        public static async Task<IDocument> ParseHtml(string html)
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