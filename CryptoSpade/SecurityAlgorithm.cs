using System.Collections.Generic;

namespace CryptoSpade
{
    public abstract class SecurityAlgorithm
    {
        protected readonly Dictionary<char, int> Alphabet;

        protected SecurityAlgorithm()
        {
            Alphabet = new Dictionary<char, int>();
            char c = 'a';
            Alphabet.Add(c, 0);

            for (int i = 1; i < 26; i++)
            {
                Alphabet.Add(++c, i);
            }
        }
    }
}