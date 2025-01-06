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
    public class UserGroupsController : ControllerBase
    {
        private readonly SIRAMDBContext _db;

        public UserGroupsController(SIRAMDBContext context)
        {
            _db = context;
        }

        // GET: api/<UserGroupsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroup>>> Get()
        {
            return await _db.UserGroups.ToListAsync();
        }

        // GET api/<UserGroupsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroup>> Get(int id)
        {
            var userGroup = await _db.UserGroups.Where(m => m.id == id).FirstOrDefaultAsync();

            if (userGroup == null)
            {
                return NotFound();
            }

            return userGroup;
        }

        // POST api/<UserGroupsController>
        [HttpPost("Create")]
        public async Task<ActionResult<Response>> Create(UserGroup content)
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
                var userGroup = await _db.UserGroups.Where(m => m.user_id.ToLower() == content.user_id.ToLower() && m.group_id == content.group_id).FirstOrDefaultAsync();
                if (userGroup == null)
                {
                    UserGroup ugrp = new UserGroup();
                    ugrp.id = content.id;
                    ugrp.user_id = content.user_id;
                    ugrp.group_id = content.group_id;
                    ugrp.status = content.status;
                    ugrp.created_at = DateTime.Now;
                    ugrp.created_by = content.created_by;
                    ugrp.updated_at = DateTime.Now;
                    ugrp.updated_by = content.created_by;
                    ugrp.last_updated_at = DateTime.Now;
                    _db.UserGroups.Add(ugrp);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "create UserGroup success";

                    return resp;
                }
                else
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "UserGroup already exist";

                    return resp;
                }
            }
        }

        // POST api/<UserGroupsController>
        [HttpPost("Update/{id}")]
        public async Task<ActionResult<Response>> Update(int id, UserGroup content)
        {
            Response resp = new Response();
            var userGroup = await _db.UserGroups.Where(m => m.id == id && m.user_id.ToLower() == content.user_id.ToLower() && m.group_id == content.group_id).FirstOrDefaultAsync();
            if (userGroup == null)
            {
                resp.code = 404;
                resp.status = false;
                resp.message = "not found";
                return resp;
            }
            else
            {
                userGroup.id = content.id;
                userGroup.user_id = content.user_id;
                userGroup.group_id = content.group_id;
                userGroup.status = content.status;
                userGroup.created_at = userGroup.created_at;
                userGroup.created_by = userGroup.created_by;
                userGroup.updated_at = DateTime.Now;
                userGroup.updated_by = content.created_by;
                userGroup.last_updated_at = userGroup.updated_at;
                await _db.SaveChangesAsync();

                resp.code = 200;
                resp.status = true;
                resp.message = "update UserGroup success";

                return resp;
            }
        }
    }
}
