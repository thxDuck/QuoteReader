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
        static readonly string cssColorAttributeName = "color: ";
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
        //string colorAttributeName = "color: ";
        private string GetColorFromStyleAttribute(string cssSpanStyle)
        {
            int indexOfColorAttribute = cssSpanStyle.IndexOf(cssColorAttributeName);
            if (indexOfColorAttribute == -1) return "";

            string restOfCssColorStyle = cssSpanStyle[(indexOfColorAttribute + cssColorAttributeName.Length)..];
            string colorValue = restOfCssColorStyle.Split(';')[0];

            return colorValue;
        }
        private List<MessageContent> GetContent(IDocument document)
        {
            IElement? contentBloc = document.QuerySelector(contentSelector);

            if (contentBloc is null) return [EMPTY_MESSAGE];

            List<MessageContent> quoteContentList = [];
            IEnumerable<IElement> nodes = contentBloc.Children.Where(item => item.TagName == "SPAN" || item.TagName == "SPAN");

            foreach (IElement element in nodes)
            {
                string color = "RGB(170, 170, 170)";
                var username = element.TextContent;
                var content = element.NextSibling?.TextContent ?? "";
                IEnumerable<IStyleSheet> styles = element.GetStyleSheets();
                var styleAttribute = element.GetAttribute("style");

                bool isColorAttributePresent = styleAttribute?.IndexOf("color: ") >= 0;
                if (styleAttribute != null && isColorAttributePresent)
                {
                    color = GetColorFromStyleAttribute(styleAttribute);
                }

                quoteContentList.Add(new() { Username = username, Color = color, Text = content });
            }
            return quoteContentList;
        }
    }
}