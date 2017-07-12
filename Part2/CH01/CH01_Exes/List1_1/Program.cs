using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringExtension;

namespace List1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "1 2 3 4 5";

            //확장 메소드의 일반적 호출 방법
            string s2 = s1.Reverse();
            Console.WriteLine(s2);
            //출력
            // 5 4 3 2 1

            string s3 = StringExtension.MyExtensions.Reverse(s1);
            Console.WriteLine(s3);

            string s4 = "ABC".Reverse().ToLower();
            Console.WriteLine(s4);

            Console.WriteLine("12345".Head(3));
            //출력
            //123
#if DEBUG
            Console.ReadKey();
#endif

        }
    }
}
