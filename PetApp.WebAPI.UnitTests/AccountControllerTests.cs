using Microsoft.AspNetCore.Mvc;
using Moq;
using PetApp.WebAPI.Controllers;
using PetApp.WebAPI.Models;
using PetApp.WebAPI.Services;
using PetApp.WebAPI.ViewModels;

namespace PetApp.WebAPI.UnitTests
{
	[TestClass]
	public class AccountControllerTests : BaseControllerTest
	{
		[TestMethod]
		public async Task CreateAccountReturnsBadRequestIfRequiredRequestDataMissed()
		{
			// Arrange
			AccountController controller = new(null, Mock.Of<ITokenService>());
			controller.ModelState.AddModelError("Email", "Email is required");

			// Act
			IActionResult result = await controller.CreateAccount(new UserRegistrationViewModel());

			// Assert
			Assert.IsInstanceOfType<BadRequestObjectResult>(result);
		}

		[TestMethod]
		public async Task CreateAccountReturnsOkAndSavesNewUser()
		{
			// Arrange
			PetAppDbContext testContext = CreateDbContext("TestCreateAccount");
			AccountController controller = new(testContext, Mock.Of<ITokenService>());

			string email = "email";

			// Act
			IActionResult result = await controller.CreateAccount(new UserRegistrationViewModel
			{
				Name = "Test",
				Email = email,
				Password = "password"
			});

			// Assert
			Assert.IsInstanceOfType<OkObjectResult>(result);
			Assert.IsTrue(testContext.Users.Any(u => u.Email == email));
		}

		[TestMethod]
		public async Task LoginReturnsBadRequestIfRequiredRequestDataMissed()
		{
			// Arrange
			AccountController controller = new(null, Mock.Of<ITokenService>());
			controller.ModelState.AddModelError("Email", "Email is required");

			// Act
			IActionResult result = await controller.Login(new UserLoginViewModel());

			// Assert
			Assert.IsInstanceOfType<BadRequestObjectResult>(result);
		}

		[TestMethod]
		public async Task LoginReturnsNotFoundIfThereIsNoUserWithUsernameProvided()
		{
			PetAppDbContext testContext = CreateDbContext("TestNotFound");
			AccountController controller = new(testContext, Mock.Of<ITokenService>());

			// Act
			IActionResult result = await controller.Login(new UserLoginViewModel
			{
				Email = "email",
				Password = "password"
			});

			// Assert
			Assert.IsInstanceOfType<NotFoundObjectResult>(result);
		}

		[TestMethod]
		public async Task LoginReturnsUnauthorizedIfUsernameAndPasswordDoNotMatch()
		{
			PetAppDbContext testContext = CreateDbContext("TestUnauthorized");
			testContext.Users.Add(new User
			{
				Name = "bob",
				Email = "email",
				Password = "password"
			});
			testContext.SaveChanges();

			AccountController controller = new(testContext, Mock.Of<ITokenService>());

			// Act
			IActionResult result = await controller.Login(new UserLoginViewModel
			{
				Email = "email",
				Password = "different"
			});

			// Assert
			Assert.IsInstanceOfType<UnauthorizedObjectResult>(result);
		}

		[TestMethod]
		public async Task LoginReturnsTokenIfUserFoundAndUsernamePasswordAreCorrect()
		{
			PetAppDbContext testContext = CreateDbContext("TestToken");
			testContext.Users.Add(new User
			{
				Name = "bob",
				Email = "email",
				Password = "password"
			});
			testContext.SaveChanges();

			string secret = "testSecret";

			Mock<ITokenService> tokenServiceMock = new();
			tokenServiceMock.Setup(t => t.CreateJwtToken(It.IsAny<string>())).Returns(secret);

			AccountController controller = new(testContext, tokenServiceMock.Object);

			// Act
			IActionResult result = await controller.Login(new UserLoginViewModel
			{
				Email = "email",
				Password = "password"
			});

			// Assert
			OkObjectResult okResult = result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.AreEqual(secret, okResult.Value.GetType().GetProperty("Token").GetValue(okResult.Value));
		}
	}
}