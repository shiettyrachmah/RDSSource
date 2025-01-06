using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using WebSiram.Models;
using WebSiram.ViewModels;

namespace WebSiram.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Datakara()
        {
            if (HttpContext.Session.GetString("user_id") == null)
            {
                //return RedirectToAction("Logout", "Auth");
            }

            string ApiUrl = _config["AppSettings:ApiUrl"];
            string? username = HttpContext.Session.GetString("username");
            string? password = HttpContext.Session.GetString("password");
            string? accessToken = HttpContext.Session.GetString("token");

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.username = username;
            loginViewModel.password = password;

            GeneralResponse ObjResponse = new GeneralResponse();

            var FormString = JsonConvert.SerializeObject(loginViewModel);
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ApiUrl);
                HttpContent httpContent = new StringContent(FormString);
                client.DefaultRequestHeaders.Clear();
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                HttpResponseMessage Res = await client.PostAsync("svc/Identity/CreateAccess", httpContent);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    ObjResponse = JsonConvert.DeserializeObject<GeneralResponse>(Response);
                }
                else
                {
                    return RedirectToAction("Index","Auth");
                }
            }

            string code = ObjResponse.data;

            return Redirect("http://project.siklus.id/datakara-siram/?code=" + code);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
