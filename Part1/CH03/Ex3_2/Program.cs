using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ex3_2
{
    class Program
    {
        //文字列をカウントする
        static void Main(string[] args)
        {
            string S = "LINQ Magic";

            //従来の書き方
            {
                int count = 0;
                foreach (var c in S.ToCharArray())
                    if (char.IsUpper(c))
                        count++;
                WriteLine($"大文字の数（従来の書き方）：{count}");
                //出力
                //大文字の数（従来の書き方）:5
            }

            //LINQ-その1
            {
                int count = S.Where(c => char.IsUpper(c)).Count();
                WriteLine($"大文字の数（LINQ-その1）：{count}");
                //出力
                //大文字の数（LINQ-その1）:5
            }

            //LINQ-その2
            {
                int count = S.Count(c => char.IsUpper(c));
                WriteLine($"大文字の数（LINQ-その2）：{count}");
                //出力
                //大文字の数（LINQ-その1）:5 
            }

#if DEBUG
            ReadKey();
#endif
        }
    }
}
