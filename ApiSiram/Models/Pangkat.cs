using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiSiram.Models
{
    [Table("pangkat")]
    public class Pangkat
    {
        [Key]
        [Required]
        [Column("id")]
        public int id { get; set; }

        [Column("divisi_id")]
        [MaxLength(10)]
        public string? divisi_id { get; set; }

        [Column("kategori")]
        [MaxLength(30)]
        public string? kategori { get; set; }

        [Column("sub_kategori")]
        [MaxLength(50)]
        public string? sub_kategori { get; set; }

        [Column("pangkat_id")]
        [MaxLength(10)]
        public string? pangkat_id { get; set; }

        [Column("kd_pangkat")]
        [MaxLength(20)]
        public string? kd_pangkat { get; set; }

        [Column("nama_pangkat")]
        [MaxLength(50)]
        public string? nama_pangkat { get; set; }

        [Column("herarki")]
        public int? herarki { get; set; }

        [Column("parent_id")]
        public int? parent_id { get; set; }

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
