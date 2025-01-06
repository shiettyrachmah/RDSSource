
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebSiram.Models;
using WebSiram.ViewModels;

namespace WebSiram.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ILogger<ActivitiesController> _logger;
        private IConfiguration _config;
        public ActivitiesController(ILogger<ActivitiesController> logger, IConfiguration config)
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

            List<Activity>? activity = new List<Activity>();

            string ApiUrl = _config["AppSettings:ApiUrl"];

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                HttpResponseMessage Res = await client.GetAsync("api/Activity/GetActive");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    activity = JsonConvert.DeserializeObject<List<Activity>>(Response);
                }
                else
                {
                    return RedirectToAction("Index", "Auth");
                }
                return View(activity);
            }
        }

        // GET: UsersController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (HttpContext.Session.GetString("user_id") == null)
            {
                //return RedirectToAction("Logout", "Auth");
            }
            string? accessToken = HttpContext.Session.GetString("token");

            ActivityVM? activity = new ActivityVM();

            string ApiUrl = _config["AppSettings:ApiUrl"];

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                HttpResponseMessage Res = await client.GetAsync("api/Activity/Details/" +id);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    activity = JsonConvert.DeserializeObject<ActivityVM>(Response);
                }
                else
                {
                    return RedirectToAction("Index", "Auth");
                }
                return View(activity);
            }
        }










    }
}
