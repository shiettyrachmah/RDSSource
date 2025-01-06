using ApiSiram.Models;
using ApiSiram.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSiram.Controllers
{
    [Authorize(Roles = "sa,admin,user")]
    [Route("api/[controller]")]
    [ApiController]
    public class JabatanController : ControllerBase
    {
        private readonly SIRAMDBContext _db;
        public JabatanController(SIRAMDBContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jabatan>>> GetAll()
        {
            return await _db.Jabatans.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jabatan>> Get(int id)
        {
            var jabatan = await _db.Jabatans.Where(m => m.id == id).FirstOrDefaultAsync();

            if (jabatan == null)
            {
                return NotFound();
            }

            return jabatan;
        }

        [HttpGet("GetByJabatanId/{jabatan_id}")]
        public async Task<ActionResult<Jabatan>> GetByJabatanId(string jabatan_id)
        {
            var jabatan = await _db.Jabatans.Where(m => m.jabatan_id == jabatan_id).FirstOrDefaultAsync();

            if (jabatan == null)
            {
                return NotFound();
            }

            return jabatan;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Response>> Create(Jabatan content)
        {
            Response resp = new Response();

            if (content == null)
            {
                resp.code = 200;
                resp.status = false;
                resp.message = "Jabatan is null";

                return resp;
            }
            else
            {
                var jabatan = await _db.Jabatans.Where(m => m.jabatan_id == content.jabatan_id).FirstOrDefaultAsync();
                if (jabatan == null)
                {
                    Jabatan jab = new Jabatan();
                    jab.jabatan_id = content.jabatan_id;
                    jab.nama_jabatan = content.nama_jabatan;
                    jab.tingkat_jabatan = content.tingkat_jabatan;
                    jab.status = content.status;
                    jab.created_at = DateTime.Now;
                    jab.created_by = content.created_by;
                    jab.updated_at = DateTime.Now;
                    jab.updated_by = content.created_by;
                    jab.last_updated_at = DateTime.Now;
                    _db.Jabatans.Add(jab);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "create jabatan success";
                    return resp;
                }
                else
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "jabatan already exist";
                    return resp;
                }
            }

        }
    }
}
