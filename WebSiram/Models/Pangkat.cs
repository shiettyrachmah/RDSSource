using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSiram.Models
{
    public class Pangkat
    {
        public int id { get; set; }
        public string? divisi_id { get; set; }
        public string? kategori { get; set; }
        public string? sub_kategori { get; set; }
        public string? pangkat_id { get; set; }
        public string? kd_pangkat { get; set; }
        public string? nama_pangkat { get; set; }
        public int? herarki { get; set; }
        public int? parent_id { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? last_updated_at { get; set; }
        public string? updated_by { get; set; }
    }
}
