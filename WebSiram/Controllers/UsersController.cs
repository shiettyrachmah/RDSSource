using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebSiram.Models;
using WebSiram.ViewModels;

namespace WebSiram.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private IConfiguration _config;
        public UsersController(ILogger<UsersController> logger, IConfiguration config)
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

            List<User>? users = new List<User>();

            string ApiUrl = _config["AppSettings:ApiUrl"];

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                HttpResponseMessage Res = await client.GetAsync("api/Users/");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<User>>(Response);
                }
                return View(users);
            }
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetString("user_id") == null)
            {
                //return RedirectToAction("Logout", "Auth");
            }
            string? accessToken = HttpContext.Session.GetString("token");

            UserVM? user = new UserVM();

            string ApiUrl = _config["AppSettings:ApiUrl"];

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                HttpResponseMessage Res = await client.GetAsync("api/Users/" + id);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<UserVM>(Response);
                }
            }

            List<SelectItem> statusSelectItems = new List<SelectItem>();
            statusSelectItems.Add(new SelectItem { value = 0, text = "Tidak Aktif" });
            statusSelectItems.Add(new SelectItem { value = 1, text = "Aktif" });
            ViewBag.Status = statusSelectItems;

            return View(user);
        }

        // GET: UsersController/Edit/5
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User collection)
        {
            if (HttpContext.Session.GetString("user_id") == null)
            {
                //return RedirectToAction("Logout", "Auth");
            }
            string? accessToken = HttpContext.Session.GetString("token");

            string ApiUrl = _config["AppSettings:ApiUrl"];
            ResponseLoginViewModel? ObjResponse = new ResponseLoginViewModel();
            try
            {
                var FormString = JsonConvert.SerializeObject(collection);
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri(ApiUrl);
                    HttpContent httpContent = new StringContent(FormString);
                    httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    HttpResponseMessage Res = await client.PostAsync("api/Users/Create", httpContent);
                    if (Res.IsSuccessStatusCode)
                    {
                        var Response = Res.Content.ReadAsStringAsync().Result;
                        ObjResponse = JsonConvert.DeserializeObject<ResponseLoginViewModel>(Response);
                        if (ObjResponse.code == 200)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            return View();
                        }
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
        }

    }
}
