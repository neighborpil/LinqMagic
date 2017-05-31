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

            //종래의 방식
            {
                double ave = 0;
                int count = 0;
                foreach(int n in numbers)
                {
                    if(n % 2 == 0)
                    {
                        count++;
                        ave += (n - ave) / count;
                    }
                }
                WriteTotalMemory("합계전");
                WriteLine($"짝수만의 평균 : {ave}\n");
            }

            //Linq
            {
                //偶数だけを取り出したコレクションを得る
                var evenNumbers = numbers.Where(n => n % 2 == 0);
                WriteTotalMemory("偶数だけ取り出した後"); //

                //平均値を求める
                var ave = evenNumbers.Average();
                WriteTotalMemory("計算後(Linq)");
                WriteLine($"偶数だけの平均値(Linq) : {ave}");
            }

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
