using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetApp.WebAPI.Models
{
	public class Ad
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Title { get; set; }

		[Required]
		public int CreatorId { get; set; }

		[ForeignKey("CreatorId")]
		public User Creator { get; set; }

		public string Description { get; set; }

		public string Location { get; set; }

		public int PetId { get; set; }

		[ForeignKey("PetId")]
		public Pet Pet { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		[Required]
		public int AdStateId { get; set; }

		[ForeignKey("AdStateId")]
		public virtual AdState AdState { get; set; }

		public double Rate { get; set; }

		public int? AssignedSitterId { get; set; }

		[ForeignKey("AssignedSitterId")]
		public virtual Sitter AssignedSitter { get; set; }

		public DateTime CreatedDate { get; set; }
	}
}
