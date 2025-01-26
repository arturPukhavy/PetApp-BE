using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetApp.WebAPI.Models;
using PetApp.WebAPI.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetApp.WebAPI.Controllers
{
	[ApiController]
	public class AccountController(PetAppDbContext context) : ControllerBase
	{
		[HttpPost]
		[Route("api/account")]
		public async Task<ActionResult> CreateAccount(UserRegistrationViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			User newUser = new()
			{
				Name = viewModel.Name,
				Email = viewModel.Email,
				Password = viewModel.Password,
				DateRegistered = DateTime.Now.ToUniversalTime(),
				RoleId = 1
			};

			await context.Users.AddAsync(newUser);

			await context.SaveChangesAsync();

			return Ok("Ok");
		}

		[HttpPost("api/login")]
		public async Task<IActionResult> Login(UserLoginViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			User user = await context.Users.FirstOrDefaultAsync(u => u.Email == viewModel.Email);
			if (user == null)
			{
				return Unauthorized(new { Message = "User not found" });
			}

			if (user.Password != viewModel.Password)
			{
				return Unauthorized(new { Message = "Username or password is incorrect" });
			}

			string token = GenerateJwtToken(viewModel.Email);

			return Ok(new { Token = token });
		}

		private static string GenerateJwtToken(string username)
		{
			// change to AWS Secret Manager in future
			string jwtSecretKey = Environment.GetEnvironmentVariable("JwtSecretKey") ?? Environment.GetEnvironmentVariable("JwtSecretKey", EnvironmentVariableTarget.User);

			SecurityTokenDescriptor tokenDescriptor = new()
			{
				Subject = new ClaimsIdentity([ new Claim(ClaimTypes.Name, username) ]),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecretKey)), SecurityAlgorithms.HmacSha256Signature)
			};

			JwtSecurityTokenHandler tokenHandler = new();

			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
