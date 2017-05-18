using static System.Console;

public class SampleClass
{
  // 自動実装プロパティ（外部から読み書き可能）
  public string Name { get; set; }

  // 従来の書き方
  private string _name1;
  public string Name1 {
    get { return _name1; }
    set { _name1 = value; }
  }
  // ※この「_name1」に当たるメンバー変数が、
  //   自動実装プロパティでは自動生成される（コードからアクセスは不可）

  // 自動実装プロパティ（外部からは読み取りのみ）
  // C# 3.0 では、getとsetの両方とも記述しなければならないので、
  // 読み取り専用にしたい場合は、setをprivateにする
  public string Id { get; private set; }

  public SampleClass(string id)
  {
    Id = id;
  }
}


class Program
{
  static void Main(string[] args)
  {
    var s = new SampleClass("001");
    s.Name = "山本";

    WriteLine($"{s.Id}: {s.Name}");


#if DEBUG
    ReadKey();
#endif
  }
}
