using JWT.API.Models.Login;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.API.Services.Auth
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configruation)
        {
            _configuration = configruation;
        }

        public async Task<LoginResponse?> Authenticate(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Password))
                return null;

            //Simulate search in database the user and password

            return new LoginResponse
            {
                Token = GenerateToken(request),
                Name = request.Name,
                ExpiresIn = _configuration.GetValue<int>("Jwt:ExpirationInMinutes")
            };
        }

        private string GenerateToken(LoginRequest request)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];
            var tokenValidtyMins = _configuration.GetValue<int>("Jwt:ExpirationInMinutes");
            var TokenExpiryTimeSptamp = DateTime.UtcNow.AddMinutes(tokenValidtyMins);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Name, request.Name) }),
                Expires = TokenExpiryTimeSptamp,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256Signature),

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return accessToken;
        }
    }
}
