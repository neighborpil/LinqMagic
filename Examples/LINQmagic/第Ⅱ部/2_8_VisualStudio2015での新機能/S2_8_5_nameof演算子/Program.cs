using System;
using static System.Console;

class SampleClass
{
  public int SampleProperty1 => 1;
  private int SampleProperty2 => 2;

  public void SampleMethod(string inputString)
  {
    // 例外メッセージで使う例
    if (string.IsNullOrWhiteSpace(inputString))
      throw new ArgumentNullException(nameof(inputString));
  }
}

class Program
{
  static void Main(string[] args)
  {
    var c = new SampleClass();

    // 従来の書き方（文字列リテラル）
    WriteLine($"SampleClass型の変数c");
    // 出力：SampleClass型の変数c

    // nameof演算子を使用
    WriteLine($"{nameof(SampleClass)}型の変数{nameof(c)}");
    // 出力：SampleClass型の変数c
    // ※ 名前を変更したとき、修正漏れがあればコンパイルエラーで発見できる

    // プロパティ名／メソッド名／名前空間名など取得可能
    WriteLine($"プロパティ{nameof(c.SampleProperty1)}");
    // 出力：プロパティSampleProperty1
    WriteLine($"メソッド{nameof(c.SampleMethod)}");
    // 出力：メソッドSampleMethod
    // アクセスできないものはコンパイルエラーになる↓
    //WriteLine($"プロパティ{nameof(c.SampleProperty2)}");
    WriteLine($"名前空間{nameof(System.Linq)}");
    // 出力：名前空間Linq
    // ※ 名前の最後の部分しか取れないので注意

    // 組み込み型は取得できない
    //WriteLine($"{nameof(int)}"); //コンパイルエラー
    WriteLine($"{nameof(System.Int32)}"); //これはOK
    // 出力：Int32

    // 例外メッセージで使う例
    try
    {
      c.SampleMethod(null);
    }
    catch (ArgumentNullException ex)
    {
      WriteLine($"{ex.Message}");
      // 出力：
      // 値を Null にすることはできません。
      // パラメーター名:inputString
    }

#if DEBUG
    ReadKey();
#endif
  }
}
