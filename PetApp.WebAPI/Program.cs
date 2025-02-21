using PetApp.WebAPI.MiddlewareExtensions;
using Serilog;

namespace PetApp.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			// Configure Serilog
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.File("C:/logs/serilog.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();

			// Add Serilog
			builder.Services.AddLogging(loggingBuilder =>
				loggingBuilder.AddSerilog(dispose: true));

			builder.Services.AddAppDatabase();
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddCustomAppServices();

			builder.Services.AddAppAuthentication();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			else
			{
				app.Use(async (context, next) =>
				{
					if (context.Request.Path == "/")
					{
						await context.Response.WriteAsync("Welcome to PetApp API!");
						return;
					}

					await next();
				});
			}

			//app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}
