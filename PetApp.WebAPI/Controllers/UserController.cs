using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
	}
}
