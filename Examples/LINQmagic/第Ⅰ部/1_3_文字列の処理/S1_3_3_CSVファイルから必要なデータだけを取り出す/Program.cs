using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;  // C# 6 の機能

class Program
{
  // コレクション内の全ての文字列を表示するメソッド
  private static void WriteStrings(IEnumerable<string> strings, string header)
  {
    IEnumerable<string> quoted = strings.Select(s => $"\"{s}\"");
    string connected = string.Join(", ", quoted);
    WriteLine($"{header}: {connected}");
  }


  // 3-3. カンマ区切りの文字列から必要なデータだけを取り出す
  static void Main(string[] args)
  {
    string s = "1番目,2番目,3番目,4番目,5番目";

    // 従来の書き方
    {
      // カンマで分解する
      string[] splitted = s.Split(',');

      // 空のコレクションを用意する
      List<string> selected = new List<string>();

      // 必要なデータを選び出してコレクションに追加する
      for (int n = 0; n < splitted.Length; n++)
      {
        string w = splitted[n];
        if (n % 2 == 0)
          selected.Add(w);
      }
      WriteStrings(selected, "奇数番目だけを取り出す（従来の書き方）");
      // 出力：
      // 奇数番目だけを取り出す（従来の書き方）: "1番目", "3番目", "5番目"
    }

    // LINQ
    {
      var selected
        = s.Split(',')                   // 分解し、
           .Where((w, n) => n % 2 == 0); // 奇数番目を取り出す
      WriteStrings(selected, "奇数番目だけを取り出す（LINQ）");
      // 出力：
      // 奇数番目だけを取り出す（LINQ）: "1番目", "3番目", "5番目"
    }


#if DEBUG
    ReadKey();
#endif
  }
}
