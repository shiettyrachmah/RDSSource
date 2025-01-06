using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiram.Models
{
    public class Divisi
    {
        public int id { get; set; }
        public string? divisi_id { get; set; }
        public string? komando_id { get; set; }
        public string? nama_divisi { get; set; }
        public string? deskripsi { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? last_updated_at { get; set; }
        public string? updated_by { get; set; }
    }
}
