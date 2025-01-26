using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetApp.WebAPI.Services
{
	public class TokenService : ITokenService
	{
		public string CreateJwtToken(string userName)
		{
			// change to AWS Secret Manager in future
			string jwtSecretKey = Environment.GetEnvironmentVariable("JwtSecretKey") ?? Environment.GetEnvironmentVariable("JwtSecretKey", EnvironmentVariableTarget.User);

			SecurityTokenDescriptor tokenDescriptor = new()
			{
				Subject = new ClaimsIdentity([new Claim(ClaimTypes.Name, userName)]),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecretKey)), SecurityAlgorithms.HmacSha256Signature)
			};

			JwtSecurityTokenHandler tokenHandler = new();

			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
