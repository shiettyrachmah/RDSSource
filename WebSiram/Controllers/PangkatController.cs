using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebSiram.Models;

namespace WebSiram.Controllers
{
    public class PangkatController : Controller
    {
        private readonly ILogger<PangkatController> _logger;
        private IConfiguration _config;
        public PangkatController(ILogger<PangkatController> logger, IConfiguration config)
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

            List<Pangkat>? pangkat = new List<Pangkat>();

            string ApiUrl = _config["AppSettings:ApiUrl"];

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                HttpResponseMessage Res = await client.GetAsync("api/Pangkat");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    pangkat = JsonConvert.DeserializeObject<List<Pangkat>>(Response);
                }
                else
                {
                    return RedirectToAction("Index", "Auth");
                }
                return View(pangkat);
            }
        }
    }
}
