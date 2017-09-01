using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequence_LIS_
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 10, 22, 9, 33, 21, 50, 41, 60 };
            var lis = new LongestIncreasingSubsequence(new List<int>(numbers));
            Console.WriteLine(lis.Length);
            Console.ReadKey();
        }
    }

    class LongestIncreasingSubsequence
    {
        private readonly IList<int> _numbers;
        private readonly int[] _longest;

        public int Length
        {
            get { return Compute(); }
        }

        public LongestIncreasingSubsequence(IList<int> numbers)
        {
            _numbers = numbers;
            _longest = new int[_numbers.Count];
        }

        private int Compute()
        {
            _longest[0] = 1;
            for (var i = 1; i < _numbers.Count; i++)
            {
                var max = -1;
                _longest[i] = 1;
                for (var j = 0; j < i; j++)
                {
                    if (_numbers[j] < _numbers[i] && _longest[j] > max)
                    {
                        max = _longest[j];
                        _longest[i] = _longest[j] + 1;
                    }
                }
            }
            return _longest[_numbers.Count - 1];
        }

    }
}
