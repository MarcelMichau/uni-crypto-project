using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CryptoSpade
{
    public class Vernam
    {
        private readonly string _key;

        public Vernam(string key)
        {
            _key = key;
        }

        public string Decrypt(string cipher)
        {
            return Process(cipher);
        }

        public void DecryptFile(string encryptedFile, string decryptedFile)
        {
            // Read in the encrypted bytes:
            byte[] encryptedBytes;
            using (var fs = new FileStream(encryptedFile, FileMode.Open))
            {
                encryptedBytes = new byte[fs.Length];
                fs.Read(encryptedBytes, 0, encryptedBytes.Length);
            }

            // Read in the key:
            byte[] keyBytes;
            using (var fs = new FileStream(_key, FileMode.Open))
            {
                keyBytes = new byte[fs.Length];
                fs.Read(keyBytes, 0, keyBytes.Length);
            }

            // Decrypt the data with the Vernam-algorithm:
            var decryptedBytes = new byte[encryptedBytes.Length];
            DoVernam(encryptedBytes, keyBytes, ref decryptedBytes);

            // Write the decrypted file:
            using (var fs = new FileStream(decryptedFile, FileMode.Create))
            {
                fs.Write(decryptedBytes, 0, decryptedBytes.Length);
            }
        }

        public string Encrypt(string plaintext)
        {
            return Process(plaintext);
        }

        public void EncryptFile(string originalFile, string encryptedFile)
        {
            // Read in the bytes from the original file:
            byte[] originalBytes;
            using (var fs = new FileStream(originalFile, FileMode.Open))
            {
                originalBytes = new byte[fs.Length];
                fs.Read(originalBytes, 0, originalBytes.Length);
            }

            // Create the one time key for encryption. This is done
            // by generating random bytes that are of the same lenght
            // as the original bytes:
            var keyBytes = new byte[originalBytes.Length];
            var random = new Random();
            random.NextBytes(keyBytes);

            // Write the key to the file:
            using (var fs = new FileStream(_key, FileMode.Create))
            {
                fs.Write(keyBytes, 0, keyBytes.Length);
            }

            // Encrypt the data with the Vernam-algorithm:
            var encryptedBytes = new byte[originalBytes.Length];
            DoVernam(originalBytes, keyBytes, ref encryptedBytes);

            // Write the encrypted file:
            using (var fs = new FileStream(encryptedFile, FileMode.Create))
            {
                fs.Write(encryptedBytes, 0, encryptedBytes.Length);
            }
        }

        private void DoVernam(byte[] inBytes, byte[] keyBytes, ref byte[] outBytes)
        {
            // Check arguments:
            if ((inBytes.Length != keyBytes.Length) ||
                (keyBytes.Length != outBytes.Length))
                throw new ArgumentException("Byte-array are not of same length");

            // Encrypt/decrypt by XOR:
            for (int i = 0; i < inBytes.Length; i++)
                outBytes[i] = (byte)(inBytes[i] ^ keyBytes[i]);
        }

        private string Process(string plaintext)
        {
            string output = string.Empty;
            if (plaintext.Length == _key.Length)
            {
                var result = new StringBuilder();

                for (int c = 0; c < plaintext.Length; c++)
                    result.Append((char)(plaintext[c] ^ _key[c % _key.Length]));

                return result.ToString();
            }
            MessageBox.Show(@"The plaintext and key are not the same length.", @"Key Length Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return output;
        }
    }
}