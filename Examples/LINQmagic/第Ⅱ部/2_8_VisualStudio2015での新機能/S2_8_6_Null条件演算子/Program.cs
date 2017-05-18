using System.Collections.Generic;
using System.Linq;
using static System.Console;

class Program
{
  static IList<string> SampleMethod(int index)
  {
    if (index < 1)
      return null;
    return new List<string> { "abc", "ABC" };
  }

  static void Main(string[] args)
  {
    // リストの最初の文字列を取得する
    // 従来の書き方
    string result1 = null;
    IList<string> s1 = SampleMethod(0);
    if (s1 != null)
      result1 = s1.First();

    // Null条件演算子を使えば1行で書ける
    string result2 = SampleMethod(0)?.First();
    string result3 = SampleMethod(1)?.First();
    WriteLine($"result2は{result2 ?? "null"}");
    // 出力：result2はnull
    WriteLine($"result3は{result3 ?? "null"}");
    // 出力：result3はabc

    // Null条件演算子はインデクサーの前にも書ける
    string result4 = SampleMethod(0)?[0];
    WriteLine($"result4は{result4 ?? "null"}");
    // 出力：result4はnull

#if DEBUG
    ReadKey();
#endif
  }
}
