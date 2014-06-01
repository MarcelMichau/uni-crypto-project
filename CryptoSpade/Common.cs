using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CryptoSpade
{
    internal static class Common
    {
        internal static int GetAlphabetPosition(int textPosition, int keyPosition, Mode mode)
        {
            var result = 0;

            switch (mode)
            {
                case Mode.Encrypt:
                    result = (textPosition + keyPosition) % 26;
                    break;

                case Mode.Decrypt:
                    result = textPosition - keyPosition;

                    if (result < 0)
                    {
                        result += 26;
                    }
                    break;
            }

            return result;
        }

        internal static string Shift(string token, string key, Mode mode, Dictionary<char, int> alphabetSorted)
        {
            var result = "";
            try
            {
                for (int i = 0; i < token.Length; i++)
                {
                    var textPosition = alphabetSorted[token[i]];
                    var keyPosition = alphabetSorted[key[i]];
                    var resPosition = GetAlphabetPosition(textPosition, keyPosition, mode);
                    result += alphabetSorted.Keys.ElementAt(resPosition);
                }
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show(@"No special characters are allowed.", @"Key Type Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = null;
            }
            return result;
        }
    }
}