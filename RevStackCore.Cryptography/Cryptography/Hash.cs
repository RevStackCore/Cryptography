namespace RevStackCore.Cryptography
{
	public static class Hash
	{
		public static string Encrypt(string clearText)
		{
			return BCrypt.Net.BCrypt.HashPassword(clearText);
		}

		public static bool Verify(string clearText, string hashedValue)
		{
			return BCrypt.Net.BCrypt.Verify(clearText, hashedValue);
		}

	}
}
