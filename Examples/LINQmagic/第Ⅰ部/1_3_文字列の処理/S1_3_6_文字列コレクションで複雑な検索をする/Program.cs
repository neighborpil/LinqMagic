using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;  // C# 6 の機能


public static class StringExtensions
{
  // 拡張メソッド
  public static IEnumerable<string> MyWhere(this IEnumerable<string> wordList, IEnumerable<string> keywords)
  {
    IEnumerable<string> results = wordList;
    foreach (var k in keywords)
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
  // コレクション内の全ての文字列を表示するメソッド
  private static void WriteStrings(IEnumerable<string> strings, string header)
  {
    IEnumerable<string> quoted = strings.Select(s => $"\"{s}\"");
    string connected = string.Join(", ", quoted);
    WriteLine($"{header}: {connected}");
  }

  // 「LINQその1」で使う条件判定メソッド
  private static bool IsAllMatch(string s, IEnumerable<string> keywords)
  {
    foreach (var k in keywords)
    {
      if (k.StartsWith("!"))
      {
        var word = k.Substring(1);
        var r = new Regex(word);
        WriteLine($"new Regex(\"{word}\")");
        if (r.IsMatch(s))  // 否定条件なので、マッチしたらfalse
          return false;
      }
      else
      {
        var r = new Regex(k);
        WriteLine($"new Regex(\"{k}\")");
        if (!r.IsMatch(s))
          return false;
      }
    }
    return true;
  }

  // 3-6. 文字列コレクションで複雑な検索をする
  static void Main(string[] args)
  {
    // 冒頭に using System.Text.RegularExpressions; が必要

    // サンプルデータ（文字列の配列）
    string[] sampleData = { "ぶた", "こぶた", "ぶたまん",
                            "ねぶたまつり", "ねぷたまつり",
                            "きつね", "ねこ", };

    // 検索語
    string[] keywords = { "ぶた", "!まつり", };



    // こんな風にLINQで書きたいけれど…
    // var results = sampleData.Where(s => foo(s, keywords));
    // 出力: "ぶた", "こぶた", "ぶたまん"



    // LINQその1：ラムダ式の中に判定メソッドを置いてみる
    // → これではラムダ式が呼び出されるたびに、
    //    IsAllMatchメソッド内で正規表現オブジェクトが生成される
    // ※パフォーマンスの問題が出なければ、これでも構わない
    {
      // 検索する
      var results = sampleData.Where(s => IsAllMatch(s, keywords));
      WriteStrings(results, "LINQその1");
      // 出力：
      // new Regex("ぶた")
      // new Regex("まつり")
      // new Regex("ぶた")
      // new Regex("まつり")
      // new Regex("ぶた")
      // new Regex("まつり")
      // new Regex("ぶた")
      // new Regex("まつり")
      // new Regex("ぶた")
      // new Regex("ぶた")
      // new Regex("ぶた")
      // LINQその1: "ぶた", "こぶた", "ぶたまん"
    }

    // LINQその2：拡張メソッドを作る
    {
      // 検索する
      var results = sampleData.MyWhere(keywords);
      WriteStrings(results, "LINQその2");
      // 出力：
      // new Regex("ぶた")
      // new Regex("まつり")
      // LINQその2: "ぶた", "こぶた", "ぶたまん"
    }
    // LINQその3：LINQその2は、さらにチェーンできる
    {
      var results = sampleData.MyWhere(keywords).Where(s => s != "ぶた");
      WriteStrings(results, "LINQその3");
      // 出力：
      // new Regex("ぶた")
      // new Regex("まつり")
      // LINQその3: "こぶた", "ぶたまん"
    }



#if DEBUG
    ReadKey();
#endif
  }

}
