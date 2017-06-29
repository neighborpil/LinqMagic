using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace List7_4
{
    class Program
    {
        static void WrtieTotalMemory(string header)
        {
            var totalMemory = GC.GetTotalMemory(true) / 1024.0 / 1024.0;
            WriteLine($"{header} : {totalMemory:0.0 MB}");
        }

        //ToListメソッドのデメリット
        static void Main(string[] args)
        {
            // 1 ~ 100万 (100万個) の整数を持つ配列(役４MB)
            int[] numbers = Enumerable.Range(1, 1000000).ToArray();
            WrtieTotalMemory("配列確保後");
            WriteLine($"配列の要素数 : {numbers.Length}\n");

            // 偶数だけを取り出したコレクションを得る(2MBほど消費する?)
            IEnumerable<int> evenNumbers = numbers.Where(n => n % 2 == 0);
            WrtieTotalMemory("偶数だけ取り出した後");

            // ToListを使う
            List<int> evenNumbersList = evenNumbers.ToList();
            WrtieTotalMemory("ToList後");

            // 平均値を求める
            var ave = evenNumbersList.Average();
            WrtieTotalMemory("計算後(LINQ)");
            WriteLine($"偶数だけの平均値(LINQ) : {ave}");

#if DEBUG
            ReadKey();
#endif
        }
    }
}
