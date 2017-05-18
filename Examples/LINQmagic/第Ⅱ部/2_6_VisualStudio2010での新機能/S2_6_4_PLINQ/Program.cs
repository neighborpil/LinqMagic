using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class Program
{
  static string SampleMethod(int n)
  {
    var id = System.Threading.Thread.CurrentThread.ManagedThreadId;
    WriteLine($"START: n={n}, ThreadId={id}");

    // マルチスレッド動作を確認しやすくするためランダムな時間を待機
    System.Threading.Thread.Sleep(100 + (new Random()).Next(100));

    var result = $"result={n}";
    WriteLine($"END:   n={n}, ThreadId={id}");
    return result;
  }

  static void Main(string[] args)
  {
    IEnumerable<int> numbers = Enumerable.Range(1, 5);

    // 通常のLINQ
    IEnumerable<string> results1
      = numbers.Select(n => SampleMethod(n));
    foreach (var s in results1)
      WriteLine(s);

    WriteLine();

    // PLINQ
    ParallelQuery<string> results2
      = numbers.AsParallel().Select(n => SampleMethod(n));
    foreach (var s in results2)
      WriteLine(s);

    WriteLine();

    // PLINQ（順序保持）
    ParallelQuery<string> results3
      = numbers.AsParallel().AsOrdered().Select(n => SampleMethod(n));
    foreach (var s in results3)
      WriteLine(s);

#if DEBUG
    ReadKey();
#endif
  }
}
