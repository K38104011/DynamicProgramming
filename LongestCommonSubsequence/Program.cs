using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLongestCommonSubsequence lcs = new MyLongestCommonSubsequence("ABCDGH", "AEDFHR");
            Console.WriteLine(lcs.Value);
            MyLongestCommonSubsequence lcs2 = new MyLongestCommonSubsequence("AGGTAB", "GXTXAYB");
            Console.WriteLine(lcs2.Value);
            Console.ReadKey();
        }

        class MyLongestCommonSubsequence
        {
            private readonly string _firstString;
            private readonly string _secondString;

            public int Value
            {
                get { return Compute(); }
            }

            public MyLongestCommonSubsequence(string firstString, string secondString)
            {
                _firstString = firstString;
                _secondString = secondString;
            }

            private int Compute()
            {
                var table = new int[_firstString.Length + 1, _secondString.Length + 1];
                for (var i = 0; i <= _firstString.Length; i++)
                {
                    table[i, 0] = 0;
                }
                for (var i = 0; i <= _secondString.Length; i++)
                {
                    table[0, i] = 0;
                }
                for (var i = 1; i <= _firstString.Length; i++)
                {
                    for (var j = 1; j <= _secondString.Length; j++)
                    {
                        if (_firstString[i - 1] == _secondString[j - 1])
                        {
                            table[i, j] = new[] {table[i, j - 1] + 1, table[i - 1, j]}.Max(value => value);
                        }
                        else
                        {
                            table[i, j] = new[] { table[i, j - 1], table[i - 1, j] }.Max(value => value);
                        }
                    }
                }
                return table[_firstString.Length, _secondString.Length];
            }
        }
    }
}
