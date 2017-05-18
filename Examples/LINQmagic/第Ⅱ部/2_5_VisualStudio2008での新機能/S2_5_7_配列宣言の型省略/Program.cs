using System.Linq;
using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    // 従来の書き方（左辺に型名を指定）
    int[] array1 = { 1, 2, 3, };
    WriteLine($"array1の型は{array1.GetType().Name}");

    // varを使って、右辺に型名を指定
    var array2 = new int[] { 1, 2, 3, };
    WriteLine($"array2の型は{array2.GetType().Name}");

    // 配列宣言の型省略
    var array3 = new[] { 1, 2, 3, };
    WriteLine($"array3の型は{array3.GetType().Name}");
    // 出力：
    // array3の型はInt32[]

    // 型を推論できないときはコンパイルエラー
    //var array4 = new[] { null, null, null, };
    //var array5 = new[] { 1, "abc", };


    WriteLine();

    // 匿名型のメンバーとして匿名型の配列を与える
    var result
      = Enumerable.Range(1, 3)
        .Select(n => new { Numbers = new[] 
                           {
                             new { Base=n, Negative=-n, },
                             new { Base=-n, Negative = n, },
                           },
                         });
    int count = 1;
    foreach (var a in result)
    {
      WriteLine($"{count++}番めの匿名型の配列");
      int index = 0;
      foreach (var n in a.Numbers)
        WriteLine($"要素[{index++}]: Base={n.Base}, Negative={n.Negative}");
    }
    // 出力：
    // 1番めの匿名型の配列
    // 要素[0]: Base = 1, Negative = -1
    // 要素[1]: Base = -1, Negative = 1
    // 2番めの匿名型の配列
    // 要素[0]: Base = 2, Negative = -2
    // 要素[1]: Base = -2, Negative = 2
    // 3番めの匿名型の配列
    // 要素[0]: Base = 3, Negative = -3
    // 要素[1]: Base = -3, Negative = 3


#if DEBUG
    ReadKey();
#endif
  }
}
