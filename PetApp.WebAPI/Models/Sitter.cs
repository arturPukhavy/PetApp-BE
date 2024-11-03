using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetApp.WebAPI.Models
{
	public class Sitter
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Description { get; set; }

		public int Location { get; set; }

		public double Rate { get; set; }

		public string Contacts { get; set; }
	}
}
