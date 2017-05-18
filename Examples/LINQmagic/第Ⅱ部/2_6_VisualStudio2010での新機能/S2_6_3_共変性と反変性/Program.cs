using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    // 共変性
    IEnumerable<string> se = new[]{ "abc", "あいう", };
    // seはstring型のコレクションなので、stringのメソッドを呼び出せる
    WriteLine($"{se.First().Substring(0,1)}");
    // 出力：a

    // ↓object型のコレクションにキャスト（暗黙の型変換）

    IEnumerable<object> oe = se;
    // oeはobject型のコレクションなので、stringのメソッドは呼び出せない
    //WriteLine($"{oe.First().Substring(0, 1)}"); //コンパイルエラー
    foreach (object o in oe)
      WriteLine($"{o.ToString()}"); // ToStringメソッドはobject型にもある
    // 出力：
    // abc
    // あいう

    // 反変性
    Func<object, string> od = o => o.GetType().Name;
    // odは引数にobject型を取るデリゲートなので、DateTimeOffset型も渡せる
    WriteLine($"{od(DateTimeOffset.Now)}");
    // 出力：DateTimeOffset

    // ↓string型のデリゲートにキャスト（暗黙の型変換）

    Func<string, string> sd = od;
    // sdは引数にstring型を取るデリゲートなので、DateTimeOffset型は不可
    //WriteLine($"{sd(DateTimeOffset.Now)}"); //コンパイルエラー
    WriteLine($"{sd("abc")}");
    // 出力：String


    // 共変性/反変性を越えてキャストするには、
    // 明示的にCast拡張メソッドを使う

    List<string> sl = new List<string> { "abc", "あいう", };
    // List<T>は不変なので、List<object>にキャストできない
    //List<object> ol = sl; //コンパイルエラー
    //List<object> ol = (List<object>)sl; //コンパイルエラー

    // Cast拡張メソッドを使う
    List<object> ol = sl.Cast<object>().ToList();

    // ただし、上のコードは、コレクションの新しい実体を生成している
    // 要素を書き換えても元のコレクションには反映されないので注意
    ol[0] = "ABC";
    WriteLine($"ol[0]={ol[0]}");
    WriteLine($"sl[0]={sl[0]}");
    // 出力：
    // ol[0]=ABC
    // sl[0]=abc


#if DEBUG
    ReadKey();
#endif
  }
}
