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
    public class PangkatController : ControllerBase
    {
        private readonly SIRAMDBContext _db;
        public PangkatController(SIRAMDBContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pangkat>>> GetAll()
        {
            return await _db.Pangkats.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pangkat>> Get(int id)
        {
            var pangkat = await _db.Pangkats.Where(m => m.id == id).FirstOrDefaultAsync();

            if (pangkat == null)
            {
                return NotFound();
            }

            return pangkat;
        }

        [HttpGet("GetByPangkatId/{pangkat_id}")]
        public async Task<ActionResult<Pangkat>> GetByKomandoId(string pangkat_id)
        {
            var pangkat = await _db.Pangkats.Where(m => m.pangkat_id == pangkat_id).FirstOrDefaultAsync();

            if (pangkat == null)
            {
                return NotFound();
            }

            return pangkat;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Response>> Create(Pangkat content)
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
                long cnt;
                string runid = string.Empty;
                var RowMax = await _db.Pangkats.OrderByDescending(x => x.pangkat_id).FirstOrDefaultAsync();
                if (RowMax == null)
                {
                    runid = "P001";
                }
                else
                {
                    string lastUserId = RowMax.pangkat_id;
                    string lastNumber = lastUserId.Substring(1, 3);
                    cnt = Convert.ToInt32(lastNumber) + 1;
                    string joinstr = "000" + cnt;
                    runid = "p" + (joinstr.Substring(joinstr.Length - 1, 3));
                }

                var pangkat = await _db.Pangkats.Where(m => m.pangkat_id == content.pangkat_id).FirstOrDefaultAsync();
                if (pangkat == null)
                {
                    Pangkat kom = new Pangkat();
                    kom.divisi_id = content.divisi_id;
                    kom.kategori = content.kategori;
                    kom.sub_kategori = content.sub_kategori;
                    kom.pangkat_id = runid;
                    kom.kd_pangkat = content.kd_pangkat;
                    kom.nama_pangkat = content.nama_pangkat;
                    kom.herarki = content.herarki;
                    kom.parent_id = content.parent_id;
                    kom.status = content.status;
                    kom.created_at = DateTime.Now;
                    kom.created_by = content.created_by;
                    kom.updated_at = DateTime.Now;
                    kom.updated_by = content.created_by;
                    kom.last_updated_at = DateTime.Now;
                    _db.Pangkats.Add(kom);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "create pangkat success";
                    return resp;
                }
                else
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "pangkat already exist";
                    return resp;
                }
            }

        }
    }
}
