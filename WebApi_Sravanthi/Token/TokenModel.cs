namespace WebApi_Sravanthi.Token
{
    // ✅ Separate models, not inside TokenModel class
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RefreshRequest
    {
        public string OldToken { get; set; }
        public string RefToken { get; set; }
    }
}
