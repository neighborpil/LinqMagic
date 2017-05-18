using System;
using static System.Console;

class Program
{
  // int型を扱うメソッド
  static int Max1(int a, int b)
  {
    return a > b ? a : b;
  }

  // double型を扱うメソッド
  static double Max2(double a, double b)
  {
    return a > b ? a : b;
  }

  // 型に依存しないジェネリックなメソッド
  static T Max<T>(T a, T b) where T : IComparable
  {
    return a.CompareTo(b) > 0 ? a : b;
  }



  static void Main(string[] args)
  {
    // intの計算
    int result1 = Max1(1, 2);
    WriteLine($"Max1(1, 2)={result1}");

    // このメソッドにdoubleを与えると…
    //double result2 = Max1(1.2, 2.5);
    // →コンパイルエラー! 「'double'から'int'へ変換することはできません」

    // したがって、double用のAddメソッドも必要になる
    double result2 = Max2(1.2, 2.5);
    WriteLine($"Max2(1.2, 2.5)={result2}");

    // しかし、ジェネリックメソッドなら、呼び出すコードで型が決まる
    int result3 = Max<int>(1, 2);
    double result4 = Max<double>(1.2, 2.5);
    WriteLine($"Max<int>(1, 2)={result3}, Max<double>(1.2, 2.5)={result4}");

    // 推論可能な場合は型引数を省略可能
    int result5 = Max(1, 2);
    double result6 = Max(1.2, 2.5);
    WriteLine($"Max(1, 2)={result5}, Max(1.2, 2.5)={result6}");



    // MyStack<T>クラスを使う
    var stack = new MyStack<string>();
    WriteLine($"Count={stack.Count}");
    stack.Push("abc");
    WriteLine($"Count={stack.Count}");
    stack.Push("あいう");
    WriteLine($"Count={stack.Count}");
    string item1 = stack.Pop();
    WriteLine($"Pop:{item1}, Count={stack.Count}");
    string item2 = stack.Pop();
    WriteLine($"Pop:{item2}, Count={stack.Count}");
    // 出力：
    // Count = 0
    // Count = 1
    // Count = 2
    // Pop: あいう, Count = 1
    // Pop: abc, Count = 0

#if DEBUG
    ReadKey();
#endif
  }
}
