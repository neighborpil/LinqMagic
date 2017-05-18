using static System.Console;

class Program
{
  // メソッド：従来の書き方
  int SampleMethod1(int a, int b)
  {
    return a + b;
  }

  // メソッド：ラムダ式による定義
  int SampleMethod2(int a, int b) => a + b;

  // voidのメソッドでも可能
  private int _number;
  void SampleMethod1(int n)
  {
    _number = n * 2;
  }
  void SampleMethod2(int n) => _number = n * 2;

  // 読み取り専用プロパティ：従来の書き方
  int SampleProperty1
  {
    get
    {
      return _number * 3;
    }
  }

  // 読み取り専用プロパティ：ラムダ式による定義
  // ※「{ get; }」は書かない
  int SampleProperty2 => _number * 3;



  static void Main(string[] args)
  {
    var o = new Program();

    WriteLine($"SampleMethod1(1, 2)={o.SampleMethod1(1, 2)}");
    WriteLine($"SampleMethod2(2, 3)={o.SampleMethod2(2, 3)}");

    o.SampleMethod1(2);
    WriteLine($"SampleMethod1(2) → _number={o._number}");

    o.SampleMethod2(3);
    WriteLine($"SampleMethod2(3) → _number={o._number}");

    o._number = 1;
    WriteLine($"_number = 1 → SampleProperty1 = {o.SampleProperty1}");
    o._number = 2;
    WriteLine($"_number = 2 → SampleProperty2 = {o.SampleProperty2}");

#if DEBUG
    ReadKey();
#endif
  }
}
