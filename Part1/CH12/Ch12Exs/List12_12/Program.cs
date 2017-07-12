using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
[Making IQueryable]
*/
namespace List12_12
{
    class Program
    {
        static void Main(string[] args)
        {
            IQueryable<Sample> q = SampleQueryProvider.CreateQuery(@".\sample.csv");

            Console.WriteLine("전부 획득 : foreach 시작");

            foreach (var s in q)
                Console.WriteLine($"☆ Kind={s.Kind}, Value={s.Value}");

            Console.WriteLine();


            IEnumerable<Sample> q1 = q.Where(s => s.Kind == "A");
            Console.WriteLine("A만");
            foreach (var s in q1)
            {
                Console.WriteLine($"☆ Kind={s.Kind}, Value={s.Value}");

            }

            IEnumerable<Sample> e1 = q.Where(s => s.Kind == "A")
                                     .AsEnumerable() // 이거 이후 IEnumerable 체인
                                     .Where(s => s.Value == 100);
            Console.WriteLine("A이고 Value=100인 것");
            foreach (var s in e1)
            {
                Console.WriteLine($"☆ Kind={s.Kind}, Value={s.Value}");

            }

            Console.WriteLine();
            IEnumerable<Sample> e2 = q.Where(s => s.Kind == "B")
                                      .AsEnumerable()
                                      .Take(1); //콜렉션 처음에서 한개 획득
            Console.WriteLine("B : 단, 최초의 1개만 foreach 시작");
            foreach (var s in e2)
            {
                Console.WriteLine($"☆ Kind={s.Kind}, Value={s.Value}");

            }

#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
