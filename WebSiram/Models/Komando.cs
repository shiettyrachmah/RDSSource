using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSiram.Models
{
    public class Komando
    {
        public int id { get; set; }
        public string? komando_id { get; set; }
        public string? nama_komando { get; set; }
        public string? jenis_komando { get; set; }
        public string? wilayah { get; set; }
        public string? deskripsi { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? last_updated_at { get; set; }
        public string? updated_by { get; set; }
    }
}
