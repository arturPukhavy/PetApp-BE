﻿using System.ComponentModel.DataAnnotations;

namespace PetApp.WebAPI.ViewModels
{
	public class UserLoginViewModel
	{
		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
