using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class JwtService
    {
        public async Task<string> GenerateJwtTokenAsync(string userId, string userEmail)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f1nj34fn114123r81hf12d812d982121fd21r"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Email, userEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                // Puedes agregar más claims según las necesidades de tu aplicación
            };

            var token = new JwtSecurityToken(
                issuer: "Mauricio Avendaño",
                audience: "ValidAudience",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Configura el tiempo de expiración del token
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
