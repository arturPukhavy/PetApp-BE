namespace PetApp.WebAPI.Services
{
	public interface ITokenService
	{
		string CreateJwtToken(string userName);
	}
}