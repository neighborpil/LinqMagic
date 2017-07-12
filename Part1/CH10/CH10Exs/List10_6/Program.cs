using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace List10_6
{
    class Program
    {
        //콜렉션 내의 모든 요소들을 표시하는 메소드 2.1절 참조
        private static void WriteNumbers<T>(IEnumerable<T> items, string header)
        {
            Write($"{header} : ");
            foreach (var n in items)
                Write($"{n} ");
            WriteLine();
        }

        static void Main(string[] args)
        {
            // 숫자 콜렉션
            IEnumerable<int> numbers = Enumerable.Range(1, 10);
            double[] doubles = { 0.0, 1.1, 2.2, 3.3, 4.4, 5.5 };

            // 표준 링큐확장메소드(Where) 사용
            {
                IEnumerable<int> evens1 = numbers.Where(n => n % 2 == 0);
                IEnumerable<double> evens2 = doubles.Where(n => n < 4.0);
                WriteNumbers(evens1, "Where (int) ");
                WriteNumbers(evens2, "Where (double) ");
            }

            WriteLine();

            //10.2 : linq를 사용한 linq확장 메소드
            {
                IEnumerable<int> evens1 = numbers.LessThan1(4);
                IEnumerable<double> evens2 = doubles.LessThan1(4.0);
                WriteNumbers(evens1, "LessThan1 (int) ");
                WriteNumbers(evens2, "LessThan1 (double) ");
            }

            WriteLine();

            //10.3 foreach를 사용하는 linq확장 메소드(예1 - 실패)
            {
                IEnumerable<int> evens1 = numbers.LessThan2(4);
                IEnumerable<double> evens2 = doubles.LessThan2(4.0);
                WriteNumbers(evens1, "LessThan2 (int) ");
                WriteNumbers(evens2, "LessThan2 (double) ");

                //rufrhksms qkfmrp skdhwlaks
                WriteLine($"evens1의 형은 {evens1.GetType().Name}");
                //출력
                // evens1의 형은 LIst'1
            }

            WriteLine();

            //10.4 foreach를 사용하는 linq확장 메소드(예2 - 성공)
            {
                IEnumerable<int> evens1 = numbers.LessThan3(4);
                IEnumerable<double> evens2 = doubles.LessThan3(4.0);
                WriteNumbers(evens1, "LessThan3 (int) ");
                WriteNumbers(evens2, "LessThan3 (double) ");

                WriteLine($"LessThan3<int> 메소드가 반환하는 형 : {evens1.GetType().Name}");

                //출력
                //LessThan3<int> 메소드가 반환하는 형 : <LessThan3>d__2'1
                //이것은 자동 생성된 클래스
            }

            WriteLine();

            //10.4 : 람다식을 사용하는 LINQ확장 메소드
            {
                IEnumerable<string> result1 = numbers.ToQuotedString(n => n >= 5);
                IEnumerable<string> result2 = doubles.ToQuotedString(d => d < 4.0);
                WriteNumbers(result1, "5이상의 int");
                WriteNumbers(result2, "4이하의 실수");
            }



#if DEBUG
            ReadKey();
#endif
        }
    }
}
