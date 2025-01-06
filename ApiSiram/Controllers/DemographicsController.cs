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
    public class DemographicsController : ControllerBase
    {
        private readonly SIRAMDBContext _db;

        public DemographicsController(SIRAMDBContext context)
        {
            _db = context;
        }

        // GET: api/<DemographicsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Demographic>>> GetAll()
        {
            return await _db.Demographics.ToListAsync();
        }

        // GET api/<DemographicsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Demographic>> Get(int id)
        {
            var demographic = await _db.Demographics.Where(m => m.id == id).FirstOrDefaultAsync();

            if (demographic == null)
            {
                return NotFound();
            }

            return demographic;
        }

        // POST api/<DemographicsController>
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Response>> Create(Demographic content)
        {
            Response resp = new Response();

            if (content == null)
            {
                resp.code = 200;
                resp.status = false;
                resp.message = "demographic is null";

                return resp;
            }
            else
            {
                var demographics = await _db.Demographics.Where(m => m.nik == content.nik).FirstOrDefaultAsync();
                if (demographics == null)
                {
                    Demographic dmg = new Demographic();
                    dmg.reg_no = content.reg_no;
                    dmg.nik = content.nik;
                    dmg.full_name = content.full_name;
                    dmg.place_of_birth = content.place_of_birth;
                    dmg.date_of_birth = content.date_of_birth;
                    dmg.gender = content.gender;
                    dmg.blood_type = content.blood_type;
                    dmg.address = content.address;
                    dmg.rt = content.rt;
                    dmg.rw = content.rw;
                    dmg.village = content.village;
                    dmg.sub_district = content.sub_district;
                    dmg.regency = content.regency;
                    dmg.province = content.province;
                    dmg.religion = content.religion;
                    dmg.maritalStatus = content.maritalStatus;
                    dmg.occupation = content.occupation;
                    dmg.nationality = content.nationality;
                    dmg.foto = content.foto;
                    dmg.signature = content.signature;

                    dmg.status = content.status;
                    dmg.created_at = DateTime.Now;
                    dmg.created_by = content.created_by;
                    dmg.updated_at = DateTime.Now;
                    dmg.updated_by = content.created_by;
                    dmg.last_updated_at = DateTime.Now;
                    _db.Demographics.Add(dmg);
                    await _db.SaveChangesAsync();

                    resp.code = 200;
                    resp.status = true;
                    resp.message = "create demographic success";
                    return resp;
                }
                else
                {
                    resp.code = 200;
                    resp.status = false;
                    resp.message = "demographic already exist";
                    return resp;
                }
            }
        }
    }
}
