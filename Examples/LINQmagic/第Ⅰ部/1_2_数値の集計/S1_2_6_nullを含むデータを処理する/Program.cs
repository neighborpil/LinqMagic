using System;
using System.Linq;
using static System.Console;  // C# 6 の機能

class Program
{
  static void Main(string[] args)
  {
    // 要素に null も持つ Nullable<int> 型の配列
    int?[] numbers = { 1, 2, null, 3, };
    //int?[] numbers = { null, null, null, };

    // 従来の書き方
    {
      int min = int.MaxValue;
      int max = int.MinValue;
      bool areAllNull = true;
      foreach (int? n in numbers)
      {
        if (n == null)
          continue;

        areAllNull = false;
        if (n < min)
          min = n.Value;
        if (n > max)
          max = n.Value;
      }
      if (!areAllNull)
        WriteLine($"最小値, 最大値（従来の書き方）: {min}, {max}");
      // 出力：
      // 最小値, 最大値（従来の書き方）: 1, 3
      else
        WriteLine("コレクションの内容がすべて null でした");
    }

    // LINQ（一応これでも結果は得られる）
    {
      var min = numbers.Where(n => n != null).Min();
      var max = numbers.Where(n => n != null).Max();
      // min, max は var で宣言したけど。実際の型は何?

      if (min != null && max != null) // ←実際には片方のチェックだけで良い
        WriteLine($"最小値, 最大値（LINQその1）: {min}, {max}");
      // 出力：
      // 最小値, 最大値（LINQその1）: 1, 3
      else
        WriteLine("コレクションの内容がすべて null でした");
    }


    // LINQ（無駄のない書き方）
    {
      int? min = numbers.Min();
      int? max = numbers.Max();

      // これでもOKなんだが、さすがに分かりにくい
      //WriteLine("最小値, 最大値（LINQその2）: "
      //          + $"{min?.ToString() ?? "(null)"}, "
      //          + $"{max?.ToString() ?? "(null)"}");

      if (min != null) // minがnullでないなら、maxもnullではない
        WriteLine($"最小値, 最大値（LINQその2）: {min}, {max}");
      // 出力：
      // 最小値, 最大値（LINQその2）: 1, 3
      else
        WriteLine("コレクションの内容がすべて null でした");
    }


#if DEBUG
    // Visual Studio からデバッグ実行したときに、
    // コンソールがすぐに閉じてしまわないようにする
    Console.ReadKey();
#endif
  }
}

