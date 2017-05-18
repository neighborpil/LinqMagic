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

  // コレクション内のすべての整数を表示するメソッド（従来の書き方）
  private static void WriteNumbers_oldstyle(IEnumerable<int> numbers,
                                            string header)
  {
    Console.Write("{0}:", header); 
    foreach (var n in numbers)
      Console.Write(" {0}", n);
    Console.WriteLine();
  }

  static void Main(string[] args)
  {
    // 1～10までの整数を用意する（LINQ）
    IEnumerable<int> numbers = Enumerable.Range(1, 10);
    WriteNumbers(numbers, "整数の入ったコレクション");
    // 出力：
    // 整数の入ったコレクション: 1 2 3 4 5 6 7 8 9 10

    // 1～10までの整数を用意する（従来の書き方）
    // ※配列は IEnumerable を実装している
    int[] numbers_oldstyle = new int[10];
    for (int i = 0; i < 10; i++)
      numbers_oldstyle[i] = i + 1;
    WriteNumbers_oldstyle(numbers_oldstyle,
                          "整数の入ったコレクション（従来の書き方）");
    // 出力：
    // 整数の入ったコレクション（従来の書き方）: 1 2 3 4 5 6 7 8 9 10

#if DEBUG
    // Visual Studio からデバッグ実行したときに、
    // コンソールがすぐに閉じてしまわないようにする
    Console.ReadKey();
#endif
  }
}
