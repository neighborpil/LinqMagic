using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;
namespace Ex3_6
{
    public static class StringExpressions
    {
        //拡張メソッド
        public static IEnumerable<string> MyWhere(this IEnumerable<string> wordList, IEnumerable<string> kewords)
        {
            IEnumerable<string> results = wordList;
            foreach (var k in kewords)
            {
                if (k.StartsWith("!"))
                {
                    var word = k.Substring(1);
                    var r = new Regex(word);
                    WriteLine($"new Regex(\"{word}\")");
                    results = results.Where(s => !r.IsMatch(s));
                }
                else
                {
                    var r = new Regex(k);
                    WriteLine($"new Regex(\"{k}\")");
                    results = results.Where(s => r.IsMatch(s));
                }
            }

            return results;
        }
    }

    class Program
    {
        //コレクション内のすべての文字列を表示するメソッド
        private static void WriteStrings(IEnumerable<string> strings, string header)
        {
            IEnumerable<string> quoted = strings.Select(s => $"\"{s}\"");
            string connected = string.Join(",", quoted);
            WriteLine($"{header} : {connected}");
        }

        //「LINQ-その1」で使う条件判定メソッド
        private static bool IsAllMatch(string s, IEnumerable<string> keywords)
        {
            foreach (var k in keywords)
            {
                if (k.StartsWith("!"))
                {
                    var word = k.Substring(1);
                    var r = new Regex(word);
                    WriteLine($"new Regex(\"{word}\")");
                    if (r.IsMatch(s)) //否定条件なので、マッチしたらfalse
                        return false;
                }
                else{
                    var r = new Regex(k);
                    WriteLine($"new Regex(\"{k}\")");
                    if (!r.IsMatch(s))
                        return false;
                }
            }
            return true;
        }

        //「3.6:文字列コレクションで複雑な検索をする」
        static void Main(string[] args)
        {
            //冒頭に using System.Text.RegularExpressions;が必要

            //サンプルデータ(文字列の配列)
            string[] sampleData = {"ぶた", "こぶた", "ぶたまん", "ねぶたまつり",
                "ねぷたまつり", "きつね", "ねこ" };

            //検索語
            string[] keywords = { "ぶた", "!まつり" };

            //LINQ-その1 : ラムダ式の中に判定メソッドを置いてみる
            {
                //検索する
                var results = sampleData.Where(s => IsAllMatch(s, keywords));
                WriteStrings(results, "LINQ-その1");
                //出力
                //new Regex("ぶた")
                //new Regex("まつり")
                //new Regex("ぶた")
                //new Regex("まつり")
                //new Regex("ぶた")
                //new Regex("まつり")
                //new Regex("ぶた")
                //new Regex("まつり")
                //new Regex("ぶた")
                //new Regex("ぶた")
                //new Regex("ぶた")
                //LINQ - その1 : "ぶた","こぶた","ぶたまん"
            }

            //LINQ-その2 : 拡張メソッドを作る
            {
                //検索する
                var results = sampleData.MyWhere(keywords);
                WriteStrings(results, "LINQ-その2");
                //出力
                //new Regex("ぶた")
                //new Regex("まつり")
                //LINQ - その2 : "ぶた","こぶた","ぶたまん"
            }

            //LINQ-その3 : LINQ‐その2は,さらにチェーンできる
            {
                var results = sampleData.MyWhere(keywords).Where(s => s != "ぶた");
                WriteStrings(results, "LINQ-その3");
                //出力
                //new Regex("ぶた")
                //new Regex("まつり")
                //LINQ - その3 : "こぶた","ぶたまん"
            }

#if DEBUG
            ReadKey();
#endif
        }
    }
}
