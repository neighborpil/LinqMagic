using static System.Console;

class Program
{
  // デリゲート「CalcDelegate型」の定義
  delegate int CalcDelegate(int n);

  // 「CalcDelegate型」にシグネチャが一致するメソッド
  // ※ C# 1.1では、この定義が必須だった
  static int Add1(int n)
  {
    return n + 1;
  }

  static void Main(string[] args)
  {
    // C# 1.1 のとき：
    // 「CalcDelegate型」の変数delegateSampleを宣言し、
    // Add1メソッドを代入して初期化
    CalcDelegate delegateSample1 = new CalcDelegate(Add1);

    // 「CalcDelegate型」の変数delegateSample1を実行
    int result1 = delegateSample1(2);
    WriteLine($"デリゲートを介してAdd1(2)を実行：{result1}");

    // C# 2.0 では、メソッド定義を別に書かずに済む
    CalcDelegate delegateSample2
      = delegate(int n)
        {
          // Add1メソッドの内容をここに直接書ける（匿名メソッド）
          return n + 1;
        };
    // 「CalcDelegate型」の変数delegateSample2を実行
    int result2 = delegateSample2(3);
    WriteLine($"匿名デリゲートを実行：{result2}");


#if DEBUG
    ReadKey();
#endif
  }
}
