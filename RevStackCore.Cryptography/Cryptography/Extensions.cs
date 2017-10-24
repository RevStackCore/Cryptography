using System;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

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

		public static string ToEncryptedBase64String(this Base64Credential source)
		{
			return Base64.EncryptCredentials(source);
		}

		public static Base64Credential ToBase64Credentials(this string source)
		{
			return Base64.DecryptCredentials(source);
		}

		public static Base64Credential ToBase64Credentials(this AuthenticationHeaderValue source)
		{
			return Base64.DecryptCredentials(source);
		}

		public static string ToDecryptedBase64String(this string source)
		{
			return Base64.Decrypt(source);
		}

        public static byte[] GenerateByteKey()
        {
            var generator = RandomNumberGenerator.Create();
            var salt = new byte[256 / 8];
            generator.GetBytes(salt);
            return salt;
        }

        public static string GenerateByteKeyString()
        {
            var salt = GenerateByteKey();
            return Encoding.UTF8.GetString(salt);
        }

        public static string GenerateKey()
        {
            return GenerateKey(24);
        }

        public static string GenerateKey(int length)
        {
            const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%&*()+=abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();
            var rand = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = pool[rand.Next(0, pool.Length)];
                builder.Append(c);
            }
            return builder.ToString();
        }

        public static string RandomString(int length)
        {
            const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();
            var rand = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = pool[rand.Next(0, pool.Length)];
                builder.Append(c);
            }
            return builder.ToString();
        }

        public static string RandomString(int length,string pool)
        {
            var builder = new StringBuilder();
            var rand = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = pool[rand.Next(0, pool.Length)];
                builder.Append(c);
            }
            return builder.ToString();
        }
	}
}
