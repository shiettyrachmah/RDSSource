namespace ApiSiram.ViewModels
{
    public class ResponseLogin
    {
        public int code { get; set; }
        public bool status { get; set; }
        public string? message { get; set; }
        public string? user_id { get; set; }
        public string? username { get; set; }
        public string? role { get; set; }
        public string? token { get; set; }
        
    }
}
