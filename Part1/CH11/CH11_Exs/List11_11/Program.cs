using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace List11_11
{
    /// <summary>
    /// 지연실행하지 않는 LINQ 데이타소스
    /// 이 예는 생성자의 인수에 주어진 갯수만큼 짝수를
    /// 생성하여 보유
    /// Numbers 프로퍼티가 링큐의 데이터소스가 된다
    /// </summary>
    public class EvenNumbers
    {
        private List<int> _evenNumbers = new List<int>();

        public EvenNumbers(int count)
        {
            for (int n = 0; n <= count; n++)
                _evenNumbers.Add(n * 2);
        }

        public IEnumerable<int> Numbers
        {
            get
            {
                return new System.Collections.ObjectModel.ReadOnlyCollection<int>(_evenNumbers);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var en = new EvenNumbers(5);
            foreach (var n in en.Numbers)
                WriteLine(n);

            //출력
            //2
            //4
            //6
            //8
            //10

#if DEBUG
            ReadKey();
#endif
        }
    }
}
