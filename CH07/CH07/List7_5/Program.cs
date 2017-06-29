using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace List7_5
{
    public class Sample
    {
        public string Kind { get; set; }
        public int Value { get; set; }
    }

    class Program
    {
        static Sample CreateFromCsvLine(string line)
        {
            WriteLine($"[1] Select : {line}");

            //カンマで分解する
            string[] items = line.Split(',');

            // Sampleオブジェクトを作って返す
            return new Sample()
            {
                Kind = items[0].Trim(),
                Value = int.Parse(items[1].Trim())
            };
        }

        static bool IsKindA(Sample s)
        {
            bool isKindA = s.Kind == "A";
            WriteLine($"[2] Where : {s.Kind}, {s.Value}, ({isKindA})");
            return isKindA;
        }

        //7.2 : ToListメソッドのメリット
        static void Main(string[] args)
        {
            //Sample.csv ファイルから1行ずつ最後まで読み込む
            IEnumerable<string> lines = File.ReadLines(@".\Sample.csv");
            WriteLine("ReadLine End");

            //CSVファイルの各行からSampleオブジェクトを作る
            // ここでいったん「実体化」する
            List<Sample> samples = lines.Select(line => CreateFromCsvLine(line)).ToList(); //[1] Select : ...
            WriteLine("Select完了");

            // Kindが「A」のデータだけを抜き出す
            IEnumerable<Sample> selectedA = samples.Where(s => IsKindA(s)); //[2] Where : ...
            WriteLine("Where 完了");

            //Valueを合計する
            int sumA = selectedA.SumValues(); // [3] Sum : ..
            WriteLine("Sum 完了");

            WriteLine($"Aだけの合計は{sumA}");

            // 続けて、KindがBのデータだけいをぬきだして合計する
            WriteLine();
            WriteLine("残りのデータも合計する");

            // Kindが「A」ではないデータだけを抜き出す。
            IEnumerable<Sample> selectedB = samples.Where(s => !IsKindA(s));
            WriteLine("Where 完了");

            //Valueを合計する
            int sumB = selectedB.SumValues();
            WriteLine("Sum End");

            WriteLine($"Bだけいの合計は{sumB}");

#if DEBUG
            ReadKey();
#endif 
        }
    }
}
