using System.Net.Http.Headers;


namespace QuoteReader.Services
{
    public class QuoteService
    {

        public static async Task<Quote> GetQuote(int? id)
        {
            // var html = 
            return new Quote { Id =0, Description = "", Title = "", Viewed = false, PostedDate = DateTime.Now };
        }

    }
}