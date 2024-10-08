using AngleSharp.Css.Dom;
using AngleSharp.Dom;

namespace QuoteReader.Services
{

    public interface IQuoteExtractor
    {
        public Quote ExtractQuoteFromDocument(IDocument document);
    }
    public class QuoteExtractorService : IQuoteExtractor
    {

        private string titleSelector = "main h1";
        private string contentSelector = "main div:nth-child(2) p";

        public Quote ExtractQuoteFromDocument(IDocument document)
        {
            string title = GetTitle(document);
            List<QuoteContent> content = GetContent(document);

            return new Quote { Id = 0, Content = content, Title = title, Viewed = false, PostedDate = DateTime.Now };
        }

        private string GetTitle(IDocument document)
        {
            var titleElement = document.QuerySelector(titleSelector);
            if (titleElement is null) return "";

            return titleElement.TextContent;
        }

        private List<QuoteContent> GetContent(IDocument document)
        {
            IElement? contentBloc = document.QuerySelector(contentSelector);
            if (contentBloc is null) return [new QuoteContent { Username = "", Color = "", Message = "" }];
            List<QuoteContent> quoteContentList = [];
            IEnumerable<IElement> nodes = contentBloc.Children.Where(item => item.TagName == "SPAN" || item.TagName == "SPAN");

            foreach (IElement element in nodes)
            {
                var username = element.TextContent;
                var content = element.NextSibling?.TextContent ?? "";
                var color = element.GetStyleSheets();
                quoteContentList.Add(new QuoteContent { Username = username, Color = "", Message = content });
            }
            return quoteContentList;
        }
    }
}