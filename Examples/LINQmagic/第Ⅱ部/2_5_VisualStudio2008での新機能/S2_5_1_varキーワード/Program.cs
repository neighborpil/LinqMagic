using static System.Console;


class Program
{
  static void Main(string[] args)
  {
    var a = 1;
    var b = 1.0f;
    var c = 1.0;
    //var d = null; //コンパイルエラー

    WriteLine($"変数aの型は{a.GetType().Name}");
    WriteLine($"変数bの型は{b.GetType().Name}");
    WriteLine($"変数cの型は{c.GetType().Name}");
    // 出力：
    // 変数aの型はInt32
    // 変数bの型はSingle
    // 変数cの型はDouble

#if DEBUG
    ReadKey();
#endif
  }
}
