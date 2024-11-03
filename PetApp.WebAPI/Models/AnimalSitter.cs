using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetApp.WebAPI.Models
{
	public class AnimalSitter
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public int SitterId { get; set; }

		[ForeignKey("SitterId")]
		public virtual Sitter Sitter { get; set; }

		[Required]
		public int AnimalId { get; set; }

		[ForeignKey("AnimalId")]
		public virtual Animal Animal { get; set; }

		[Required]
		public double Price { get; set; }
	}
}
