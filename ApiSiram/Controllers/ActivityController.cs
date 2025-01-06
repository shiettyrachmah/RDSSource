using ApiSiram.Models;
using ApiSiram.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSiram.Controllers
{
    [Authorize(Roles = "sa,admin,user")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly SIRAMDBContext _db;
        public ActivityController(SIRAMDBContext context)
        {
            _db = context;
        }

        [HttpGet("GetActive")]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActive()
        {
            var activity = await _db.Activities.Where(m => m.status != "Closed").ToListAsync();

            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> Get(int id)
        {
            var activity = await _db.Activities.Where(m => m.id == id).FirstOrDefaultAsync();

            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }

        [HttpGet("Details/{id}")]
        public async Task<ActionResult<ActivityVM>> Details(string id)
        {
            ActivityVM avm = new ActivityVM();
            var activity = await _db.Activities.Where(m => m.reg_no == id).FirstOrDefaultAsync();
            var details = await _db.DetailActivities.Where(m => m.reg_no == id).ToListAsync();

            avm.activiy = activity;
            avm.details_activity = details;

            return avm;
        }

        [HttpGet("GetByRegNo/{reg_no}")]
        public async Task<ActionResult<List<Activity>>> GetByRegNo(string reg_no)
        {
            var activity = await _db.Activities.Where(m => m.reg_no == reg_no).ToListAsync();

            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Response>> Create(Activity content)
        {
            Response resp = new Response();

            if (content == null)
            {
                resp.code = 200;
                resp.status = false;
                resp.message = "activity is null";

                return resp;
            }
            else
            {
                var activity = await _db.Activities.Where(m => m.reg_no == content.reg_no).FirstOrDefaultAsync();
                if (activity != null)
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "reg_no already exist";
                    return resp;
                }
                else
                {
                    Activity act = new Activity();
                    act.reg_no = content.reg_no;
                    act.status = content.status;
                    act.description = content.description;
                    act.created_at = DateTime.Now;
                    act.created_by = content.created_by;
                    act.updated_at = DateTime.Now;
                    act.updated_by = content.created_by;
                    act.last_updated_at = DateTime.Now;
                    _db.Activities.Add(act);
                    await _db.SaveChangesAsync();

                    DetailActivity dtact = new DetailActivity();
                    dtact.reg_no = content.reg_no;
                    dtact.status = content.status;
                    dtact.description = content.description;
                    dtact.created_at = DateTime.Now;
                    dtact.created_by = content.created_by;
                    _db.DetailActivities.Add(dtact);
                    await _db.SaveChangesAsync();

                    resp.code = 201;
                    resp.status = true;
                    resp.message = "create activity success";
                    return resp;
                }
            }

        }

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<Response>> Update(Activity content)
        {
            Response resp = new Response();

            if (content == null)
            {
                resp.code = 200;
                resp.status = false;
                resp.message = "activity is null";

                return resp;
            }
            else
            {
                var act = await _db.Activities.Where(m => m.reg_no == content.reg_no).FirstOrDefaultAsync();
                if (act == null)
                {
                    resp.code = 404;
                    resp.status = false;
                    resp.message = "activity not found";
                    return resp;
                }
                else
                {
                    act.status = content.status;
                    act.description = content.description;
                    act.last_updated_at = act.updated_at;
                    act.updated_at = DateTime.Now;
                    act.updated_by = content.created_by;
                    await _db.SaveChangesAsync();

                    DetailActivity dtact = new DetailActivity();
                    dtact.reg_no = content.reg_no;
                    dtact.status = content.status;
                    dtact.description = content.description;
                    dtact.created_at = DateTime.Now;
                    dtact.created_by = content.created_by;
                    _db.DetailActivities.Add(dtact);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "update activity success";
                    return resp;
                }
            }
        }
    }
}
