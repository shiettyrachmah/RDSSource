using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebSiram.Models;

namespace WebSiram.Controllers
{
    public class KomandoController : Controller
    {
        private readonly ILogger<KomandoController> _logger;
        private IConfiguration _config;
        public KomandoController(ILogger<KomandoController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("user_id") == null)
            {
                //return RedirectToAction("Logout", "Auth");
            }
            string? accessToken = HttpContext.Session.GetString("token");

            List<Komando>? komando = new List<Komando>();

            string ApiUrl = _config["AppSettings:ApiUrl"];

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                HttpResponseMessage Res = await client.GetAsync("api/Komando");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    komando = JsonConvert.DeserializeObject<List<Komando>>(Response);
                }
                else
                {
                    return RedirectToAction("Index", "Auth");
                }
                return View(komando);
            }
        }
    }
}
