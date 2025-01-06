using ApiSiram.Models;
using ApiSiram.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSiram.Controllers
{
    [Authorize(Roles = "sa,admin,user")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly SIRAMDBContext _db;

        public RolesController(SIRAMDBContext context)
        {
            _db = context;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            return await _db.Roles.ToListAsync();
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            var role = await _db.Roles.Where(m => m.id == id).FirstOrDefaultAsync();

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // POST api/<RolesController>
        [HttpPost("Create")]
        public async Task<ActionResult<Response>> Create(Role content)
        {
            Response resp = new Response();

            if (content == null)
            {
                resp.code = 200;
                resp.status = false;
                resp.message = "role is null";

                return resp;
            }
            else
            {
                var user = await _db.Roles.Where(m => m.roles_name.ToLower() == content.roles_name.ToLower()).FirstOrDefaultAsync();
                if (user == null)
                {
                    Role newRole = new Role();
                    newRole.id = content.id;
                    newRole.roles_name = content.roles_name;
                    newRole.guard_name = content.guard_name;
                    newRole.description = content.description;
                    newRole.status = content.status;
                    newRole.created_at = DateTime.Now;
                    newRole.created_by = content.created_by;
                    newRole.updated_at = DateTime.Now;
                    newRole.updated_by = content.created_by;
                    newRole.last_updated_at = DateTime.Now;
                    _db.Roles.Add(newRole);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "create role success";

                    return resp;
                }
                else
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "role already exist";

                    return resp;
                }
            }
        }

        // POST api/<RolesController>
        [HttpPost("Update/{id}")]
        public async Task<ActionResult<Response>> Update(int id, Role content)
        {
            Response resp = new Response();
            var role = await _db.Roles.Where(m => m.id == id && m.roles_name.ToLower() == content.roles_name.ToLower()).FirstOrDefaultAsync();
            if (role == null)
            {
                resp.code = 404;
                resp.status = false;
                resp.message = "not found";
                return resp;
            }
            else
            {
                role.id = content.id;
                role.roles_name = content.roles_name;
                role.guard_name = content.guard_name;
                role.description = content.description;
                role.status = content.status;
                role.created_at = role.created_at;
                role.created_by = role.created_by;
                role.updated_at = DateTime.Now;
                role.updated_by = content.created_by;
                role.last_updated_at = role.updated_at;
                await _db.SaveChangesAsync();

                resp.code = 200;
                resp.status = true;
                resp.message = "update role success";

                return resp;
            }
        }

    }
}
