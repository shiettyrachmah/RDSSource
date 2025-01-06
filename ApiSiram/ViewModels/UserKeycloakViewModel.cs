namespace ApiSiram.ViewModels
{
    public class UserKeycloakViewModel
    {
        public int code { get; set; }
        public bool status { get; set; }
        public string? message { get; set; }
        public KeycloakClaim? claim { get; set; }
    }

    public class KeycloakClaim
    {
        public string scope { get; set; }
        public string matra { get; set; }
        public bool email_verified { get; set; }
        public string alamat_kesatuan { get; set; }
        public string jabatan { get; set; }
        public string telepon { get; set; }
        public string kd_satuan { get; set; }
        public string agama { get; set; }
        public string korps { get; set; }
        public string pangkat { get; set; }
        public string kesatuan { get; set; }
        public string preferred_username { get; set; }
        public string given_name { get; set; }
        public string nrp { get; set; }
        public string alamat { get; set; }
        public string kd_jabatan { get; set; }
        public string kd_pangkat { get; set; }
        public string user_id { get; set; }
        public string name { get; set; }
        public string family_name { get; set; }
        public string jenis_kelamin { get; set; }
        public string email { get; set; }
    }
}
