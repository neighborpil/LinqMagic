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

  // 2-4. 条件を満たす数値だけを合計する
  static void Main(string[] args)
  {
    // 1～10までの整数を用意する
    IEnumerable<int> numbers = Enumerable.Range(1, 10);
    WriteNumbers(numbers, "元の数値");
    // 出力：
    // 元の数値: 1 2 3 4 5 6 7 8 9 10

    // 偶数だけを取り出して合計する（LINQ）
    {
      var evenNumbers = numbers.Where(n => n % 2 == 0);
      WriteNumbers(evenNumbers, "偶数だけ（LINQ-1）");
      // 出力：
      // 偶数だけ（LINQ-1）: 2 4 6 8 10

      var sum = evenNumbers.Sum();
      WriteLine($"偶数だけの合計（LINQ-1）: {sum}");
      // 出力：
      // 偶数だけの合計（LINQ-1）: 30
    }

    // LINQ拡張メソッドはチェーンできる
    {
      var sum = numbers.Where(n => n % 2 == 0).Sum();
      WriteLine($"偶数だけの合計（LINQ-2）: {sum}");
      // 出力：
      // 偶数だけの合計（LINQ-2）: 30
    }


#if DEBUG
    // Visual Studio からデバッグ実行したときに、
    // コンソールがすぐに閉じてしまわないようにする
    Console.ReadKey();
#endif
  }
}
