using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetApp.WebAPI.Models;
using PetApp.WebAPI.Services;
using PetApp.WebAPI.ViewModels;

namespace PetApp.WebAPI.Controllers
{
	[ApiController]
	public class AccountController(PetAppDbContext context, ITokenService tokenService) : ControllerBase
	{
		[HttpPost]
		[Route("api/account")]
		public async Task<IActionResult> CreateAccount(UserRegistrationViewModel viewModel)
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
				return NotFound(new { Message = "User not found" });
			}

			if (user.Password != viewModel.Password)
			{
				return Unauthorized(new { Message = "Username or password is incorrect" });
			}

			string token = tokenService.CreateJwtToken(viewModel.Email);

			return Ok(new { Token = token });
		}
	}
}
