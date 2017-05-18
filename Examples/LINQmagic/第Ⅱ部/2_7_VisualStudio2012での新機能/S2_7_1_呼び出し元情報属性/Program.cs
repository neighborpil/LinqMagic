using System.IO;
using System.Runtime.CompilerServices;
using static System.Console;

public class SampleClass
{
  // Caller Info（呼び出し元情報）には3つの属性がある
  // CallerMemberName、CallerFilePath、CallerLineNumber
  // これらの属性は、省略可能な引数に付ける

  public static void ShowCallerInfo(
      string message,
      [CallerMemberName] string callerMemberName = "",
      [CallerFilePath] string callerFilePath="",
      [CallerLineNumber] int callerLineNumber=0
    )
  {
    WriteLine(message);
    WriteLine($"CallerMemberName={callerMemberName}");
    WriteLine($"CallerFileName={Path.GetFileName(callerFilePath)}");
    WriteLine($"CallerLineNumber={callerLineNumber}");
    WriteLine();
  }

  public SampleClass()
  {
    ShowCallerInfo("SampleClassのコンストラクターから呼び出し：");
  }

  public void SampleMethod()
  {
    ShowCallerInfo("SampleMethodメソッドから呼び出し：");
  }

  public string SampleProperty
  {
    get
    {
      ShowCallerInfo("SamplePropertyプロパティから呼び出し：");
      return null;
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    SampleClass.ShowCallerInfo("Mainメソッドから呼び出し：");
    // 出力：
    // Mainメソッドから呼び出し：
    // CallerMemberName = Main
    // CallerFileName = Program.cs
    // CallerLineNumber = 49

    var s = new SampleClass();
    // 出力：
    // SampleClassのコンストラクターから呼び出し：
    // CallerMemberName =.ctor
    // CallerFileName = Program.cs
    // CallerLineNumber = 27

    s.SampleMethod();
    // 出力：
    // SampleMethodメソッドから呼び出し：
    // CallerMemberName = SampleMethod
    // CallerFileName = Program.cs
    // CallerLineNumber = 32

    var t = s.SampleProperty;
    // 出力：
    // SamplePropertyプロパティから呼び出し：
    // CallerMemberName = SampleProperty
    // CallerFileName = Program.cs
    // CallerLineNumber = 39

    // Caller Infoを与えてやれば、呼び出し元を隠せる
    SampleClass.ShowCallerInfo(
        "Mainメソッドから呼び出し（情報隠蔽）：",
        "Fake Name", "Fake File", -999
      );
    // 出力：
    // Mainメソッドから呼び出し（情報隠蔽）：
    // CallerMemberName = Fake Name
    // CallerFileName = Fake File
    // CallerLineNumber = -999

#if DEBUG
    ReadKey();
#endif
  }
}
