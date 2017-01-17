using System;
using System.Security.Cryptography;
using System.Text;

namespace RevStackCore.Cryptography
{
	public static class Symmetric
	{
		public static string Encrypt(string clearText, string key)
		{
			byte[] inputArray = Encoding.UTF8.GetBytes(clearText);
			var tripleDES = TripleDES.Create();
			tripleDES.Key = Encoding.UTF8.GetBytes(key);
			tripleDES.Mode = CipherMode.ECB;
			tripleDES.Padding = PaddingMode.PKCS7;
			ICryptoTransform cTransform = tripleDES.CreateEncryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
			tripleDES.Dispose();
			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}

		public static string Decrypt(string encryptedText, string key)
		{
			byte[] inputArray = Convert.FromBase64String(encryptedText);
			var tripleDES = TripleDES.Create();
			tripleDES.Key = Encoding.UTF8.GetBytes(key);
			tripleDES.Mode = CipherMode.ECB;
			tripleDES.Padding = PaddingMode.PKCS7;
			ICryptoTransform cTransform = tripleDES.CreateDecryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
			tripleDES.Dispose();
			return Encoding.UTF8.GetString(resultArray);
		}


	}
}
