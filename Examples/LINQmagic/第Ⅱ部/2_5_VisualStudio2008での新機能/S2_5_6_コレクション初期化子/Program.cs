using System.Collections.Generic;
using System.Linq;
using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    // 配列の初期化
    int[] array1 = new int[] { 1, 2, 3, };
    foreach (int n in array1)
      WriteLine($"{n}");

    // コレクションの初期化（コレクション初期化子を使用）
    List<int> list1 = new List<int> { 1, 2, 3, };
    foreach (int n in list1)
      WriteLine($"{n}");

    // コレクションの初期化（従来の書き方）
    List<int> list2 = new List<int>();
    list2.Add(1);
    list2.Add(2);
    list2.Add(3);
    foreach (int n in list2)
      WriteLine($"{n}");
    // 出力：
    // 1
    // 2
    // 3


    WriteLine();

    // 匿名型のメンバーとしてList<int>型のコレクションを作る
    var result
      = Enumerable.Range(1, 3)
        .Select(n => new { Numbers = new List<int> { n, n + 1, n + 2, }, });
    foreach (var a in result)
      WriteLine($"{a.Numbers[0]}, {a.Numbers[1]}, {a.Numbers[2]}");
    // 出力：
    // 1, 2, 3
    // 2, 3, 4
    // 3, 4, 5


#if DEBUG
    ReadKey();
#endif
  }
}
