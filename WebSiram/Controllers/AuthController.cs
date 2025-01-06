using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebSiram.ViewModels;

namespace WebSiram.Controllers
{
    public class AuthController : Controller
    {
        private IConfiguration _config;
        public AuthController( IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        // POST: AuthController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel collection)
        {
            string ApiUrl = _config["AppSettings:ApiUrl"];
            ResponseLoginViewModel? ObjResponse = new ResponseLoginViewModel();
            try
            {
                //string email = collection["email"];
                //string password = collection["password"];
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
                    HttpResponseMessage Res = await client.PostAsync("api/Auth/Login", httpContent);
                    if (Res.IsSuccessStatusCode)
                    {
                        var Response = Res.Content.ReadAsStringAsync().Result;
                        ObjResponse = JsonConvert.DeserializeObject<ResponseLoginViewModel>(Response);
                        if (ObjResponse.code == 200)
                        {
                            HttpContext.Session.SetString("user_id", ObjResponse.user_id.ToString());
                            HttpContext.Session.SetString("username", ObjResponse.username.ToString());
                            HttpContext.Session.SetString("password", collection.password);
                            //HttpContext.Session.SetString("role", ObjResponse.role.ToString());
                            HttpContext.Session.SetString("token", ObjResponse.token.ToString());

                            //var result = await _signInManager.PasswordSignInAsync(collection.email, collection.password, false, false);
                            return Redirect("~/Home/Index");
                        }
                        else
                        {
                            return View("Index");
                        }
                    }
                    else
                    {
                        return View("Index");
                    }
                }
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
