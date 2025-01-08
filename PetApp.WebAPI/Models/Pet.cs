using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetApp.WebAPI.Models
{
	public class Pet
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int UserId { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public string Breed { get; set; }

		public byte[] Photo { get; set; }

		public int Age { get; set; }

		public string AdditionalInfo { get; set; }

		public bool IsVisibleInSearch { get; set; }
	}
}
