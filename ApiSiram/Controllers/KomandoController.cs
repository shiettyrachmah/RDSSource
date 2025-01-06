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
    public class KomandoController : ControllerBase
    {
        private readonly SIRAMDBContext _db;
        public KomandoController(SIRAMDBContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Komando>>> GetAll()
        {
            return await _db.Komandos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Komando>> Get(int id)
        {
            var komando = await _db.Komandos.Where(m => m.id == id).FirstOrDefaultAsync();

            if (komando == null)
            {
                return NotFound();
            }

            return komando;
        }

        [HttpGet("GetByKomandoId/{komando_id}")]
        public async Task<ActionResult<Komando>> GetByKomandoId(string komando_id)
        {
            var komando = await _db.Komandos.Where(m => m.komando_id == komando_id).FirstOrDefaultAsync();

            if (komando == null)
            {
                return NotFound();
            }

            return komando;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Response>> Create(Komando content)
        {
            Response resp = new Response();

            if (content == null)
            {
                resp.code = 200;
                resp.status = false;
                resp.message = "komando is null";

                return resp;
            }
            else
            {
                var divisi = await _db.Komandos.Where(m => m.komando_id == content.komando_id).FirstOrDefaultAsync();
                if (divisi == null)
                {
                    Komando kom = new Komando();
                    kom.komando_id = content.komando_id;
                    kom.nama_komando = content.nama_komando;
                    kom.jenis_komando = content.jenis_komando;
                    kom.deskripsi = content.deskripsi;
                    kom.status = content.status;
                    kom.created_at = DateTime.Now;
                    kom.created_by = content.created_by;
                    kom.updated_at = DateTime.Now;
                    kom.updated_by = content.created_by;
                    kom.last_updated_at = DateTime.Now;
                    _db.Komandos.Add(kom);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "create komando success";
                    return resp;
                }
                else
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "komando already exist";
                    return resp;
                }
            }

        }
    }
}
