using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSiram.Models
{
    public partial class User
    {
        public int id { get; set; }
        public string? user_id { get; set; } 
        public string? username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string telepon { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string roles_id { get; set; }
        public string division { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public object created_by { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime last_updated_at { get; set; }
        public object updated_by { get; set; }
    }

}
