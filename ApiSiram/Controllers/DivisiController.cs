using ApiSiram.Models;
using ApiSiram.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSiram.Controllers
{
    [Authorize(Roles = "datakara,sa,admin,user")]
    [Route("api/[controller]")]
    [ApiController]
    public class DivisiController : ControllerBase
    {
        private readonly SIRAMDBContext _db;
        public DivisiController(SIRAMDBContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Divisi>>> GetAll()
        {
            return await _db.Divisis.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Divisi>> Get(int id)
        {
            var divisi = await _db.Divisis.Where(m => m.id == id).FirstOrDefaultAsync();

            if (divisi == null)
            {
                return NotFound();
            }

            return divisi;
        }

        [HttpGet("GetByDivisiId/{divisi_id}")]
        public async Task<ActionResult<Divisi>> GetByDivisiId(string divisi_id)
        {
            var divisi = await _db.Divisis.Where(m => m.divisi_id == divisi_id).FirstOrDefaultAsync();

            if (divisi == null)
            {
                return NotFound();
            }

            return divisi;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Response>> Create(Divisi content)
        {
            Response resp = new Response();

            if (content == null)
            {
                resp.code = 200;
                resp.status = false;
                resp.message = "divisi is null";

                return resp;
            }
            else
            {
                var divisi = await _db.Divisis.Where(m => m.divisi_id == content.divisi_id).FirstOrDefaultAsync();
                if (divisi == null)
                {
                    Divisi div = new Divisi();
                    div.divisi_id = content.divisi_id;
                    div.komando_id = content.komando_id;
                    div.nama_divisi = content.nama_divisi;
                    div.deskripsi = content.deskripsi;
                    div.status = content.status;
                    div.created_at = DateTime.Now;
                    div.created_by = content.created_by;
                    div.updated_at = DateTime.Now;
                    div.updated_by = content.created_by;
                    div.last_updated_at = DateTime.Now;
                    _db.Divisis.Add(div);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "create divisi success";
                    return resp;
                }
                else
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "divisi already exist";
                    return resp;
                }
            }

        }
    }
}
