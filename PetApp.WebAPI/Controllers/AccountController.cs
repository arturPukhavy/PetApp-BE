using Microsoft.AspNetCore.Mvc;
using PetApp.WebAPI.Models;
using PetApp.WebAPI.ViewModels;

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
	}
}
