using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CryptoSpade
{
    internal class StrongEncrypt
    {
        private const string Hash = "SHA1";
        private const int Iterations = 2;
        private const int KeySize = 256;
        private static string _salt;
        private static string _vector;
        private static string _password;

        public StrongEncrypt(string password)
        {
            var rsv = new RandomSaltAndVector(password);

            _password = password;
            _salt = rsv.Salt;
            _vector = rsv.Vector;
        }

        public static string Decrypt<T>(string value) where T : SymmetricAlgorithm, new()
        {
            if (!File.Exists(value))
            {
                byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
                byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
                byte[] valueBytes = Convert.FromBase64String(value);

                byte[] decrypted;
                int decryptedByteCount;

                using (var cipher = new T())
                {
                    var passwordBytes = new PasswordDeriveBytes(_password, saltBytes, Hash, Iterations);
                    byte[] keyBytes = passwordBytes.GetBytes(KeySize / 8);

                    cipher.Mode = CipherMode.CBC;

                    try
                    {
                        using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                        {
                            using (var from = new MemoryStream(valueBytes))
                            {
                                using (var reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                                {
                                    decrypted = new byte[valueBytes.Length];
                                    decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                    cipher.Clear();
                }
                return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
            }
            else
            {
                byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
                byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);

                using (var cipher = new T())
                {
                    var passwordBytes = new PasswordDeriveBytes(_password, saltBytes, Hash, Iterations);
                    byte[] keyBytes = passwordBytes.GetBytes(KeySize / 8);

                    var fsread = new FileStream(value, FileMode.Open, FileAccess.Read);

                    ICryptoTransform decrypt = cipher.CreateDecryptor(keyBytes, vectorBytes);

                    var cryptostreamDecr = new CryptoStream(fsread,
                       decrypt,
                       CryptoStreamMode.Read);

                    var fsDecrypted = new StreamWriter(value + "_d");
                    fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
                    fsDecrypted.Flush();
                    fsDecrypted.Close();

                    return null;
                }
            }
        }

        public static string Encrypt<T>(string value)
                where T : SymmetricAlgorithm, new()
        {
            if (!File.Exists(value))
            {
                byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
                byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
                byte[] valueBytes = Encoding.UTF8.GetBytes(value);

                byte[] encrypted;
                using (var cipher = new T())
                {
                    var passwordBytes =
                        new PasswordDeriveBytes(_password, saltBytes, Hash, Iterations);
                    byte[] keyBytes = passwordBytes.GetBytes(KeySize / 8);

                    cipher.Mode = CipherMode.CBC;

                    using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
                    {
                        using (var to = new MemoryStream())
                        {
                            using (var writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                            {
                                writer.Write(valueBytes, 0, valueBytes.Length);
                                writer.FlushFinalBlock();
                                encrypted = to.ToArray();
                            }
                        }
                    }
                    cipher.Clear();
                }
                return Convert.ToBase64String(encrypted);
            }
            else
            {
                byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
                byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);

                using (var cipher = new T())
                {
                    var passwordBytes = new PasswordDeriveBytes(_password, saltBytes, Hash, Iterations);
                    byte[] keyBytes = passwordBytes.GetBytes(KeySize / 8);

                    var fsInput = new FileStream(value, FileMode.Open, FileAccess.Read);

                    var fsEncrypted = new FileStream(value + "_e", FileMode.Create, FileAccess.Write);

                    ICryptoTransform encrypt = cipher.CreateEncryptor(keyBytes, vectorBytes);
                    var cryptostream = new CryptoStream(fsEncrypted, encrypt, CryptoStreamMode.Write);

                    var bytearrayinput = new byte[fsInput.Length];
                    fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                    cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                    cryptostream.Close();
                    fsInput.Close();
                    fsEncrypted.Close();

                    return null;
                }
            }
        }

        private class RandomSaltAndVector
        {
            public RandomSaltAndVector(string password)
            {
                int seed = password.GetHashCode();
                const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
                var random = new Random(seed);

                Salt = new string(
                    Enumerable.Repeat(chars, 16)
                              .Select(s => s[random.Next(s.Length)])
                              .ToArray());

                Vector = new string(
                   Enumerable.Repeat(chars, 16)
                             .Select(s => s[random.Next(s.Length)])
                             .ToArray());
            }

            public string Salt { get; private set; }

            public string Vector { get; private set; }
        }
    }
}