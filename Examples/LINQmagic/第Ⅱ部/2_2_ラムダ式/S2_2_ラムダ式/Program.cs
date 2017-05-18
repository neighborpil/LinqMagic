using System;
using static System.Console;

namespace S2_2_ラムダ式CS
{
  class Program
  {
    // 普通のメソッド定義（メソッドの中身はreturnするだけ）
    int Add1(int x, int y)
    {
      return x + y;
    }

    // ラムダ式によるメソッド定義
    int Add2(int x, int y)
      => x + y;

    // 匿名メソッドによるデリゲート定義
    Func<int, int, int> Add3
      = delegate (int x, int y)
        {
          return x + y;
        };

    // ラムダ式によるデリゲート定義（その1）
    Func<int, int, int> Add4
      = (x, y) =>
        {
          return x + y;
        };

    // ラムダ式によるデリゲート定義（その2）
    Func<int, int, int> Add5
      = (x, y) => x + y;

    // 入力パラメーターが1個の場合は、その括弧を省略できる
    Func<int, int> Twice 
      = x => x * 2;


    static void Main(string[] args)
    {
      var instance = new Program();
      WriteLine($"普通のメソッド定義：{instance.Add1(1,2)}");
      WriteLine($"ラムダ式によるメソッド定義：{instance.Add2(1, 2)}");
      WriteLine($"匿名メソッドによるデリゲート定義：{instance.Add3(1, 2)}");
      WriteLine($"ラムダ式によるデリゲート定義（その1）：{instance.Add4(1, 2)}");
      WriteLine($"ラムダ式によるデリゲート定義（その2）：{instance.Add5(1, 2)}");


      // ラムダ式で変数をキャプチャ
      int n = 3;
      Func<int, int> addN = (x) => n += x;
      WriteLine($"n={n}, addN(2)={addN(2)}, n={n}");
      // 出力：
      // n=3, addN(2)=5, n=5


#if DEBUG
      ReadKey();
#endif
    }
  }
}
