using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiram.Models
{
    [Table("activites")]
    public class Activity
    {
        public int id { get; set; }
        public string? reg_no { get; set; }
        public string? status { get; set; }
        public string? description { get; set; }
        public DateTime created_at { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? last_updated_at { get; set; }
        public string? updated_by { get; set; }
    }
}
