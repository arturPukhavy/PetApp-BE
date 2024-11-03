using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetApp.WebAPI.Models
{
	public class UnavailableTimeframeSitter
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public int SitterId { get; set; }

		[ForeignKey("SitterId")]
		public virtual Sitter Sitter { get; set; }

		[Required]
		public int UnavailableTimeframeId { get; set; }

		[ForeignKey("UnavailableTimeframeId")]
		public virtual UnavailableTimeframe UnavailableTimeframe { get; set; }
	}
}
