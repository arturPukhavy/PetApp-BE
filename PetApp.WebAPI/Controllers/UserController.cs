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
		public async Task<IEnumerable<User>> Get()
		{
			return await _context.Users.ToListAsync();
		}
	}
}
