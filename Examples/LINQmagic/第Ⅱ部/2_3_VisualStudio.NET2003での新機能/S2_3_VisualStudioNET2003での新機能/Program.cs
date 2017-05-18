using System.Collections;
using static System.Console;

class Program
{
  // デリゲート「CalcDelegate型」の定義
  delegate int CalcDelegate(int n);

  // 「CalcDelegate型」にシグネチャが一致するメソッド
  static int Add1(int n)
  {
    return n + 1;
  }


  // デリゲート「CalcDelegate2型」の定義
  delegate int CalcDelegate2();

  static int m;

  // 「CalcDelegate2型」にシグネチャが一致するメソッド
  // 注：このような副作用に頼るコードは良くないけれども、
  //     サンプルということでお許しください
  static int Add1()
  {
    WriteLine($"m={m}, Add1実行");
    m++;
    return m;
  }
  static int Twice()
  {
    WriteLine($"m={m}, Twice実行");
    m *= 2;
    return m;
  }


  static void Main(string[] args)
  {
    // foreachループの例
    IEnumerable numbers = new int[]{1, 2, 3, };
    foreach (object n in numbers)
    {
      if ((int)n % 2 == 0)
        continue;
      WriteLine(n);
    }
    // 出力：
    // 1
    // 3

    // 上のforeachループは、whileループでも書ける
    IEnumerator enumerator = numbers.GetEnumerator();
    while (enumerator.MoveNext())
    {
      object n = enumerator.Current;
      if ((int)n % 2 == 0)
        continue;
      WriteLine(n);
    }


    // デリゲートの例
    CalcDelegate delegateSample = new CalcDelegate(Add1);
    int result1 = delegateSample(2);
    WriteLine($"デリゲートを介してAdd1(2)を実行：{result1}");
    // 出力：
    // デリゲートを介してAdd1(2)を実行：3

    // マルチキャストデリゲート
    CalcDelegate2 multiDelegateSample = new CalcDelegate2(Add1);
    multiDelegateSample += Twice;
    m = 2;
    int result2 = multiDelegateSample();
    WriteLine($"デリゲートを介してAdd1、Twiceを実行：{result2}");
    // 出力：
    // m = 2, Add1実行
    // m = 3, Twice実行
    // デリゲートを介してAdd1、Twiceを実行：6


#if DEBUG
    ReadKey();
#endif
  }
}
