using System;
using System.Linq;
using static System.Console;

// async/awaitを使った非同期処理の記述例

class Program
{
  static string NowTime => DateTimeOffset.Now.ToString("ss.fff");

  static async void TplSample()
  {
    const string URL = "http://gihyo.jp/book/2013/978-4-7741-5828-0";
    var hc = new System.Net.Http.HttpClient();

    // 非同期処理を開始する
    WriteLine($"{NowTime} 非同期処理を開始します");
    string html = await hc.GetStringAsync(URL);

    // 非同期処理が完了した後の処理
    WriteLine($"{NowTime} 非同期処理が完了しました");
    WriteLine(html.Split("\r\n".ToCharArray())
                  .Where(s => s.Contains("title"))
                  .FirstOrDefault());
  }

  static void Main(string[] args)
  {
    TplSample();
    WriteLine($"{NowTime} Mainメソッド末尾");

    // 出力例：
    // 06.333 非同期処理を開始します
    // 06.395 Mainメソッド末尾
    // 07.114 非同期処理が完了しました
    // <title> Ｃ#による マルチコアのための非同期……省略……

#if DEBUG
    ReadKey();
#endif
  }
}
