using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

  // 3-4. 文字列コレクションを検索する
  static void Main(string[] args)
  {
    // 冒頭に using System.Text.RegularExpressions; が必要

    // サンプルデータ（文字列の配列）
    string[] sampleData = { "ぶた", "こぶた", "ぶたまん",
                              "ねぶたまつり", "ねぷたまつり",
                              "きつね", "ねこ", };

    // 【1】 条件が一つだけ
    // LIKE '%ぶた%'

    // 正規表現オブジェクト
    var regex = new Regex("ぶた", RegexOptions.Compiled);
    // ※ この検索だけならば、StringクラスのContainsメソッドでも可能

    // 従来の書き方
    {
      // 検索する
      List<string> results = new List<string>();
      foreach (var s in sampleData)
      {
        if (regex.IsMatch(s))
          results.Add(s);
      }
      WriteStrings(results, "従来の書き方");
      // 出力：
      // 従来の書き方: "ぶた", "こぶた", "ぶたまん", "ねぶたまつり"
    }

    // LINQ
    {
      // 検索する
      var results = sampleData.Where(s => regex.IsMatch(s));
      WriteStrings(results, "LINQ");
      // 出力：
      // LINQ: "ぶた", "こぶた", "ぶたまん", "ねぶたまつり"
    }


    // 【2】AND条件（条件の数は不定）

    // 正規表現オブジェクトのコレクション
    var regexList = new List<Regex>()
      {
        new Regex("ぶた", RegexOptions.Compiled),
        new Regex("たま", RegexOptions.Compiled),
      };

    // 従来の書き方1
    {
      // 検索する
      List<string> results = new List<string>();
      foreach (var s in sampleData)
      {
        bool allMatch = true;
        foreach (var r in regexList)
        {
          if (!r.IsMatch(s))
          {
            allMatch = false;
            break;
          }
        }
        if (allMatch)
          results.Add(s);
      }
      WriteStrings(results, "AND検索 - 従来の書き方1");
      // 出力：
      // AND検索 - 従来の書き方1: "ぶたまん", "ねぶたまつり"
    }

    // 従来の書き方2
    // 中間結果用に大量のコレクションを作成するので、
    // 頻繁にガベージコレクションが働くことになる
    {
      // 検索する
      IEnumerable<string> results = sampleData;
      foreach (var r in regexList)
      {
        List<string> work = new List<string>();
        foreach (var s in results)
          if (r.IsMatch(s))
            work.Add(s);
        results = work;
      }
      WriteStrings(results, "AND検索 - 従来の書き方2");
      // 出力：
      // AND検索 - 従来の書き方2: "ぶたまん", "ねぶたまつり"
    }


    // LINQ
    // LINQマジックにより、中間結果用のコレクションは実体化されない
    {
      // 検索する
      IEnumerable<string> work = sampleData;
      foreach (var r in regexList)
        work = work.Where(s => r.IsMatch(s));
      WriteStrings(work, "AND検索 - LINQ");
      // 出力：
      // AND検索 - LINQ: "ぶたまん", "ねぶたまつり"
    }

    // LINQ
    // foreachループ内の条件式が一定なら、All拡張メソッドで書ける
    // ただし、難易度は高い
    {
      // 検索する
      var result
        = sampleData.Where(s => regexList.All(r => r.IsMatch(s)));
      WriteStrings(result, "AND検索 - LINQ（難易度高）");
      // 出力：
      // AND検索 - LINQ（難易度高）: "ぶたまん", "ねぶたまつり"
    }



    // 【3】OR検索


    // 従来の書き方
    {
      // 検索する
      List<string> results = new List<string>();
      foreach (var s in sampleData)
      {
        foreach (var r in regexList)
        {
          if (r.IsMatch(s))
          {
            results.Add(s);
            break;
          }
        }
      }
      WriteStrings(results, "OR検索 - 従来の書き方");
      // 出力：
      // OR検索 - 従来の書き方: "ぶた", "こぶた", "ぶたまん", "ねぶたまつり", "ねぷたまつり"
    }

    // LINQその1
    {
      // 検索する
      IEnumerable<string> work = new List<string>();
      foreach (var r in regexList)
        work = work.Union(sampleData.Where(s => r.IsMatch(s)));
      WriteStrings(work, "OR検索 - LINQその1");
      // 出力：
      // OR検索 - LINQその1: "ぶた", "こぶた", "ぶたまん", "ねぶたまつり", "ねぷたまつり"
      // ※偶然、順序が変わらなかった。Unionする方式では、順序は保証されない
    }

    // LINQ
    // foreachループ内の条件式が一定なら、Any拡張メソッドで書ける
    // ただし、難易度は高い
    {
      // 検索する
      var result
        = sampleData.Where(s => regexList.Any(r => r.IsMatch(s)));
      WriteStrings(result, "OR検索 - LINQ（難易度高）");
      // 出力：
      // OR検索 - LINQ（難易度高）: "ぶた", "こぶた", "ぶたまん", "ねぶたまつり", "ねぷたまつり"
    }





    // sampleDataを壊していないことの確認
    WriteStrings(sampleData, "sampleData");

#if DEBUG
    ReadKey();
#endif
  }
}
