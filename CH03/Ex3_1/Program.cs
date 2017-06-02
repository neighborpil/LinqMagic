using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ex3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = { "データ 一番目", " 二番目", "\"三\"番目", "四番目", "碁盤目" };
            WriteStrings(strings, "LINQ");
            WriteString_oldStyle(strings, "OldStyle");

#if DEBUG
            ReadKey();
#endif
        }

        //コレクション内のすべての文字列を表示するメソッド
        private static void WriteStrings(IEnumerable<string> strings, string header)
        {
            IEnumerable<string> quoted = strings.Select(s => $"\"{s}\"");
            string connected = string.Join(",", quoted);

            WriteLine($"{header} : {connected}");
        }

        //コレクション内のすべての文字列を表示するメソッド（従来の書き方）
        private static void WriteString_oldStyle(IEnumerable<string> strings, string header)
        {
            List<string> quoted = new List<string>();
            foreach (var s in strings)
                quoted.Add($"\"{s}\"");
            string connected = string.Join(",", quoted);

            Console.WriteLine("{0} : {1}", header, connected);
        }
    }
}
