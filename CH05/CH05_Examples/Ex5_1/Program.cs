using System;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// LINQ의 Sum메소드의 내부 동작 메소드
        /// </summary>
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
                Value = int.Parse(items[1].Trim()),
            };
        }

        /// <summary>
        /// 데이터의 종류가 A인지 판정
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static bool IsKindA(Sample s)
        {
            bool isKindA = s.Kind == "A";
            WriteLine($"[2] Where : {s.Kind}, {s.Value}, ({isKindA})");
            return isKindA;
        }
        static void Main(string[] args)
        {
            //「Sample.cv」　ファイルから一行づつ最後まで読み込む
            IEnumerable<string> lines = File.ReadLines(@".\sample.csv");
            WriteLine("※ReadLine 完了");


            // CSVファイルの各行からSampleオブジェクトを作る
            IEnumerable<Sample> samples = lines.Select(line => CreateFromCsvLine(line)); //->「[1] Select : ...」
            WriteLine("※Select 完了");

            // Kindが「A」のデータだけを抜き出す
            IEnumerable<Sample> selectedA = samples.Where(s => IsKindA(s)); // => 「[2] Where : ...」

            // Valueを合計する
            int sumA = selectedA.SumValues(); // => 「[3] Sum : ...」

            WriteLine($"Aだけの合計は{sumA}");
#if DEBUG
            ReadKey();
#endif
        }
    }
}
