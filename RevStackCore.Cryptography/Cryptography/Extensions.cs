using System.Net.Http.Headers;

namespace RevStackCore.Cryptography
{
	public static class Extensions
	{
		public static string ToSymmetricEncryptedString(this string source, string key)
		{
			return Symmetric.Encrypt(source, key);
		}

		public static string ToSymmetricDecryptedString(this string source, string key)
		{
			return Symmetric.Decrypt(source, key);
		}

		public static string ToHashedString(this string source)
		{
			return Hash.Encrypt(source);
		}

		public static bool ToVerifiedHash(this string source, string clearText)
		{
			return Hash.Verify(clearText, source);
		}

		public static string ToEncryptedBase64String(this string source)
		{
			return Base64.Encrypt(source);
		}

		public static string ToEncryptedBase64String(this Base64Credentials source)
		{
			return Base64.EncryptCredentials(source);
		}

		public static Base64Credentials ToBase64Credentials(this string source)
		{
			return Base64.DecryptCredentials(source);
		}

		public static Base64Credentials ToBase64Credentials(this AuthenticationHeaderValue source)
		{
			return Base64.DecryptCredentials(source);
		}

		public static string ToDecryptedBase64String(this string source)
		{
			return Base64.Decrypt(source);
		}
	}
}
