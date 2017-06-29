using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List9_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // LINQ　拡張メソッド(5.6節のコードを改変
            int sum = File.ReadLines(@"\sample.csv").
                Select(line => CreateFromCSVLine(line))
                .Where(sample => IsKindA(sample))
                .Sum(s => s.Value);

            //クエリ式
            int sum = (
                from line in File.ReadLines(@"\sample.csv")
                select CreateFromCSVLine(line) into sample
                where IsKindA(sample)
                select sample)
                .Sum(s => s.Value);

        }

        private static bool IsKindA(object sample)
        {
            throw new NotImplementedException();
        }

        private static object CreateFromCSVLine(string line)
        {
            throw new NotImplementedException();
        }
    }
}
