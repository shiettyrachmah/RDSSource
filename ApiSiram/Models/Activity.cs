using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSiram.Models
{
    [Table("activites")]
    public class Activity
    {
        [Key]
        [Required]
        [Column("id")]
        public int id { get; set; }

        [Column("reg_no")]
        [MaxLength(20)]
        public string? reg_no { get; set; }

        [Column("status")]
        [MaxLength(50)]
        public string? status { get; set; }

        [Column("description")]
        public string? description { get; set; }

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
