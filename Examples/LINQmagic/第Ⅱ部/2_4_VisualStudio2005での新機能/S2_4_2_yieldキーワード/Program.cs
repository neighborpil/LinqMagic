using System.Collections.Generic;
using static System.Console;

class Program
{
  static IEnumerable<string> SampleIterate()
  {
    WriteLine("SampleIterateメソッド内：開始、一つめを返す"); //②
    yield return "abc";
    WriteLine("SampleIterateメソッド内：二つめを返す"); //④
    yield return "あいう";
  }

  static IEnumerable<string> IterateProperty
  {
    get //プロパティでもイテレーターを使用できる
    {
      string s = "これは、プロパティです";
      foreach (char c in s)
      {
        if (char.IsPunctuation(c))
          continue;

        if (c == 'プ')
        {
          yield break; //これで列挙終了
          WriteLine("この行は実行されない");
        }
        yield return c.ToString();
      }
      WriteLine("この行は実行されない");
    }
  }



  static void Main(string[] args)
  {
    IEnumerable<string> items = SampleIterate();
    WriteLine("SampleIterateメソッドの呼び出し完了"); //①

    int i = 1;
    foreach (var s in items)
      WriteLine($"foreachループ {i++} 周目：{s}"); //③、⑤
    // 出力：
    //① SampleIterateメソッドの呼び出し完了
    //② SampleIterateメソッド内：開始、一つめを返す
    //③ foreachループ 1 周目：abc
    //④ SampleIterateメソッド内：二つめを返す
    //⑤ foreachループ 2 周目：あいう



    foreach (string s in IterateProperty)
      WriteLine(s);
    // 出力：
    // こ
    // れ
    // は


#if DEBUG
    ReadKey();
#endif
  }
}
