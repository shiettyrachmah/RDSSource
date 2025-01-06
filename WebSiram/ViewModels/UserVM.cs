using System.Text.RegularExpressions;
using WebSiram.Models;

namespace WebSiram.ViewModels
{
    public class UserVM
    {
        public User user { get; set; }
        public Personel personel { get; set; }
        public List<Role> roles { get; set; }
        public List<MGroup> groups { get; set; }
        public List<Divisi> divisis { get; set; }
        public List<Pangkat> pangkats { get; set; }
        public List<Jabatan> jabatans { get; set; }
    }
}
