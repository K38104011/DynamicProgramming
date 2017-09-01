using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memoization
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = 40;
            MyFibonacci f = new MyFibonacci(number);
            var watch = new Stopwatch();

            watch.Start();
            var r1 = f.Value;
            Console.WriteLine(r1);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            watch.Reset();
            watch.Start();
            var r2 = Fib(number);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            Console.WriteLine(r1 == r2);

            Console.ReadKey();
        }

        private static int Fib(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return Fib(n - 1) + Fib(n - 2);
        }
    }

    public class MyFibonacci
    {
        public int Number { get; }

        public int Value
        {
            get { return GetValue(Number); }
        }

        private readonly Dictionary<int, int> _dict;

        public MyFibonacci(int number)
        {
            Number = number;
            _dict = new Dictionary<int, int>
            {
                { 0, 0 },
                { 1, 1 },
            };
        }

        private int GetValue(int number)
        {
            return Compute(number);
        }

        private int Compute(int number)
        {
            if (_dict.ContainsKey(number))
            {
                return _dict[number];
            }
            return _dict[number] = Compute(number - 1) + Compute(number - 2);
        }
    }
}
