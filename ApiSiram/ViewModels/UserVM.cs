using ApiSiram.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ApiSiram.ViewModels
{
    public class UserVM
    {
        public User user { get; set; }
        public Personel personel { get; set; }
        public List<Role> roles { get; set; }
        public List<Group> groups { get; set; }
        public List<Divisi> divisis { get; set; }
        public List<Pangkat> pangkats { get; set; }
        public List<Jabatan> jabatans { get; set; }
    }
}
