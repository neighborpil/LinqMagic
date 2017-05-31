using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ex2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Enumerable.Range(1, 1000000).ToArray();

            WriteTotalMemory("배열확보전");
            WriteLine($"배열의 요소 수:{numbers.Length}\n");

#if DEBUG
            ReadKey();
#endif

        }

        static void WriteTotalMemory(string header)
        {
            var totalMemory = GC.GetTotalMemory(true) / 1024.0 / 1024.0; //byte >> kb >> Mb
            WriteLine($"{header}:{totalMemory:0.0 MB}");
        }
    }
}
