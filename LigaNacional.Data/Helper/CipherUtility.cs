using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LigaNacional.Data.Helper
{
    public class CipherUtility
    {

        private static string Encrypt<T>(string value, string password, string salt) where T : SymmetricAlgorithm, new()
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            SymmetricAlgorithm algorithm = new T();

            var rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

            var transform = algorithm.CreateEncryptor(rgbKey, rgbIV);

            using (var buffer = new MemoryStream())
            {
                using (var stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
                {
                    using (var writer = new StreamWriter(stream, Encoding.Unicode))
                    {
                        writer.Write(value);
                    }
                }

                return Convert.ToBase64String(buffer.ToArray());
            }
        }

        private static string Decrypt<T>(string text, string password, string salt) where T : SymmetricAlgorithm, new()
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            SymmetricAlgorithm algorithm = new T();

            var rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

            var transform = algorithm.CreateDecryptor(rgbKey, rgbIV);

            using (var buffer = new MemoryStream(Convert.FromBase64String(text)))
            {
                using (var stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
                {
                    using (var reader = new StreamReader(stream, Encoding.Unicode))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        public static string AesEncript(string plain)
        {
            var encript = Encrypt<AesManaged>(plain, "pw_aes", "salt_aes");
            return encript;
        }

        public static string AesDecript(string encrypted)
        {
            var encript = CipherUtility.Decrypt<AesManaged>(encrypted, "pw_aes", "salt_aes");
            return encript;
        }

        public static string TripeDesEncript(string plain)
        {
            var encript = Encrypt<TripleDESCryptoServiceProvider>(plain, "pw_tpledes", "salt_tpledes");
            return encript;
        }

        public static string TripeDesDecript(string encrypted)
        {
            var encript = CipherUtility.Decrypt<TripleDESCryptoServiceProvider>(encrypted, "pw_tpledes", "salt_tpledes");
            return encript;
        }

        public static string RijndaelEncript(string plain)
        {
            var encript = Encrypt<RijndaelManaged>(plain, "pw_rijdael", "salt_rijdael");
            return encript;
        }

        public static string RijndaelDecript(string encrypted)
        {
            var encript = CipherUtility.Decrypt<RijndaelManaged>(encrypted, "pw_rijdael", "salt_rijdael");
            return encript;
        }

       
    }

}