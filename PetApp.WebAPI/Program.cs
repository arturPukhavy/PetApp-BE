using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PetApp.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			// change to AWS Secret Manager in future
			string connectionString = Environment.GetEnvironmentVariable("PetAppConnectionString") ?? Environment.GetEnvironmentVariable("PetAppConnectionString", EnvironmentVariableTarget.User);

			if (string.IsNullOrEmpty(connectionString))
			{
				throw new Exception("Connection string is not set");
			}

			builder.Services.AddDbContext<PetAppDbContext>(options =>
			    options.UseNpgsql(connectionString));

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// change to AWS Secret Manager in future
			string jwtSecretKey = Environment.GetEnvironmentVariable("JwtSecretKey") ?? Environment.GetEnvironmentVariable("JwtSecretKey", EnvironmentVariableTarget.User);

			builder.Services
				.AddAuthentication(x =>
				{
					x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(x =>
				{
					x.RequireHttpsMetadata = false;
					x.SaveToken = true;
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecretKey)),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});

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

			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}
