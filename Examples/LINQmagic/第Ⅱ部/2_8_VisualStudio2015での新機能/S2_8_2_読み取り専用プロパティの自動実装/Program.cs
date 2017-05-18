using static System.Console;

class Program
{
  // 従来の書き方
  private readonly string _var1;
  public string Var1
  {
    get
    {
      return _var1;
    }
  }

  // C# 3（自動実装プロパティ）
  public string Var2 { get; private set; }

  // C# 6（自動実装プロパティ）
  public string Var3 { get; }

  // 読み取り専用プロパティは、コンストラクターで初期化する
  public Program()
  {
    _var1 = "abc";
    Var2 = "abc";
    Var3 = "abc";
  }





  static void Main(string[] args)
  {
    var o = new Program();

    WriteLine("従来のプロパティ");
    WriteLine($"初期値={o.Var1}");
    //o._var1 = "ABC"; //コンパイルエラー（コンストラクター以降では書き込み不可）

    WriteLine("C# 3の自動実装プロパティ");
    WriteLine($"初期値={o.Var2}");
    // 注意：他の二つと違い、クラス内からであれば変更できてしまう
    //o.Var2 = "ABC"; //privateなsetterでは、クラス内から書き込みできてしまう

    WriteLine("C# 6の自動実装プロパティ");
    WriteLine($"初期値={o.Var3}");
    //o.Var3 = "ABC"; //コンパイルエラー（コンストラクター以降では書き込み不可）


#if DEBUG
    ReadKey();
#endif
  }
}
