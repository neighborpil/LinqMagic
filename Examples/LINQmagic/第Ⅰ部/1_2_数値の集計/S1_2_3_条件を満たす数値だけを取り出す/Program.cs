using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;  // C# 6 の機能

class Program
{
  // コレクション内のすべての整数を表示するメソッド
  private static void WriteNumbers(IEnumerable<int> numbers, string header)
  {
    Write($"{header}:");  // C# 6 の機能 (冒頭に using static System.Console; が必要)
    foreach (var n in numbers)
      Write($" {n}");
    WriteLine();
  }

  // 2-3. 条件を満たす数値だけを取り出す
  static void Main(string[] args)
  {
    // 1～10までの整数を用意する
    IEnumerable<int> numbers = Enumerable.Range(1, 10);
    WriteNumbers(numbers, "元の数値");
    // 出力：
    // 元の数値: 1 2 3 4 5 6 7 8 9 10

    // 最小値／最大値を取り出す
    {
      int min = numbers.Min();
      WriteLine($"LINQのMinメソッド: {min}");
      // 出力：
      // LINQのMinメソッド: 1

      int max = numbers.Max();
      WriteLine($"LINQのMaxメソッド: {max}");
      // 出力：
      // LINQのMaxメソッド: 10
    }

    // 最小値／最大値を取り出す（従来の書き方）
    {
      int min = int.MaxValue;
      int max = int.MinValue;
      foreach (int n in numbers)
      {
        if (n < min)
          min = n;
        if (n > max)
          max = n;
      }
      WriteLine($"最小値（従来の書き方）: {min}");
      // 出力：
      // 最小値（従来の書き方）: 1

      WriteLine($"最大値（従来の書き方）: {max}");
      // 出力：
      // 最大値（従来の書き方）: 10
    }


    // 偶数だけを取り出す（従来の書き方）
    {
      var results = new List<int>();
      foreach (int n in numbers)
        if (n % 2 == 0)
          results.Add(n);
      WriteNumbers(results, "偶数だけ（従来の書き方）");
      // 出力：
      // 偶数だけ（従来の書き方）: 2 4 6 8 10
    }

    // 偶数だけを取り出す（LINQ）
    {
      var results = numbers.Where(n => n % 2 == 0);
      WriteNumbers(results, "偶数だけ（LINQ）");
      // 出力：
      // 偶数だけ（LINQ）: 2 4 6 8 10
    }

    // 偶数だけを取り出す（クエリ式）
    {
      var results = from n in numbers
                     where n % 2 == 0
                     select n;
      WriteNumbers(results, "偶数だけ（クエリ式）");
      // 出力：
      // 偶数だけ（クエリ式）: 2 4 6 8 10
    }


#if DEBUG
    // Visual Studio からデバッグ実行したときに、
    // コンソールがすぐに閉じてしまわないようにする
    Console.ReadKey();
#endif
  }
}

