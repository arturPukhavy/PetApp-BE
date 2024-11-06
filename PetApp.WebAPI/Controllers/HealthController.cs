using Microsoft.AspNetCore.Mvc;

namespace PetApp.WebAPI.Controllers
{
	[ApiController]
	public class HealthController : ControllerBase
	{
		[HttpGet]
		[Route("api/statuscheck")]
		public OkObjectResult Get()
		{
			return Ok("Ok");
		}
	}
}
