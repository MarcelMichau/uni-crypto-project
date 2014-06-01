using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CryptoSpade
{
    public sealed class Caesar : SecurityAlgorithm
    {
        private readonly int _key;

        public Caesar(int key)
        {
            _key = key;
        }

        public string Decrypt(string cipher)
        {
            return Process(cipher, Mode.Decrypt);
        }

        public string Encrypt(string plainText)
        {
            return Process(plainText, Mode.Encrypt);
        }

        private string Process(string plaintext, Mode mode)
        {
            string result = string.Empty;

            if (!File.Exists(plaintext))
            {
                try
                {
                    foreach (char c in plaintext)
                    {
                        var charposition = Alphabet[c];
                        var res = Common.GetAlphabetPosition(charposition, _key, mode);
                        result += Alphabet.Keys.ElementAt(res % 26);
                    }
                }
                catch (KeyNotFoundException)
                {
                    MessageBox.Show(@"No special characters or numbers are allowed.", @"Key Type Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = null;
                }
            }
            else
            {
                if (mode.ToString() == "Encrypt")
                {
                    byte[] fileBytes = File.ReadAllBytes(plaintext);

                    for (int i = 0; i < fileBytes.Length; i++)
                    {
                        fileBytes[i] = (byte)(fileBytes[i] + _key);
                    }

                    File.WriteAllBytes(plaintext, fileBytes);
                }
                else
                {
                    byte[] fileBytes = File.ReadAllBytes(plaintext);

                    for (int i = 0; i < fileBytes.Length; i++)
                    {
                        fileBytes[i] = (byte)(fileBytes[i] - _key);
                    }

                    File.WriteAllBytes(plaintext, fileBytes);
                }
            }
            return result;
        }
    }
}