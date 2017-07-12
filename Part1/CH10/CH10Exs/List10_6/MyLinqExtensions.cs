using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace List10_6
{
    /// <summary>
    /// 확장 메소드를 위한 public static 클래스
    /// </summary>
    public static class MyLinqExtensions
    {
        //10.2 LINQ를 사용하는 링큐 확장 메서드
        public static IEnumerable<T> LessThan1<T>(this IEnumerable<T> numbers, T threshold) where T : IComparable
        {
            return numbers.Where(n => n.CompareTo(threshold) < 0);
        }

        //10.3 foreach를 사용하는 LINQ확장 메소드(예1 - 실패)
        public static IEnumerable<T> LessThan2<T>(this IEnumerable<T> numbers, T threshold) where T : IComparable
        {
            List<T> result = new List<T>(); // toList쓰면 메모리에 계산식이 아니라 값이 저장된다
            foreach (var n in numbers)
            {
                if(n.CompareTo(threshold) < 0)
                    result.Add(n);
            }
            return result;
        }

        //10.3 : foreach를 사용하는 LINQ확장 메서드(예2 - 성고)
        public static IEnumerable<T> LessThan3<T>(this IEnumerable<T> numbers, T threshold) where T : IComparable
        {
            foreach (var n in numbers)
            {
                if (n.CompareTo(threshold) < 0)
                    yield return n;
            }
        }


        //10.4 람다식을 두번째 인수로 사용하는 링큐 확장메소드
        //주어진 조건을 만족하는 경우에만, 수치를 문자열로하고 따옴표"로 감싼다
        public static IEnumerable<string> ToQuotedString<TSource>(this IEnumerable<TSource> numbers, 
            Func<TSource, bool> predicate) where TSource : IFormattable
        {
            foreach (var n in numbers)
            {
                bool match = predicate(n);
                if (match)
                    yield return $"\"{n.ToString()}\"";
            }
        }

        //주의! 실제로는 람다식이 불필요한 확장메소드도 준비해둘 필요가 있다
        public static IEnumerable<string>  ToQuotedString<TSource>(this IEnumerable<TSource> numbers) where TSource : IFormattable
        {
            foreach (var n in numbers)
            {
                yield return $"\"{n.ToString()}\"";

            }
        }
    }
}
