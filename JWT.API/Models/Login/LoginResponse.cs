namespace JWT.API.Models.Login
{
    public class LoginResponse
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}
