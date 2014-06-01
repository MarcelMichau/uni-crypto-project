using System;

namespace CryptoSpade
{
    public sealed class Vigenere : SecurityAlgorithm
    {
        private string _key;

        public Vigenere(string key)
        {
            _key = key;
        }

        public string Decrypt(string cipherText)
        {
            return Process(cipherText, Mode.Decrypt);
        }

        public Byte[] DecryptFile(Byte[] ciphertext)
        {
            var result = new Byte[ciphertext.Length];

            _key = _key.Trim().ToUpper();

            int keyIndex = 0;
            int keylength = _key.Length;

            for (int i = 0; i < ciphertext.Length; i++)
            {
                keyIndex = keyIndex % keylength;
                int shift = _key[keyIndex] - 65;
                result[i] = (byte)((ciphertext[i] + 256 - shift) % 256);
                keyIndex++;
            }
            return result;
        }

        public string Encrypt(string plainText)
        {
            return Process(plainText, Mode.Encrypt);
        }

        public Byte[] EncryptFile(Byte[] plaintext)
        {
            var result = new Byte[plaintext.Length];

            _key = _key.Trim().ToUpper();

            int keyIndex = 0;
            int keylength = _key.Length;

            for (int i = 0; i < plaintext.Length; i++)
            {
                keyIndex = keyIndex % keylength;
                int shift = _key[keyIndex] - 65;
                result[i] = (byte)((plaintext[i] + shift) % 256);
                keyIndex++;
            }
            return result;
        }

        private string DuplicateKey(string message, string key)
        {
            if (key.Length < message.Length)
            {
                int length = message.Length - key.Length;

                for (int i = 0; i < length; i++)
                {
                    key += key[i % key.Length];
                }
            }

            return key;
        }

        private string Process(string message, Mode mode)
        {
            _key = _key.ToLower().Replace(" ", "");
            _key = DuplicateKey(message, _key);
            return Common.Shift(message, _key, mode, Alphabet);
        }
    }
}