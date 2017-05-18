using static System.Console;

// パーシャルクラスの一方
public partial class SampleClass
{
  public string FullName { get; private set; }

  public static SampleClass Create1(string firstName, string lastName)
  {
    var instance = new SampleClass();
    instance.SetFullName1(firstName, lastName); //パーシャルメソッドを呼び出し
    return instance;
  }

  public static SampleClass Create2(string firstName, string lastName)
  {
    var instance = new SampleClass();
    instance.SetFullName2(firstName, lastName); //パーシャルメソッドを呼び出し
    return instance;
  }

  // パーシャルメソッドの定義
  // ※void型でなければならない。また、暗黙にprivateになる。
  partial void SetFullName1(string firstName, string lastName);
  partial void SetFullName2(string firstName, string lastName);
}

// パーシャルクラスの他方
public partial class SampleClass
{
  // パーシャルメソッドの実装
  partial void SetFullName1(string firstName, string lastName)
  {
    this.FullName = $"{lastName} {firstName}";
  }

  // SetFullName2は未実装
  //
  // ※実装がないときは、
  //   そのパーシャルメソッドを呼び出している部分が無視される
  //   （コンパイルエラーにはならない）
}


class Program
{
  static void Main(string[] args)
  {
    var s1 = SampleClass.Create1("康彦", "山本");
    WriteLine($"FullName:「{s1.FullName}」");
    var s2 = SampleClass.Create2("康彦", "山本");
    WriteLine($"FullName:「{s2.FullName}」");
    // 出力：
    // FullName:「山本 康彦」
    // FullName:「」

#if DEBUG
    ReadKey();
#endif
  }
}
