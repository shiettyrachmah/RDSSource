using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using WebSiram.Models;

namespace WebSiram.Controllers
{
    public class GroupsController : Controller
    {
        private readonly ILogger<GroupsController> _logger;
        private IConfiguration _config;
        public GroupsController(ILogger<GroupsController> logger, IConfiguration config)
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

            List<MGroup>? groups = new List<MGroup>();

            string ApiUrl = _config["AppSettings:ApiUrl"];

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                HttpResponseMessage Res = await client.GetAsync("api/Groups");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    groups = JsonConvert.DeserializeObject<List<MGroup>>(Response);
                }
                else
                {
                    return RedirectToAction("Index", "Auth");
                }
                return View(groups);
            }
        }
    }
}
