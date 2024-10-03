using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Features;

namespace QuoteReader.Services
{
    public class HttpService
    {

        private const string BaseUrl = "https://danstonchat.com/quote/";
        private static string GetUrl(int id)
        {
            return $"{BaseUrl}{id}.html";
        }

        public async Task<Quote> FetchQuote(int id)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            string url = GetUrl(id);
            await ProcessRepositoriesAsync(client, url);

            static async Task ProcessRepositoriesAsync(HttpClient client, string url)
            {

                var html = await client.GetStringAsync(url);
                Console.Write(html);

                var document = HtmlParserService.ParseHtml(html);
            };

            return new Quote { Id = 0, Description = "", Title = "", Viewed = false, PostedDate = DateTime.Now };
        }

    }
}