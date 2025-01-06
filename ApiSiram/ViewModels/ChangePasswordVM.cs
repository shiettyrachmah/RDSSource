namespace ApiSiram.ViewModels
{
    public class ChangePasswordVM
    {
        public string? user_id { get; set; }
        public string? password { get; set; }
        public string? confirm_password { get; set; }
        public string? created_by { get; set; }
    }
}
