using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiram.Models
{
    [Table("detail_activities")]
    public class DetailActivity
    {
        public int id { get; set; }
        public string? reg_no { get; set; }
        public string? status { get; set; }
        public string? description { get; set; }
        public DateTime created_at { get; set; }
        public string? created_by { get; set; }

    }
}
