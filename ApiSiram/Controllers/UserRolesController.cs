using ApiSiram.Models;
using ApiSiram.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSiram.Controllers
{
    [Authorize(Roles = "sa,admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly SIRAMDBContext _db;

        public UserRolesController(SIRAMDBContext context)
        {
            _db = context;
        }

        // GET: api/<UserRolesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> Get()
        {
            return await _db.UserRoles.ToListAsync();
        }

        // GET api/<UserRolesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> Get(int id)
        {
            var userRole = await _db.UserRoles.Where(m => m.id == id).FirstOrDefaultAsync();

            if (userRole == null)
            {
                return NotFound();
            }

            return userRole;
        }

        // POST api/<UserRolesController>
        [HttpPost("Create")]
        public async Task<ActionResult<Response>> Create(UserRole content)
        {
            Response resp = new Response();

            if (content == null)
            {
                resp.code = 200;
                resp.status = false;
                resp.message = "UserGroup is null";

                return resp;
            }
            else
            {
                var userRole = await _db.UserRoles.Where(m => m.user_id.ToLower() == content.user_id.ToLower() && m.role_id == content.role_id).FirstOrDefaultAsync();
                if (userRole == null)
                {
                    UserRole urole = new UserRole();
                    urole.id = content.id;
                    urole.user_id = content.user_id;
                    urole.role_id = content.role_id;
                    urole.status = content.status;
                    urole.created_at = DateTime.Now;
                    urole.created_by = content.created_by;
                    urole.updated_at = DateTime.Now;
                    urole.updated_by = content.created_by;
                    urole.last_updated_at = DateTime.Now;
                    _db.UserRoles.Add(urole);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "create UserRole success";

                    return resp;
                }
                else
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "UserRole already exist";

                    return resp;
                }
            }
        }

        // POST api/<UserGroupsController>
        [HttpPost("Update/{id}")]
        public async Task<ActionResult<Response>> Update(int id, UserRole content)
        {
            Response resp = new Response();
            var userRole = await _db.UserRoles.Where(m => m.id == id && m.user_id.ToLower() == content.user_id.ToLower() && m.role_id == content.role_id).FirstOrDefaultAsync();
            if (userRole == null)
            {
                resp.code = 404;
                resp.status = false;
                resp.message = "not found";
                return resp;
            }
            else
            {
                userRole.id = content.id;
                userRole.user_id = content.user_id;
                userRole.role_id = content.role_id;
                userRole.status = content.status;
                userRole.created_at = userRole.created_at;
                userRole.created_by = userRole.created_by;
                userRole.updated_at = DateTime.Now;
                userRole.updated_by = content.created_by;
                userRole.last_updated_at = userRole.updated_at;
                await _db.SaveChangesAsync();

                resp.code = 200;
                resp.status = true;
                resp.message = "update UserRole success";

                return resp;
            }
        }
    }
}
