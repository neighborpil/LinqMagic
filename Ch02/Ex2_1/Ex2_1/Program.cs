using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ex2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1~10까지 정수 준비(Linq)
            IEnumerable<int> numbers = Enumerable.Range(1, 10);
            WriteNumbers(numbers, "정수가 들어간 콜렉션");

            //1~10까지 출력, 옛날방법
            int[] numbers_oldstyle = new int[10];
            for (int i = 0; i < 10; i++)
                numbers_oldstyle[i] = i + 1;
            WriteNumbers_oldstyle(numbers_oldstyle, "정수가 들어간 콜렉션(옛날방법)");

#if DEBUG
            ReadKey();
#endif

        }

        //콜렉션 내 모든 정수를 표시하는 메소드
        private static void WriteNumbers(IEnumerable<int> numbers, string header)
        {
            Write($"{header} : "); //c# 6기능
            foreach (var n in numbers)
                Write($" {n}");
            WriteLine();
        }

        //콜렉션 내에 모든 정수를 표시, 옛날스타일
        private static void WriteNumbers_oldstyle(IEnumerable<int> numbers, string header)
        {
            Console.Write(header + " : ");
            foreach (var n in numbers)
                Console.Write(" " + n);
            Console.WriteLine();
        }
    }
}
