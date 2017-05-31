using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ex2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 10);

            WriteLine($"sum : {numbers.Sum()}");
            WriteLine($"avg : {numbers.Average()}");
            WriteLine($"min : {numbers.Min()}");
            WriteLine($"max : {numbers.Max()}");

#if DEBUG
            ReadKey();
#endif
        }

    }
}
