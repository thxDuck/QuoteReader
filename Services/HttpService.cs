
namespace QuoteReader.Services
{
    public interface IHttpService
    {
        Task<string> FetchQuotePage(int id);
    }

    public class HttpService : IHttpService

    {
        private const string BaseUrl = "https://danstonchat.com/quote/";
        private static string GetUrl(int id)
        {
            return $"{BaseUrl}{id}.html";
        }

        public async Task<string> FetchQuotePage(int id)
        {
            using var httpClient = new HttpClient();

            string url = GetUrl(id);
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }
}