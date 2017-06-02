using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ex2_19
{
    class Program
    {
        static void Main(string[] args)
        {
            //Old Style
            {
                //要素に null も持つ Nullable<int> 型の配列
                int?[] numbers = { 1, 2, null, 3, };

                int min = int.MaxValue;
                int max = int.MinValue;
                bool areAllNull = true;
                foreach (int? n in numbers)
                {
                    if (n == null)
                        continue;

                    areAllNull = false;

                    if (n < min)
                        min = n.Value;
                    if (n > max)
                        max = n.Value;
                }

                if (!areAllNull)
                    WriteLine($"最小値、最大値（従来の書き方）：{min}, {max}");
                //「出力」
                //最小値、最大値（従来の書き方）：1, 3
                else
                    WriteLine("コレクションの内容が全てnullでした");
            }

            //LINQ1
            {
                //要素にnullを持つNullable<int>型の配列
                int?[] numbers = { 1, 2, null, 3, };
                var min = numbers.Where(n => n != null).Min();
                var max = numbers.Where(n => n != null).Max();

                if (min != null && max != null)
                    WriteLine($"最小値、最大値(LINQ - その１):{min}, {max}");
                //出力
                //最小値、最大値(LINQ-その１): 1, 3
                else
                    WriteLine("コレクションの内容は全てnullでした");
            }

            //LINQ2
            {
                //要素にnullを持つNullable<int>型の配列
                int?[] numbers = { 1, 2, null, 3, };
                var min = numbers.Min();
                var max = numbers.Max();

                if (min != null && max != null)
                    WriteLine($"最小値、最大値(LINQ - その2):{min}, {max}");
                //出力
                //最小値、最大値(LINQ-その１): 1, 3
                else
                    WriteLine("コレクションの内容は全てnullでした");

                //追加
                WriteLine("最小値、最大値(LINQ-その２) : "
                    + $"{min?.ToString() ?? "(null)"}," //??연산자는 값을 반한화는 메소드이다
                    + $"{max?.ToString() ?? "(null)"}"); //a ?? b는 a가 null이라면 b를 반환하라는 의미이다
            }

            

#if DEBUG
            ReadKey();
#endif
        }
    }
}
