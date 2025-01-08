using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetApp.WebAPI.Models
{
	public class Message
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int ChatId { get; set; }

		[ForeignKey("ChatId")]
		public Chat Chat { get; set; }

		public string Text { get; set; }

		public DateTime DateTimeSent { get; set; }
	}
}
