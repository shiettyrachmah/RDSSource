using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiram.Models
{
    public class Personel
    {
        public int id { get; set; }
        public string? personel_id { get; set; }
        public string? user_id { get; set; }
        public string? upline_id { get; set; }
        public string? nrp { get; set; }
        public string? divisi_id { get; set; }
        public string? pangkat_id { get; set; }
        public string? jabatan_id { get; set; }
        public string? nik { get; set; } 
        public string? nama { get; set; } 
        public string? tempat_lahir { get; set; } 
        public DateOnly tanggal_lahir { get; set; }
        public string? jenis_kelamin { get; set; } 
        public string? golongan_darah { get; set; } 
        public string? alamat { get; set; }
        public string? rt { get; set; } 
        public string? rw { get; set; }
        public string? desa { get; set; } 
        public string? kecamatan { get; set; } 
        public string? kabupaten { get; set; } 
        public string? provinsi { get; set; } 
        public string? agama { get; set; } 
        public string? status_perkawinan { get; set; }
        public string? pekerjaan { get; set; } 
        public string? kewarganegaraan { get; set; } 
        public byte[]? foto { get; set; }
        public byte[]? signature { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? last_updated_at { get; set; }
        public string? updated_by { get; set; }
    }
}
