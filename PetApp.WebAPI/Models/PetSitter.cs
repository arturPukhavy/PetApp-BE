using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetApp.WebAPI.Models
{
	public class PetSitter
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public int SitterId { get; set; }

		[ForeignKey("SitterId")]
		public virtual Sitter Sitter { get; set; }

		[Required]
		public int PetId { get; set; }

		[ForeignKey("PetId")]
		public virtual Pet Pet { get; set; }

		[Required]
		public double Price { get; set; }
	}
}
