using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace List9_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Enumerable.Range(1, 10).ToList();
            //LINQ 拡張メソッド
            var results = numbers.Where(n => n % 2 == 0);
            WriteNumbers(results, "偶数だけ(LINQ)");

            WriteLine();

            //クエリ式
            var resultsQ = from n in numbers
                          where n % 2 == 0
                          select n;
            WriteNumbers(resultsQ, "(クエリ式)");

        }

        private static void WriteNumbers(IEnumerable<int> results, string str)
        {
            Write($"results{str} : ");
            foreach (var item in results)
            {
                Write($" {item}");
            }

#if DEBUG
            ReadKey();
#endif
        }
    }
}
