using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    // 匿名型の初期化と、それを格納するローカル変数a
    var a = new {
                  FirstName ="康彦",
                  LastName = "山本",
                };
    //a.LastName = "高橋"; // 読み取り専用なので代入はコンパイルエラー
    WriteLine($"a.LastName={a.LastName}, a.FirstName={a.FirstName}");
    WriteLine($"匿名型変数aの型名は「{a.GetType().Name}」");
    // 出力例：
    // a.LastName=山本, a.FirstName=康彦
    // 匿名型変数aの型名は「<> f__AnonymousType0`2」




    // 日付型のコレクションを用意する
    var firstWeek = new List<DateTimeOffset>();
    var firstDay = new DateTimeOffset(2016, 1, 1, 0, 0, 0, 
                                      TimeSpan.FromHours(9.0));
    foreach (var n in Enumerable.Range(0, 7))
      firstWeek.Add(firstDay.AddDays(n));

    // 匿名型を使って、曜日の名前とその文字列長を取り出す
    var x
      = firstWeek.Select(d => 
                    new {
                          DayOfWeek =d.DayOfWeek.ToString(),
                          Length =d.DayOfWeek.ToString().Length,
                        });
    WriteLine($"匿名型コレクションの変数xの型名は「{x.GetType().Name}」");
    bool reported = false;
    foreach (var y in x)
    {
      if (!reported)
      {
        reported = true;
        WriteLine($"匿名型変数yの型名は「{y.GetType().Name}」");
      }
      WriteLine($"DayOfWeek={y.DayOfWeek}, Length={y.Length}");
    }
    // 出力例：
    // 匿名型コレクションの変数xの型名は「WhereSelectListIterator`2」
    // 匿名型変数yの型名は「<> f__AnonymousType1`2」
    // DayOfWeek = Friday, Length = 6
    // DayOfWeek = Saturday, Length = 8
    // DayOfWeek = Sunday, Length = 6
    // DayOfWeek = Monday, Length = 6
    // DayOfWeek = Tuesday, Length = 7
    // DayOfWeek = Wednesday, Length = 9
    // DayOfWeek = Thursday, Length = 8

#if DEBUG
    ReadKey();
#endif
  }
}
