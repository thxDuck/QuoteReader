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

        private readonly string titleSelector = "main h1";
        private readonly string contentSelector = "main div:nth-child(2) p";
        private readonly MessageContent EMPTY_MESSAGE = new()
        {
            Username = "",
            Color = "",
            Text = ""
        };

        public Quote ExtractQuoteFromDocument(IDocument document)
        {
            string title = GetTitle(document);
            List<MessageContent> content = GetContent(document);

            return new Quote { Id = 0, Content = content, Title = title, Viewed = false, PostedDate = DateTime.Now };
        }

        private string GetTitle(IDocument document)
        {
            var titleElement = document.QuerySelector(titleSelector);
            if (titleElement is null) return "";

            return titleElement.TextContent;
        }

        private List<MessageContent> GetContent(IDocument document)
        {
            IElement? contentBloc = document.QuerySelector(contentSelector);

            if (contentBloc is null) return [EMPTY_MESSAGE];

            List<MessageContent> quoteContentList = [];
            IEnumerable<IElement> nodes = contentBloc.Children.Where(item => item.TagName == "SPAN" || item.TagName == "SPAN");

            foreach (IElement element in nodes)
            {
                var username = element.TextContent;
                var content = element.NextSibling?.TextContent ?? "";
                var color = element.GetStyleSheets();
                quoteContentList.Add(new() { Username = username, Color = "", Text = content });
            }
            return quoteContentList;
        }
    }
}