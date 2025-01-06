using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebSiram.Models;

namespace WebSiram.Controllers
{
    public class DivisiController : Controller
    {
        private readonly ILogger<DivisiController> _logger;
        private IConfiguration _config;
        public DivisiController(ILogger<DivisiController> logger, IConfiguration config)
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

            List<Divisi>? divisi = new List<Divisi>();

            string ApiUrl = _config["AppSettings:ApiUrl"];

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                HttpResponseMessage Res = await client.GetAsync("api/Divisi");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    divisi = JsonConvert.DeserializeObject<List<Divisi>>(Response);
                }
                else
                {
                    return RedirectToAction("Index", "Auth");
                }
                return View(divisi);
            }
        }
    }
}
