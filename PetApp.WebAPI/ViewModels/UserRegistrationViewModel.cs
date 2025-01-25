using System.ComponentModel.DataAnnotations;

namespace PetApp.WebAPI.ViewModels
{
	public class UserRegistrationViewModel
	{
		public string Name { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
