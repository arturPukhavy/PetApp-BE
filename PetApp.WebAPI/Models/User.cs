using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetApp.WebAPI.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string Contacts { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime DateRegistered { get; set; }

		public byte[]? Photo { get; set; }

		public int RoleId { get; set; }

		[ForeignKey("RoleId")]
		public virtual Role Role { get; set; }

		public int? SitterId { get; set; }

		[ForeignKey("SitterId")]
		public virtual Sitter Sitter { get; set; }
	}
}
