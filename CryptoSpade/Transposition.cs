using System;
using System.Collections.Generic;

namespace CryptoSpade
{
    public sealed class Transposition : SecurityAlgorithm
    {
        private readonly int[] _key;

        public Transposition()
        {
            _key = null;
        }

        public Transposition(int[] key)
        {
            _key = key;
        }

        public string Decrypt(string cipherText)
        {
            int columns = 0, rows = 0;
            Dictionary<int, int> rowsPositions = FillPositionsDictionary(cipherText, ref columns, ref rows);
            var matrix = new char[rows, columns];

            //Fill Matrix
            int charPosition = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[j, rowsPositions[i + 1]] = cipherText[charPosition];
                    charPosition++;
                }
            }

            string result = "";

            foreach (char c in matrix)
            {
                if (c != '*')
                {
                    result += c;
                }
            }

            return result;
        }

        public string Encrypt(string plainText)
        {
            int columns = 0, rows = 0;
            Dictionary<int, int> rowsPositions = FillPositionsDictionary(plainText, ref columns, ref rows);
            var matrix2 = new char[rows, columns];

            //Fill Matrix
            int charPosition = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (charPosition < plainText.Length)
                    {
                        matrix2[i, j] = plainText[charPosition];
                    }
                    else
                    {
                        matrix2[i, j] = ' ';
                    }

                    charPosition++;
                }
            }

            string result = "";

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result += matrix2[j, rowsPositions[i + 1]];
                }

                result += " ";
            }

            return result;
        }

        public static Byte[] EncryptFile(Byte[] pathBytes, string key)
        {
            int columns = key.Length;
            var rows = (int)Math.Ceiling((double)pathBytes.Length / (double)columns);

            var temp = new Byte[columns, rows];
            var result = new Byte[rows * columns];

            int toGrid = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (toGrid >= pathBytes.Length) break;
                    temp[c, r] = pathBytes[toGrid];
                    toGrid++;
                }
            }

            int[] order = OrderString(key);
            for (int i = 0; i < order.Length; i++)
            {
                temp = TransposeColumns(temp, i, Convert.ToInt32(order[i]), rows);
            }

            int toArray = 0;
            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    result[toArray] = temp[c, r];
                    toArray++;
                }
            }
            return result;
        }

        public static Byte[] DecryptFile(Byte[] pathBytes, string key)
        {
            int columns = key.Length;
            var rows = (int)Math.Ceiling((double)pathBytes.Length / (double)columns);

            var temp = new Byte[columns, rows];
            var result = new Byte[rows * columns];

            int toGrid = 0;
            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    if (toGrid >= pathBytes.Length) break;
                    temp[c, r] = pathBytes[toGrid];
                    toGrid++;
                }
            }

            int[] order = OrderString(key);
            for (int i = order.Length - 1; i >= 0; i--)
            {
                temp = TransposeColumns(temp, i, Convert.ToInt32(order[i]), rows);
            }


            int toArray = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {

                    result[toArray] = temp[c, r];
                    toArray++;
                }
            }
            return result;
        }

        private Dictionary<int, int> FillPositionsDictionary(string token, ref int columns, ref int rows)
        {
            var result = new Dictionary<int, int>();
            columns = _key.Length;
            rows = (int)Math.Ceiling(token.Length / (double)columns);
            /*  we need something to tell where to start
             *        4  3  1  2  5  6  7               Key
             *
             *        0  1  2  3  4  5  6               Value
             */
            //attack postponed until two am xyz
            for (int i = 0; i < columns; i++)
            {
                result.Add(_key[i], i);
            }

            return result;
        }

        private static Byte[,] TransposeColumns(Byte[,] input, int swap, int with, int rows)
        {
            var result = (Byte[,])input.Clone();
            for (int i = 0; i < rows; i++)
            {
                result[swap, i] = input[with, i];
                result[with, i] = input[swap, i];
            }
            return result;
        }

        private static int[] OrderString(string input)
        {
            var result = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                int order = input.Length - 1;
                foreach (char c in input)
                {
                    if ((Byte)input[i] < (Byte)c)
                    {
                        order--;
                    }
                }
                result[i] = order;
            }
            return result;
        }
    }
}