
using Microsoft.EntityFrameworkCore;

namespace PetApp.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			// change to AWS Secret Manager in future
			string connectionString = Environment.GetEnvironmentVariable("PetAppConnectionString", EnvironmentVariableTarget.User);

			builder.Services.AddDbContext<PetAppDbContext>(options =>
			    options.UseNpgsql(connectionString));

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}
