using Microsoft.EntityFrameworkCore;

namespace PetApp.WebAPI.UnitTests
{
	public class BaseControllerTest
	{
		protected static PetAppDbContext CreateDbContext(string dbName)
		{
			DbContextOptions<PetAppDbContext> options = new DbContextOptionsBuilder<PetAppDbContext>()
				.UseInMemoryDatabase(databaseName: dbName)
				.Options;

			PetAppDbContext dbContext = new(options);

			return dbContext;
		}
	}
}
