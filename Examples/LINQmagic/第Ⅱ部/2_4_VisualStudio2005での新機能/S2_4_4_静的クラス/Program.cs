using System;
using static System.Console;


// 静的クラス
public static class SampleClass
{
  private static DateTimeOffset _start;

  // 静的コンストラクター
  // アクセス修飾子なし、引数なし
  // このクラスの静的メンバーが初めて使われるときに、実行される
  static SampleClass()
  {
    _start = DateTimeOffset.Now;
    WriteLine("静的コンストラクター実行");
  }

  public static double ElapsedSeconds
  {
    get
    {
      return DateTimeOffset.Now.Subtract(_start).TotalSeconds;
    }
  }

}

class Program
{
  static void Main(string[] args)
  {
    WriteLine("Mainメソッド開始");
    // 出力：
    // Mainメソッド開始

    System.Threading.Thread.Sleep(1000); //約1秒待機
    WriteLine("1秒経過");
    // 出力：
    // 1秒経過

    WriteLine($"静的クラス呼び出し：{SampleClass.ElapsedSeconds}秒");
    // 出力例：
    // 静的コンストラクター実行
    // 静的クラスのメソッド呼び出し：0.0049994秒
    //※ 静的クラスのメンバーが最初に呼び出されるときに、
    //   静的コンストラクターが実行されている

    System.Threading.Thread.Sleep(1000); //約1秒待機

    WriteLine($"静的クラス呼び出し：{SampleClass.ElapsedSeconds}秒");
    // 出力例：
    // 静的クラスのメソッド呼び出し：1.006秒

#if DEBUG
    ReadKey();
#endif
  }
}

