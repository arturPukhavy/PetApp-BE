namespace PetApp.WebAPI.Utilities
{
	public static class FileUtility
	{
		private const string JwtConfigFilePath = @"C:\config\JwtSecretKey.txt";

		public static string JwtToken => GetJwtSecretKey();

		private static string GetJwtSecretKey()
		{
			if (!File.Exists(JwtConfigFilePath))
			{
				throw new Exception("JWT Secret Key file is not found");
			}

			string token = File.ReadAllText(JwtConfigFilePath);

			return token;
		}
	}
}
