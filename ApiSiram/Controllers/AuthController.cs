using ApiSiram.Models;
using ApiSiram.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSiram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SIRAMDBContext _db;
        private IConfiguration _config;

        public AuthController(IConfiguration config, SIRAMDBContext context)
        {
            _db = context;
            _config = config;
        }

        // POST api/<AuthController>
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ResponseLogin>> Login([FromBody] RequestLogin content)
        {
            string ip = HttpContext.Connection.RemoteIpAddress?.ToString();

            var userAgent = HttpContext.Request.Headers.UserAgent;
            try
            {
                var user = await _db.Users.Where(m => m.username == content.username && m.status == 1).FirstOrDefaultAsync();
                if (user != null)
                {
                    bool verified = BCrypt.Net.BCrypt.Verify(content.password, user.password);
                    if (verified)
                    {
                        List<AuthUserGroupVM> authUserGroupVM = new List<AuthUserGroupVM>();

                        var usergroups = from UG in _db.UserGroups
                                         join GRP in _db.Groups
                                         on UG.group_id equals GRP.id
                                         where UG.user_id == user.user_id
                                         select new AuthUserGroupVM { id=GRP.id, group_name = GRP.group_name };

                        ProfileVM profile = new ProfileVM();
                        Personel personel = await _db.Personels.Where(m=> m.user_id == user.user_id).FirstOrDefaultAsync();
                        if(personel != null)
                        {
                            profile.id = personel.id;
                            profile.user_id = personel.user_id;
                            profile.upline_id = personel.upline_id;
                            profile.nrp = personel.nrp; 
                            profile.divisi_id = personel.divisi_id;
                            profile.pangkat_id = personel.pangkat_id;
                            profile.nik = personel.nik;
                            profile.nama = personel.nama;
                            profile.tempat_lahir = personel.tempat_lahir;
                            profile.tanggal_lahir = personel.tanggal_lahir;
                            profile.jenis_kelamin = personel.jenis_kelamin;
                            profile.golongan_darah = personel.golongan_darah;
                            profile.alamat = personel.alamat;
                            profile.jenis_kelamin = personel.jenis_kelamin;
                        }

                        IList<string> companyList = new List<string>();
                        companyList.Add("CompanyX");

                        string companiesJson = JsonConvert.SerializeObject(companyList);


                        //your logic for login process
                        //If login usrename and password are correct then proceed to generate token
                        string key = _config["Jwt:Key"];
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        var claim = new List<Claim>{
                            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new(JwtRegisteredClaimNames.Sub, user.user_id),
                            new("username", user.username),
                            new("first_name", user.first_name),
                            new("last_name", user.last_name),
                            new("email", user.email),

                            new("user_groups", JsonConvert.SerializeObject(usergroups), JsonClaimValueTypes.JsonArray),
                            //new("Companies", companiesJson, JsonClaimValueTypes.JsonArray),
                            new("role", "user"),
                            new("divisi", "All"),
                            new("profile", JsonConvert.SerializeObject(personel), JsonClaimValueTypes.JsonArray),
                            new("resource_access", "All"),
                        };

                        //claim.Add(new Claim(ClaimTypes.Role, "sa"));
                        //claim.Add(new Claim(ClaimTypes.Role, "admin"));

                        //claim.Add(new Claim(ClaimTypes.UserData, "AL"));
                        //claim.Add(new Claim(ClaimTypes.UserData, "3245378449"));

                        var Sectoken = new JwtSecurityToken(
                            _config["Jwt:Issuer"],
                            _config["Jwt:Audience"],
                            claim,
                            expires: DateTime.Now.AddMinutes(120),
                            signingCredentials: credentials
                        );

                        var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                        ResponseLogin response = new ResponseLogin();
                        response.code = 200;
                        response.status = true;
                        response.message = "Authentication success";
                        response.user_id = user.user_id;
                        response.username = user.username;
                        response.role = "datakara";
                        response.token = token;

                        return response;
                    }
                    else
                    {
                        ResponseLogin response = new ResponseLogin();
                        response.code = 200;
                        response.status = false;
                        response.message = "Login failed";
                        response.user_id = user.user_id;
                        response.username = user.username;
                        response.token = "";
                        return response;
                    }
                }
                else
                {
                    ResponseLogin response = new ResponseLogin();
                    response.code = 404;
                    response.status = false;
                    response.message = "Not found";
                    response.user_id = "";
                    response.username = "";
                    response.token = "";
                    return response;
                }
            }
            catch (Exception e)
            {
                ResponseLogin response = new ResponseLogin();
                response.code = 500;
                response.status = false;
                response.message = "Error :" + e.Message.ToString();
                response.user_id = "";
                response.username = "";
                response.token = "";
                return response;
            }

        }
    }
}
