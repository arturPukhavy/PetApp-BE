﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetApp.WebAPI.Services;
using System.Text;

namespace PetApp.WebAPI.MiddlewareExtensions
{
	public static class AppExtensions
	{
		public static void AddCustomAppServices(this IServiceCollection services)
		{
			services.AddTransient<ITokenService, TokenService>();
		}

		public static void AddAppDatabase(this IServiceCollection services)
		{
			string connectionString = Environment.GetEnvironmentVariable("PetAppConnectionString") ?? Environment.GetEnvironmentVariable("PetAppConnectionString", EnvironmentVariableTarget.User);

			if (string.IsNullOrEmpty(connectionString))
			{
				throw new Exception("Connection string is not set");
			}

			services.AddDbContext<PetAppDbContext>(options =>
				options.UseNpgsql(connectionString));
		}

		public static void AddAppAuthentication(this IServiceCollection services)
		{
			// change to AWS Secret Manager in future
			string jwtSecretKey = Environment.GetEnvironmentVariable("JwtSecretKey") ?? Environment.GetEnvironmentVariable("JwtSecretKey", EnvironmentVariableTarget.User);

			if (string.IsNullOrEmpty(jwtSecretKey))
			{
				throw new Exception("Authentication token is not set");
			}

			services
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
		}
	}
}
