using System.ComponentModel.DataAnnotations;

namespace ApiSiram.ViewModels
{
    public class RequestLogin
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? password { get; set; }
    }
}
