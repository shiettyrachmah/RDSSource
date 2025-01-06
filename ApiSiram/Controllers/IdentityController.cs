using ApiSiram.Models;
using ApiSiram.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace ApiSiram.Controllers
{
    [Route("svc/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly SIRAMDBContext _db;
        private IConfiguration _config;

        public IdentityController(SIRAMDBContext context,IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        [HttpPost("CreateAccess")]
        public async Task<GeneralResponse> CreateAccess(LoginViewModel content)
        {
            //EncryptViewModel encryptViewModel = new EncryptViewModel();
            //encryptViewModel.key = _config["AppSettings:HasKey"];
            //encryptViewModel.plain_text = content.username + "|" + content.password;
            //string data = Encrypt(encryptViewModel);

            string plainText = content.username + "|" + content.password;
            string data = Base64Encode(plainText);

            GeneralResponse response = new GeneralResponse();
            response.code = 200;
            response.status = true;
            response.message = "Success";
            response.data = data;
            return response;
        }

        [HttpPost("CheckAccess")]
        public async Task<UserKeycloakViewModel> CheckAccess(CheckAccessViewModel content)
        {
            UserKeycloakViewModel user = new UserKeycloakViewModel();
            KeycloakClaim claim = new KeycloakClaim();

            string data = Base64Decode(content.data);
            if (data.Length > 0)
            {
                string[] arrString = data.Split('|');
                string username = arrString[0];
                string password = arrString[1];

                KeycloakLogin keycloakLogin = new KeycloakLogin();
                keycloakLogin.client_id = "api-siram";
                keycloakLogin.username = username;
                keycloakLogin.password = password;
                keycloakLogin.grant_type = "password";

                var usr = await _db.Users.Where(m => m.username == username && m.status == 1).FirstOrDefaultAsync();
                if (usr != null)
                {
                    claim.user_id = usr.user_id;
                    claim.scope = "profile siram_scope email";
                    claim.matra = "AU";
                    //user.email_verified = tokenS.Claims.First(claim => claim.Type == "email_verified").Value;
                    claim.alamat_kesatuan = "TANAH ABANG";
                    claim.jabatan = "JABATAN 1";
                    claim.telepon = usr.telepon;
                    claim.kd_satuan = "";
                    claim.agama = "";
                    claim.korps = "";
                    claim.pangkat = "";
                    claim.kesatuan = "";
                    claim.preferred_username = "";
                    claim.given_name = "";
                    claim.nrp = "";
                    claim.alamat = "";
                    claim.kd_jabatan = "";
                    claim.kd_pangkat = "";
                    claim.user_id = usr.user_id;
                    claim.name = usr.username;
                    claim.family_name = "";
                    claim.jenis_kelamin = "";
                    claim.email = usr.email;
                }
                else
                {
                    user.code = 404;
                    user.status = true;
                    user.message = "Notfound";
                    user.claim = null;
                    return user;

                }
               
            }

            user.code = 200;
            user.status = true;
            user.message = "Success";
            user.claim = claim;
            return user;
        }

        private string Encrypt(EncryptViewModel content)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(content.key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(content.plain_text);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            string base64String = Convert.ToBase64String(array);
            return base64String;
        }

        private string Decrypt(DecryptViewModel content)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(content.cipher_text);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(content.key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            //return streamReader.ReadToEnd();
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
