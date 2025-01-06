using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSiram.Models
{
    [Table("komando")]
    public class Komando
    {
        [Key]
        [Required]
        [Column("id")]
        public int id { get; set; }

        [Column("komando_id")]
        [MaxLength(15)]
        public string? komando_id { get; set; }

        [Column("nama_komando")]
        [MaxLength(50)]
        public string? nama_komando { get; set; }

        [Column("jenis_komando")]
        [MaxLength(50)]
        public string? jenis_komando { get; set; }

        [Column("wilayah")]
        [MaxLength(50)]
        public string? wilayah { get; set; }

        [Column("deskripsi")]
        public string? deskripsi { get; set; }

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
