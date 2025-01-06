using ApiSiram.Models;
using ApiSiram.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSiram.Controllers
{
    [Authorize(Roles = "sa,admin,user")]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly SIRAMDBContext _db;

        public GroupsController(SIRAMDBContext context)
        {
            _db = context;
        }

        // GET: api/<GroupsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> Get()
        {
            return await _db.Groups.ToListAsync();
        }

        // GET api/<GroupsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> Get(int id)
        {
            var group = await _db.Groups.Where(m => m.id == id).FirstOrDefaultAsync();

            if (group == null)
            {
                return NotFound();
            }

            return group;
        }

        // POST api/<GroupsController>
        [HttpPost("Create")]
        public async Task<ActionResult<Response>> Create(Group content)
        {
            Response resp = new Response();

            if (content == null)
            {
                resp.code = 200;
                resp.status = false;
                resp.message = "group is null";

                return resp;
            }
            else
            {
                var group = await _db.Groups.Where(m => m.group_name.ToLower() == content.group_name.ToLower()).FirstOrDefaultAsync();
                if (group == null)
                {
                    Group newGroup = new Group();
                    newGroup.id = content.id;
                    newGroup.group_name = content.group_name;
                    newGroup.description = content.description;
                    newGroup.status = content.status;
                    newGroup.created_at = DateTime.Now;
                    newGroup.created_by = content.created_by;
                    newGroup.updated_at = DateTime.Now;
                    newGroup.updated_by = content.created_by;
                    newGroup.last_updated_at = DateTime.Now;
                    _db.Groups.Add(newGroup);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "create group success";

                    return resp;
                }
                else
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "group already exist";

                    return resp;
                }
            }
        }

        // POST api/<GroupsController>
        [HttpPost("Update/{id}")]
        public async Task<ActionResult<Response>> Update(int id, Group content)
        {
            Response resp = new Response();
            var role = await _db.Groups.Where(m => m.id == id &&  m.group_name.ToLower() == content.group_name.ToLower()).FirstOrDefaultAsync();
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
                role.group_name = content.group_name;
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
                resp.message = "update group success";

                return resp;
            }
        }
    }
}
