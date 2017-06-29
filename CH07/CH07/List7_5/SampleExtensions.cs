using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace List7_5
{
    public static class SampleExtensions
    {
        public static int SumValues(this IEnumerable<Sample> samples)
        {
            WriteLine("start SumValues");

            int sum = 0;
            foreach (var s in samples)
            {
                sum += s.Value;
                WriteLine($"[3] Sum : {s.Kind}, {s.Value} <sum={sum}>");
                WriteLine("end SumValue");
            }
            return sum;
        }
    }
}
