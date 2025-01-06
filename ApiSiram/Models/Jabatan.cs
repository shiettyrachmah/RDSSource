using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSiram.Models
{
    [Table("jabatan")]
    public class Jabatan
    {
        [Key]
        [Required]
        [Column("id")]
        public int id { get; set; }

        [Column("jabatan_id")]
        [MaxLength(10)]
        public string? jabatan_id { get; set; }

        [Column("nama_jabatan")]
        [MaxLength(50)]
        public string? nama_jabatan { get; set; }

        [Column("tingkat_jabatan")]
        [MaxLength(30)]
        public string? tingkat_jabatan { get; set; }

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
