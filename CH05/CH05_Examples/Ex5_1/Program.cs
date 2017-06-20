using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ex5_1
{
    public class Sample
    {
        public string Kind { get; set; }
        public int Value { get; set; }
    }

    public static class SampleExtensions
    {
        public static int SumValues(this IEnumerable<Sample> samples)
        {
            WriteLine("※SumValues開始");

            int sum = 0;
            foreach (var s in samples)
            {
                sum += s.Value;
                WriteLine($"[3] Sum : {s.Kind}, {s.Value}, <sum={sum}>");
            }
            WriteLine("※SumValues終了");

            return sum;
        }
    }

    class Program
    {
        static Sample CreateFromCsvLine(string line)
        {
            WriteLine();
            WriteLine($"[1] Select : {line}");

            // カンマで分解する
            string[] items = line.Split(',');

            // Sampleオブジェクトを作って返す
            return new Sample()
            {
                Kind = items[0].Trim(),
                Value = int.Parse(items[1].Trim())
            };
        }

        static void Main(string[] args)
        {
        }
    }
}
