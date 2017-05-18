using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;  // C# 6 の機能

public static class StringExtensions
{
  // 拡張メソッド
  public static string JoinIntoString(this IEnumerable<char> chars)
  {
    return new string(chars.ToArray());
  }
}


class Program
{
  // 3-5. 文字列を反転する
  static void Main(string[] args)
  {
    // 元の文字列
    string original = "あいうえお";
    WriteLine($"元の文字列：{original}");

    // 従来の書き方
    {
      // 文字列を反転させる
      char[] chars = original.ToCharArray();
      Array.Reverse(chars);
      string reverse = new string(chars);

      WriteLine($"反転した文字列（従来の書き方）: {reverse}");
      // 出力：
      // 反転した文字列（従来の書き方）: おえういあ
    }

    // LINQ その1
    {
      // 文字列を反転させる
      string reverse = new string(original.Reverse().ToArray());
      WriteLine($"反転した文字列（LINQ-その1）: {reverse}");
      // 出力：
      // 反転した文字列（LINQ-その1）: おえういあ

      // stringはIEnumerable<char>を実装しているので、
      // original.ToCharArray().Reverse().… とは書かなくてよい
    }

    // 上のコードは、new string()しているところが、LINQらしくない。
    // そこで、拡張メソッドを独自に作り、そこに追い出す。

    // LINQ その2（LINQ拡張メソッドを作る）
    {
      // 文字列を反転させる
      string reverse = original.Reverse().JoinIntoString();
      WriteLine($"反転した文字列（LINQ-その2）: {reverse}");
      // 出力：
      // 反転した文字列（LINQ - その2）: おえういあ
    }

#if DEBUG
    ReadKey();
#endif
  }
}
