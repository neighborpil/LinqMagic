using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ex2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 10);

            var results = numbers.Where(n => n % 2 == 0);

            WriteNumbers(numbers, "정수");
            WriteNumbers(results, "짝수");

            var sum = results.Sum();

            WriteLine($"{sum}");


#if DEBUG
            ReadKey();
#endif
        }

        //콜렉션 내 모든 정수를 표시하는 메소드
        private static void WriteNumbers(IEnumerable<int> numbers, string header)
        {
            Write($"{header} : "); //c# 6기능
            foreach (var n in numbers)
                Write($" {n}");
            WriteLine();
        }
    }
}
