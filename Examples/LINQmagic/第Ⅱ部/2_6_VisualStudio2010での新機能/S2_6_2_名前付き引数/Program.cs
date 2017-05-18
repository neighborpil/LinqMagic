using static System.Console;

class Program
{
  // 通常のメソッド
  static int Subtract(int a, int b)
  {
    return a - b;
  }

  // 省略可能な引数を持つメソッド
  static int SampleMethod(int x=1, int y=2, int z=3)
  {
    return x + y + z;
  }

  static void Main(string[] args)
  {
    // 名前付き引数を使って、引数の順序を入れ替える
    int n1 = Subtract(b: 1, a: 2);
    WriteLine($"Subtract(b: 1, a: 2)={n1}");
    // 出力：Subtract(b: 1, a: 2)=1

    // 名前付き引数を使って、省略可能な引数の途中だけを指定する
    int n2 = SampleMethod(y: 4);
    WriteLine($"SampleMethod(y: 4)={n2}");
    // 出力：SampleMethod(y: 4)=8

    // 注意：名前付き引数は「:」
    // 「=」を使うと、呼び出し側のスコープにある変数になってしまう
    int a, b;
    int n3 = Subtract(b=1, a=2);
    WriteLine($"Subtract(b=1, a=2)={n3}");
    // 出力：Subtract(b=1, a=2)=-1

#if DEBUG
    ReadKey();
#endif
  }
}
