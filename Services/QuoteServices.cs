using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Features;

namespace QuoteReader.Services
{
    public class QuoteService
    {

        public static async Task<Quote> FetchQuote(int? Id)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            await ProcessRepositoriesAsync(client);

            static async Task ProcessRepositoriesAsync(HttpClient client)
            {
                var html = await client.GetStringAsync("https://danstonchat.com/quote/5.html");
                Console.Write(html);
            }

            return new Quote { Id =0, Description = "", Title = "", Viewed = false, PostedDate = DateTime.Now };


        }

    }
}