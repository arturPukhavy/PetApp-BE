using Microsoft.EntityFrameworkCore;
using PetApp.WebAPI.Models;

namespace PetApp.WebAPI
{
	public class PetAppDbContext(DbContextOptions<PetAppDbContext> options) : DbContext(options)
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// some initial test data
			modelBuilder.Entity<Role>().HasData(
				new Role
				{
					Id = 1,
					Name = "User",
					Test = "Test"
				});

			modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
					Name = "Harry Potter",
					Email = "dirtyharry@gmail.com",
					Password = "123456",
					Contacts = "Instagram:hp",
					DateRegistered = new DateTime(2020, 1, 1, 2, 3, 4, DateTimeKind.Utc).ToUniversalTime(),
					RoleId = 1
				},
				new User
				{
					Id = 2,
					Name = "Ron Weasley",
					Email = "gingerhead@gmail.com",
					Password = "123456",
					Contacts = "Instagram:rw",
					DateRegistered = new DateTime(2020, 1, 1, 2, 3, 4, DateTimeKind.Utc).ToUniversalTime(),
					RoleId = 1
				},
				new User
				{
					Id = 3,
					Name = "Hermione Granger",
					Email = "Hermione.Granger@gmail.com",
					Password = "123456",
					Contacts = "Instagram:hg",
					DateRegistered = new DateTime(2020, 1, 1, 2, 3, 4, DateTimeKind.Utc).ToUniversalTime(),
					RoleId = 1,
				});
		}

		public DbSet<Ad> Ads { get; set; }

		public DbSet<AdState> AdStates { get; set; }

		public DbSet<Chat> Chats { get; set; }

		public DbSet<Message> Messages { get; set; }

		public DbSet<Pet> Pets { get; set; }

		public DbSet<PetSitter> PetSitters { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<Sitter> Sitters { get; set; }

		public DbSet<User> Users { get; set; }
	}
}
