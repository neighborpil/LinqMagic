using static System.Console;

class Program
{
  // 従来の書き方
  private string _var1 = "abc";
  public string Var1
  {
    get
    {
      return _var1;
    }
    set
    {
      _var1 = value;
    }
  }


  // C# 3（自動実装プロパティ）
  public string Var2 { get; set; }

  // C# 3 の自動実装プロパティは、コンストラクターで初期化する
  public Program()
  {
    Var2 = "abc";
  }


  // C# 6（自動実装プロパティの初期化子）
  public string Var3 { get; set; } = "abc";



  static void Main(string[] args)
  {
    var o = new Program();

    WriteLine("従来のプロパティ");
    WriteLine($"初期値={o.Var1}");
    o.Var1 = "ABC";
    WriteLine($"変更後={o.Var1}");

    WriteLine("C# 3の自動実装プロパティ");
    WriteLine($"初期値={o.Var2}");
    o.Var2 = "ABC";
    WriteLine($"変更後={o.Var2}");

    WriteLine("C# 6の自動実装プロパティ");
    WriteLine($"初期値={o.Var3}");
    o.Var3 = "ABC";
    WriteLine($"変更後={o.Var3}");

#if DEBUG
    ReadKey();
#endif
  }
}
