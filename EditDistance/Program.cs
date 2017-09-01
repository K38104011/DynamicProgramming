using System;
using System.Linq;

namespace EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            MyEditDistance ed = new MyEditDistance("CART", "MARCH");
            Console.WriteLine(ed.Value);
            MyEditDistance ed2 = new MyEditDistance("CART", "MARCH");
            Console.WriteLine(ed2.Value2);
            Console.ReadKey();
        }

        class MyEditDistance
        {
            private readonly string _firstString;
            private readonly string _secondString;

            public int Value
            {
                get
                {
                    return Compute(_firstString.Length, _secondString.Length);
                }
            }

            public int Value2
            {
                get { return Compute2(_firstString.Length, _secondString.Length); }
            }

            public MyEditDistance(string firstString, string secondString)
            {
                _firstString = firstString;
                _secondString = secondString;
            }

            private int Compute(int firstStringLength, int secondStringLength)
            {
                if (firstStringLength == 0)
                {
                    return secondStringLength;
                }
                if (secondStringLength == 0)
                {
                    return firstStringLength;
                }
                if (_firstString[firstStringLength - 1] == _secondString[secondStringLength - 1])
                {
                    return Compute(firstStringLength - 1, secondStringLength - 1);
                }
                return 1 + new[]
                {
                    Compute(firstStringLength - 1, secondStringLength - 1),
                    Compute(firstStringLength, secondStringLength - 1),
                    Compute(firstStringLength - 1, secondStringLength)
                }.Min(value => value);
            }

            private int Compute2(int firstStringLength, int secondStringLength)
            {
                var table = new int[firstStringLength + 1, secondStringLength + 1];
                table[0, 0] = 0;
                for (var i = 1; i <= firstStringLength; i++)
                {
                    table[i, 0] = table[i - 1, 0] + 1;
                }
                for (var i = 1; i <= secondStringLength; i++)
                {
                    table[0, i] = table[0, i - 1] + 1;
                }
                for (var i = 1; i <= firstStringLength; i++)
                {
                    for (var j = 1; j <= secondStringLength; j++)
                    {
                        if (_firstString[i - 1] == _secondString[j - 1])
                        {
                            table[i, j] = table[i - 1, j - 1];
                        }
                        else
                        {
                            table[i, j] = 1 + new int[]
                            {
                                table[i, j - 1],        // delete
                                table[i - 1, j],        // insert
                                table[i - 1, j - 1]     // replace
                            }.Min(value => value);
                        }
                    }
                }
                return table[firstStringLength, secondStringLength];
            }
        }
    }
}
