using Microsoft.EntityFrameworkCore;

namespace PetApp.WebAPI.UnitTests
{
	public class BaseControllerTest
	{
		protected PetAppDbContext CreateDbContext(string dbName)
		{
			DbContextOptions<PetAppDbContext> options = new DbContextOptionsBuilder<PetAppDbContext>()
				.UseInMemoryDatabase(databaseName: dbName)
				.Options;

			PetAppDbContext dbContext = new(options);

			return dbContext;
		}
	}
}
