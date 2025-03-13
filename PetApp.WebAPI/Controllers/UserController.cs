using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetApp.WebAPI.Models;

namespace PetApp.WebAPI.Controllers
{
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ILogger<UserController> _logger;
		private readonly PetAppDbContext _context;

		public UserController(ILogger<UserController> logger, PetAppDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet]
		[Route("api/users")]
		public async Task<IActionResult> Get()
		{
			return new JsonResult(await _context.Users.ToListAsync());
		}

		[HttpGet]
		[Route("api/users/{id}")]
		[Authorize]
		public async Task<IActionResult> Get(int id)
		{
			User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

			if (user == null)
			{
				return NotFound(new { Message = "User not found" });
			}

			return new JsonResult(user);
		}
	}
}
