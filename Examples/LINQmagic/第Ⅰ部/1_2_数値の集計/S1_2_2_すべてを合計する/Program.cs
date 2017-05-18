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

  // 2-2.すべてを合計する
  static void Main(string[] args)
  {
    // 1～10までの整数を用意する
    IEnumerable<int> numbers = Enumerable.Range(1, 10);
    WriteNumbers(numbers, "元の数値");
    // 出力：
    // 元の数値: 1 2 3 4 5 6 7 8 9 10

    // 従来の書き方
    {
      int sum = 0;
      foreach (var n in numbers)
        sum += n;
      WriteLine($"従来の書き方: {sum}");
      // 出力：
      // 従来の書き方: 55
    }

    // LINQ拡張メソッドのSum()を使う
    {
      int sum = numbers.Sum();
      WriteLine($"LINQのSumメソッド: {sum}");
      // 出力：
      // LINQのSumメソッド: 55
    }

    // LINQ拡張には、平均値を求めるAverageメソッドなどもある
    {
      double ave = numbers.Average();
      WriteLine($"LINQのAverageメソッド: {ave}");
      // 出力：
      // LINQのAverageメソッド: 5.5
    }


#if DEBUG
    // Visual Studio からデバッグ実行したときに、
    // コンソールがすぐに閉じてしまわないようにする
    Console.ReadKey();
#endif
  }
}
