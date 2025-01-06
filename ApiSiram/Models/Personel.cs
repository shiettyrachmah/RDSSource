using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSiram.Models
{
    [Table("personel")]
    public class Personel
    {
        [Key]
        [Required]
        [Column("id")]
        public int id { get; set; }

        [Column("personel_id")]
        [MaxLength(10)]
        public string? personel_id { get; set; }

        [Column("user_id")]
        [MaxLength(10)]
        public string? user_id { get; set; }

        [Column("upline_id")]
        [MaxLength(10)]
        public string? upline_id { get; set; }

        [Column("nrp")]
        [MaxLength(30)]
        public string? nrp { get; set; }

        [Column("divisi_id")]
        [MaxLength(10)]
        public string? divisi_id { get; set; }

        [Column("pangkat_id")]
        [MaxLength(10)]
        public string? pangkat_id { get; set; }

        [Column("jabatan_id")]
        [MaxLength(10)]
        public string? jabatan_id { get; set; }

        [Column("nik")]
        [MaxLength(16)]
        public string? nik { get; set; } 

        [Column("nama")]
        [MaxLength(100)]
        public string? nama { get; set; } 

        [Column("tempat_lahir")]
        [MaxLength(50)]
        public string? tempat_lahir { get; set; } 

        [Column("tanggal_lahir")]
        public DateOnly tanggal_lahir { get; set; }

        [Column("jenis_kelamin")]
        [MaxLength(20)]
        public string? jenis_kelamin { get; set; } 

        [Column("golongan_darah")]
        [MaxLength(3)]
        public string? golongan_darah { get; set; } 

        [Column("alamat")]
        public string? alamat { get; set; }

        [Column("rt")]
        [MaxLength(3)]
        public string? rt { get; set; } 

        [Column("rw")]
        [MaxLength(3)]
        public string? rw { get; set; }

        [Column("desa")]
        [MaxLength(50)]
        public string? desa { get; set; } 

        [Column("kecamatan")]
        [MaxLength(50)]
        public string? kecamatan { get; set; } 

        [Column("kabupaten")]
        [MaxLength(50)]
        public string? kabupaten { get; set; } 

        [Column("provinsi")]
        [MaxLength(50)]
        public string? provinsi { get; set; } 

        [Column("agama")]
        [MaxLength(20)]
        public string? agama { get; set; } 

        [Column("status_perkawinan")]
        [MaxLength(20)]
        public string? status_perkawinan { get; set; }

        [Column("pekerjaan")]
        [MaxLength(50)]
        public string? pekerjaan { get; set; } 

        [Column("kewarganegaraan")]
        [MaxLength(3)]
        public string? kewarganegaraan { get; set; } 

        [Column("foto")]
        public byte[]? foto { get; set; }

        [Column("signature")]
        public byte[]? signature { get; set; }


        [Column("status")]
        public int status { get; set; }

        [Column("created_at")]
        public DateTime created_at { get; set; }

        [Column("created_by")]
        [MaxLength(10)]
        public string? created_by { get; set; }

        [Column("updated_at")]
        public DateTime? updated_at { get; set; }

        [Column("last_updated_at")]
        public DateTime? last_updated_at { get; set; }

        [Column("updated_by")]
        [MaxLength(10)]
        public string? updated_by { get; set; }
    }
}
