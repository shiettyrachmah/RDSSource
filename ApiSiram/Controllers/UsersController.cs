using ApiSiram.Models;
using ApiSiram.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSiram.Controllers
{

    [Authorize(Roles = "sa,admin,user")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SIRAMDBContext _db;

        public UsersController(SIRAMDBContext context)
        {
            _db = context;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> Get(int id)
        {
            UserVM userVm = new UserVM();

            var user = await _db.Users.Where(m=> m.id == id).FirstOrDefaultAsync();
            var personel = await _db.Personels.Where(m => m.user_id == user.user_id).FirstOrDefaultAsync();
            var roles = await _db.Roles.Where(m => m.status == 1).ToListAsync();
            var groups = await _db.Groups.Where(m => m.status == 1).ToListAsync();
            var divisis = await _db.Divisis.Where(m => m.status == 1).ToListAsync();
            var pangkats = await _db.Pangkats.Where(m => m.status == 1).ToListAsync();
            var jabatans = await _db.Jabatans.Where(m => m.status == 1).ToListAsync();

            if (user == null)
            {
                return NotFound();
            }

            userVm.user=user;
            userVm.personel = personel; 
            userVm.roles = roles;
            userVm.groups = groups;
            userVm.divisis = divisis;
            userVm.pangkats = pangkats;
            userVm.jabatans = jabatans;

            return userVm;
        }

        [HttpGet("RunningNumber")]
        public async Task<ActionResult<User>> RunningNumber()
        {
            long cnt;
            string user_id = string.Empty;
            var UserMax = await _db.Users.OrderByDescending(x => x.user_id).FirstOrDefaultAsync();
            if (UserMax == null)
            {
                user_id = "USR001";
            }
            else
            {
                string lastUserId = UserMax.user_id;
                string lastNumber = lastUserId.Substring(3, 3);
                cnt = Convert.ToInt32(lastNumber) + 1;
                string joinstr = "000" + cnt;
                user_id = "USR" + (joinstr.Substring(joinstr.Length - 3, 3));
            }

            return Ok(user_id);
        }

        // POST api/<UsersController>
        [HttpPost("Create")]
        public async Task<ActionResult<Response>> Create(User content)
        {
            Response resp = new Response();

            if (content == null)
            {
                resp.code = 200;
                resp.status = false;
                resp.message = "user is null";

                return resp;
            }
            else
            {
                long cnt;
                string user_id = string.Empty;
                var UserMax = await _db.Users.OrderByDescending(x => x.user_id).FirstOrDefaultAsync();
                if(UserMax == null)
                {
                    user_id = "USR001";
                }
                else
                {
                    string lastUserId = UserMax.user_id;
                    string lastNumber = lastUserId.Substring(3, 3);
                    cnt = Convert.ToInt32(lastNumber) + 1;
                    string joinstr = "000" + cnt;
                    user_id = "USR" + (joinstr.Substring(joinstr.Length - 3, 3));
                }

                var user = await _db.Users.Where(m => m.username == content.username).FirstOrDefaultAsync();
                if (user == null)
                {
                    Guid myuuid = Guid.NewGuid();
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(content.password);
                    User usr = new User();
                    usr.uuid = myuuid.ToString();
                    usr.user_id = user_id;
                    usr.username = content.username;
                    usr.first_name = content.first_name;
                    usr.last_name = content.last_name;
                    usr.email = content.email;
                    usr.telepon = content.telepon;
                    usr.password = passwordHash;
                    usr.status = 0;
                    usr.created_at = DateTime.Now;
                    usr.created_by = content.created_by;
                    usr.updated_at = DateTime.Now;
                    usr.updated_by = content.created_by;
                    usr.last_updated_at = DateTime.Now;
                    _db.Users.Add(usr);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "create user success";

                    return resp;
                }
                else
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "username already exist";

                    return resp;
                }
            }
        }

        // POST api/<UsersController>
        [HttpPost("Update/{id}")]
        public async Task<ActionResult<Response>> Update(int id, User content)
        {
            Response resp = new Response();
            var user = await _db.Users.Where(m => m.id == id && m.user_id == content.user_id).FirstOrDefaultAsync();
            if (user == null)
            {
                resp.code = 404;
                resp.status = false;
                resp.message = "not found";
                return resp;
            }
            else
            {
                user.user_id = content.user_id;
                user.username = content.username;
                user.first_name = content.first_name;
                user.last_name = content.last_name;
                user.email = content.email;
                user.telepon = content.telepon;
                user.status = content.status;
                user.created_at = user.created_at;
                user.created_by = user.created_by;
                user.updated_at = DateTime.Now;
                user.updated_by = content.created_by;
                user.last_updated_at = user.updated_at;
                await _db.SaveChangesAsync();

                resp.code = 200;
                resp.status = true;
                resp.message = "update user success";

                return resp;
            }
        }

        // POST: api/User/Update
        [HttpPost()]
        [Route("ChangePassword/{id}")]
        public async Task<ActionResult<Response>> ChangePassword(int id, ChangePasswordVM content)
        {
            Response resp = new Response();
            var user = await _db.Users.Where(m => m.id == id && m.user_id == content.user_id).FirstOrDefaultAsync();
            if (user != null)
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(content.password);
                user.password = passwordHash;
                user.last_updated_at = user.updated_at;
                user.updated_at = DateTime.Now;
                user.created_by = content.created_by;
                await _db.SaveChangesAsync();

                resp.code = 200;
                resp.status = true;
                resp.message = "change password success";

                return resp;
            }
            else
            {
                resp.code = 404;
                resp.status = false;
                resp.message = "not found";
                return resp;
            }
        }

        [HttpPost()]
        [Route("ActiveDeactive/{id}")]
        public async Task<ActionResult<Response>> ActiveDeactive(int id, User content)
        {
            Response resp = new Response();

            var user = await _db.Users.Where(m => m.id == id && m.user_id == content.user_id).FirstOrDefaultAsync();
            if (user != null)
            {
                if (user.status == 1)
                {
                    user.status = 0;
                }
                else if (user.status == 0)
                {
                    user.status = 1;
                }

                user.last_updated_at = user.updated_at;
                user.updated_at = DateTime.Now;
                user.created_by = content.created_by;
                await _db.SaveChangesAsync();

                resp.code = 200;
                resp.status = true;
                resp.message = "update status success";
                return resp;

            }
            else
            {
                resp.code = 404;
                resp.status = false;
                resp.message = "not found";
                return resp;
            }
        }

        
    }

}
