using System;
using System.Linq;
using static System.Console;  // C# 6 の機能

class Program
{
  static void WriteTotalMemory(string header)
  {
    var totalMemory = GC.GetTotalMemory(true) / 1024.0 / 1024.0;
    WriteLine($"{header}: {totalMemory:0.0 MB}");
  }

  // 2-5. メモリー消費を確かめる
  static void Main(string[] args)
  {
    // 1～100万（100万個）の整数を持つ配列（約4MB）
    int[] numbers = Enumerable.Range(1, 1000000).ToArray();
    WriteTotalMemory("配列確保後");
    WriteLine($"配列の要素数: {numbers.Length}\n");
    // 出力：
    // 配列確保後: 3.9 MB
    // 配列の要素数: 1000000

    // 従来の書き方（一つのループ内で処理）
    {
      // 偶数だけを取り出して平均値を求める
      double ave = 0;
      int count = 0;
      foreach (int n in numbers)
      {
        if (n % 2 == 0)
        {
          count++;
          ave += (n - ave) / count;
        }
      }
      WriteTotalMemory("計算後（従来の書き方）");
      WriteLine($"偶数だけの平均値（従来の書き方）: {ave}\n");
      // 出力：
      // 計算後（従来の書き方）: 3.9 MB
      // 偶数だけの平均値（従来の書き方）: 500001
    }

    // LINQ（コード上は偶数だけのコレクションを作るように見える）
    {
      // 偶数だけを取り出したコレクションを得る（2MBほど消費する?）
      var evenNumbers = numbers.Where(n => n % 2 == 0);
      WriteTotalMemory("偶数だけ取り出した後");
      // 出力：
      // 偶数だけ取り出した後: 3.9 MB
      // ※なんと、メモリーを消費していない!!

      // 平均値を求める
      var ave = evenNumbers.Average();
      WriteTotalMemory("計算後（LINQ）");
      WriteLine($"偶数だけの平均値（LINQ）: {ave}");
      // 出力：
      // 計算後（LINQ）: 3.9 MB
      // 偶数だけの平均値（LINQ）: 500001

      // 参考: 合計するには、int のままでは桁あふれするので、long にキャストする必要がある
      // var sum = evenNumbers.Sum(n => (long)n); 
    }


#if DEBUG
    // Visual Studio からデバッグ実行したときに、
    // コンソールがすぐに閉じてしまわないようにする
    Console.ReadKey();
#endif
  }
}
