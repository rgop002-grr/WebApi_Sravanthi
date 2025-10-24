using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi_Sravanthi.Token;  // 👈 Use the correct namespace

namespace WebApi_Sravanthi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshTokenController : ControllerBase
    {
        private static string refreshToken = "";
        private static string secretKey = "MySuperSecretKeyForJwtDemo@1234567890";

        // 🟢 Login → Generate Access & Refresh Tokens
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username != "sravanthi" || request.Password != "1234")
                return Unauthorized("Invalid user");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Username)
            };

            var token = new JwtSecurityToken(
                issuer: "myapp",
                audience: "myappusers",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: creds);

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            refreshToken = GenerateRefreshToken();

            return Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
        }

        // 🔄 Refresh Access Token
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] RefreshRequest model)
        {
            if (model.RefToken != refreshToken)
                return Unauthorized("Invalid refresh token");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var newToken = new JwtSecurityToken(
                issuer: "myapp",
                audience: "myappusers",
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: creds);

            string accessToken = new JwtSecurityTokenHandler().WriteToken(newToken);
            refreshToken = GenerateRefreshToken();

            return Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
        }

        // 🔐 Helper: Generate random refresh token
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
