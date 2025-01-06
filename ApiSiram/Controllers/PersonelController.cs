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
    public class PersonelController : ControllerBase
    {
        private readonly SIRAMDBContext _db;
        public PersonelController(SIRAMDBContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personel>>> GetAll()
        {
            return await _db.Personels.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personel>> Get(int id)
        {
            var personel = await _db.Personels.Where(m => m.id == id).FirstOrDefaultAsync();

            if (personel == null)
            {
                return NotFound();
            }

            return personel;
        }

        [HttpGet("PersonelAktif")]
        public async Task<ActionResult<IEnumerable<VPersonel>>> PersonelAktif()
        {
            var personel = await _db.VPersonels.FromSql($"select p.id,p.personel_id,p.upline_id ,p.user_id,p.nama ,p.jenis_kelamin,p.divisi_id,d.nama_divisi, p.pangkat_id , p2.nama_pangkat, p2.kategori ,p2.sub_kategori,p.jabatan_id , j.nama_jabatan , j.tingkat_jabatan from personel p left join divisi d on p.divisi_id = d.divisi_id left join pangkat p2 on p.pangkat_id = p2.pangkat_id left join jabatan j on p.jabatan_id = j.jabatan_id where p.status = '1' order by p.id").ToListAsync();

            if (personel == null)
            {
                return NotFound();
            }

            return personel;
        }

        [HttpGet("GetByPersonelId/{personel_id}")]
        public async Task<ActionResult<Personel>> GetByPersonelId(string personnel_id)
        {
            var personnel = await _db.Personels.Where(m => m.personel_id == personnel_id).FirstOrDefaultAsync();

            if (personnel == null)
            {
                return NotFound();
            }

            return personnel;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Response>> Create(Personel content)
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
                var personel = await _db.Personels.Where(m => m.personel_id == content.personel_id).FirstOrDefaultAsync();
                if (personel == null)
                {
                    Personel per = new Personel();
                    per.personel_id = content.personel_id;
                    per.upline_id = content.upline_id;
                    per.user_id = content.user_id;
                    per.nrp = content.nrp;
                    per.divisi_id = content.divisi_id;
                    per.pangkat_id = content.pangkat_id;
                    per.jabatan_id = content.jabatan_id;

                    per.nik = content.nik;
                    per.nama = content.nama;
                    per.jenis_kelamin = content.jenis_kelamin;
                    per.tempat_lahir = content.tempat_lahir;
                    per.tanggal_lahir = content.tanggal_lahir;
                    per.golongan_darah = content.golongan_darah;
                    per.alamat = content.alamat;
                    per.rt = content.rt;
                    per.rw = content.rw;
                    per.desa = content.desa;
                    per.kecamatan = content.kecamatan;
                    per.kabupaten = content.kabupaten;
                    per.provinsi = content.provinsi;
                    per.agama = content.agama;
                    per.status_perkawinan = content.status_perkawinan;
                    per.pekerjaan = content.pekerjaan;
                    per.kewarganegaraan = content.kewarganegaraan;
                    per.foto = content.foto;
                    per.signature = content.signature;

                    per.status = content.status;
                    per.created_at = DateTime.Now;
                    per.created_by = content.created_by;
                    per.updated_at = DateTime.Now;
                    per.updated_by = content.created_by;
                    per.last_updated_at = DateTime.Now;
                    _db.Personels.Add(per);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "create personel success";
                    return resp;
                }
                else
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "personel already exist";
                    return resp;
                }
            }

        }
    }
}
