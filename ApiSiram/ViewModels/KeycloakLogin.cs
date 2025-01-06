namespace ApiSiram.ViewModels
{
    public class KeycloakLogin
    {
        public string client_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }
    }
}
