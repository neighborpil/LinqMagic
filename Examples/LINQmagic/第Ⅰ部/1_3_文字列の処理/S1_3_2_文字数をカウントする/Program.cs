using System;
using System.Linq;
using static System.Console;  // C# 6 の機能

class Program
{
  // 3-2. 文字数をカウントする
  static void Main(string[] args)
  {
    string s = "LINQ Magic";

    // 従来の書き方
    {
      int count = 0;
      foreach (var c in s.ToCharArray())
        if (char.IsUpper(c))
          count++;
      WriteLine($"大文字の数（従来の書き方）: {count}");
      // 出力：
      // 大文字の数（従来の書き方）: 5
    }

    // LINQ（その1）
    {
      int count = s.Where(c => char.IsUpper(c)).Count();
      // stringはIEnumerable<char>を実装しているので、
      // s.ToCharArray().… とは書かなくてよい

      WriteLine($"大文字の数（LINQ-その1）: {count}");
      // 出力：
      // 大文字の数（LINQ-その1）: 5
    }

    // LINQ（その2）
    {
      // Count拡張メソッドは、ラムダ式を引数に与えられる
      int count = s.Count(c => char.IsUpper(c));

      WriteLine($"大文字の数（LINQ-その2）: {count}");
      // 出力：
      // 大文字の数（LINQ-その2）: 5
    }

#if DEBUG
    ReadKey();
#endif
  }
}
