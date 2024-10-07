

namespace QuoteReader.Services
{
    public class QuoteService
    {
        private readonly IHttpService _httpService;
        private readonly IHtmlParserService _htmlParser;

        // Constructeur, permet de créer une instance avec injection des dépendances.
        // Cela permet de ne pas être dépendant, par exemple pour faire un Mock ou un Stub,
        // on peut facilement injecter une instance d'une classe qui contiens les fonctions nécessaire !
        public QuoteService(IHttpService httpService, IHtmlParserService htmlParser)
        {
            _httpService = httpService;
            _htmlParser = htmlParser;
        }

        public async Task<Quote?> GetQuote(int id)
        {
            var html = await _httpService.GetHtmlContentAsync(id);
            var document = await _htmlParser.Parse(html);

            // TODO : extraction des données de la quote !
            return new Quote { Id = 0, Description = "", Title = "", Viewed = false, PostedDate = DateTime.Now };
        }
    }
}