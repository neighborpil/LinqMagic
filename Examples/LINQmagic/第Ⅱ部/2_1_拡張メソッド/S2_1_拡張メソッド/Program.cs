using System;
using System.Linq;

using StringExtension; //この行が必須（削除して確認してみてください）

class Program
{
  static void Main(string[] args)
  {
    string s1 = "１２３４５";

    // 拡張メソッドの一般的な呼び出し方（名前空間のインポートが必須）
    string s2 = s1.Reverse();
    Console.WriteLine(s2);
    // 出力：５４３２１

    // 次のようにして呼び出すことも可能
    string s3 = StringExtension.MyExtensions.Reverse(s1);
    Console.WriteLine(s3);

    // メソッドチェーンにできる
    string s4 = "ABC".Reverse().ToLower();
    Console.WriteLine(s4);
    // 出力：cba

    // 引数を取る拡張メソッド
    Console.WriteLine("12345".Head(3));
    // 出力：123

#if DEBUG
    Console.ReadKey();
#endif
  }
}
