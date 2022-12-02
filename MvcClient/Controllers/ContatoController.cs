using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http.Extensions;
using IdentityModel.Client;
using System.Text.Json;

namespace MvcClient2.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ContatoController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var query = new QueryBuilder();
            query.Add("client_id", "client");
            query.Add("scope", "contato");
            query.Add("response_type", "code");
            query.Add("redirect_uri", "https://localhost:7080/contato/ContatoCallback");
            string url = $"https://localhost:5001/connect/authorize{query}";
            return Redirect(url);
        }

        public async Task<IActionResult> ContatoCallback(string code, string scope)
        {
            var tokenClient = new HttpClient();
            var disco = await tokenClient.GetDiscoveryDocumentAsync("https://localhost:5001");

            var tokenResponse = await tokenClient.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
            {
                Address = disco.TokenEndpoint,
                Code = code,
                RedirectUri = "https://localhost:7080/contato/ContatoCallback",
                ClientId = "client",
                ClientSecret = "secret",

            });

            var contatoClient = new HttpClient();
            contatoClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
            var response = await contatoClient.GetAsync("https://localhost:6001/contato");
            string retorno = await response.Content.ReadAsStringAsync();
            var contatos = JsonSerializer.Deserialize<List<Contato>>(retorno);
            return View("Index", contatos);
        }
    }

    public class Contato
    {
        public string nome { get; set; }
        public string telefone { get; set; }

    }
}