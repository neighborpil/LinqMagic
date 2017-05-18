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

  // コレクション内の全ての文字列を表示するメソッド（従来の書き方）
  private static void WriteStrings_oldstyle(IEnumerable<string> strings,
                                            string header)
  {
    List<string> quoted = new List<string>();
    foreach (var s in strings)
      quoted.Add(string.Format("\"{0}\"", s));
    string connected = string.Join(", ", quoted);

    Console.WriteLine("{0}:{1}", header, connected);
  }


  static void Main(string[] args)
  {
    string[] strings = { "データ 1番目", " 2番目", "\"3\"番目", "4番目", "5番目" };

    WriteStrings(strings, "LINQ");
    WriteStrings_oldstyle(strings, "従来の書き方");

#if DEBUG
    ReadKey();
#endif
  }
}
