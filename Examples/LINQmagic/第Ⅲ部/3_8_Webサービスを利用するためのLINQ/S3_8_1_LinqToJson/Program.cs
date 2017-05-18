using Newtonsoft.Json.Linq; // Json.NET
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    // Bing APIを呼び出して、Web検索
    Task<string> task = SearchBingByJson("C# マルチコア 非同期");
    task.Wait(); // コンソールプログラムのMainメソッドではawait出来ない
    // 注：ここで例外が出る場合は、Bing Search APIのプライマリアカウントキーが
    //     SearchBingByJsonメソッド内に正しく設定されているか確認してください。

    string jsonResult = task.Result;

    // Json.NETのLINQ to JSONを使って、TitleとUrlを取り出す
    JObject jo = JObject.Parse(jsonResult);
    var results
      =jo["d"]["results"]
        .Select(t => 
          new {
            Title = t["Title"],
            Url = t["Url"]
          }
        );
    foreach (var result in results)
    {
      WriteLine($"TITLE: {result.Title}");
      WriteLine($"URL: {result.Url}");
    }
    // 出力例：
    // TITLE: Amazon.co.jp： C#によるマルチコアのための非同期/並列処理 ...
    // URL: http://www.amazon.co.jp/C-によるマルチコアのための非同期-並列処理プログラミング-山本-康彦/dp/4774158283
    // TITLE: C#による マルチコアのための非同期／並列処理プログラミング ...
    // URL: http://gihyo.jp/book/2013/978-4-7741-5828-0
    // TITLE: C#によるマルチコアのための非同期/並列処理プログラミング ...
    // URL: http://topics.libra.titech.ac.jp/recordID/catalog.bib/BB13115684

#if DEBUG
    ReadKey();
#endif
  }

  // BINGのWeb検索を呼び出し、結果をJSON文字列で返す
  static async Task<string> SearchBingByJson(string searchWord)
  {
    string serviceUrl 
      = "https://api.datamarket.azure.com/Bing/Search/v1/Web";
    string bingPrimaryAccountKey
      = "……省略……";
    string encodedWord
      = Uri.EscapeDataString($"'{searchWord}'");
    // 上の「……省略……」部分には、「Bing Search API」の利用権を購入後に
    // 下記のURLで取得できる「プライマリアカウントキー」 を設定します
    // https://datamarket.azure.com/dataset/explore/bing/search

    using (var handler = new HttpClientHandler())
    {
      handler.Credentials 
        = new NetworkCredential(bingPrimaryAccountKey, bingPrimaryAccountKey);
      using (var client = new HttpClient(handler))
      {
        var result = await client.GetStringAsync(
          $"{serviceUrl}?Query={encodedWord}&$top=3&$format=json");
        // $top=3 … 先頭の3件だけ取得
        // $format=json … 結果をJSONフォーマットで取得
        return Uri.UnescapeDataString(result);
      }
    }
  }
  // 取得結果の例（整形済み）
  // {
  //   "d":
  //   {
  //     "results":
  //     [
  //       {
  //         "__metadata":
  //         {
  //           "uri":"https://api.datamarket.azure.com/Data.ashx/Bing/Search/v1/Web?Query=\u0027C&$skip=0&$top=1# マルチコア 非同期\u0027",
  //           "type":"WebResult"
  //         },
  //         "ID":"04d32782-659c-4388-8a36-1103aa4ac12c",
  //         "Title":"Amazon.co.jp： C#によるマルチコアのための非同期/並列処理 ...",
  //         "Description":"内容紹介. いまやマルチコアのCPUは主流と言えますが、その性能を十分に発揮させるためにはソフトウェアもそれに対応し、非同期処",
  //         "DisplayUrl":"www.amazon.co.jp/C-によるマルチコアのための...",
  //         "Url":"http://www.amazon.co.jp/C-によるマルチコアのための非同期-並列処理プログラミング-山本-康彦/dp/4774158283"
  //       },
  //       {
  //         "__metadata":
  //         {
  //           "uri":"https://api.datamarket.azure.com/Data.ashx/Bing/Search/v1/Web?Query=\u0027C&$skip=1&$top=1# マルチコア 非同期\u0027",
  //           "type":"WebResult"
  //         },
  //         "ID":"46e3e8f0-8a6c-4189-9563-5bec24603902",
  //         "Title":"C#による マルチコアのための非同期／並列処理プログラミング ...",
  //         "Description":"いまやマルチコアのCPUは主流と言えますが，その性能を十分に発揮させるためにはソフトウェアもそれに対応し，非同期処理／並列処理でパフォーマンスを上げなければなりません。とは言え，これは一般的なプログラマーに ...",
  //         "DisplayUrl":"gihyo.jp/book/2013/978-4-7741-5828-0",
  //         "Url":"http://gihyo.jp/book/2013/978-4-7741-5828-0"
  //       },
  //       {
  //         "__metadata":
  //         {
  //           "uri":"https://api.datamarket.azure.com/Data.ashx/Bing/Search/v1/Web?Query=\u0027C&$skip=2&$top=1# マルチコア 非同期\u0027",
  //           "type":"WebResult"
  //         },
  //         "ID":"0aabc75e-d7ed-4517-8207-5eaa85a736fc",
  //         "Title":"C#によるマルチコアのための非同期/並列処理プログラミング ...",
  //         "Description":"C#によるマルチコアのための非同期/並列処理プログラミング : 最新開発テクニックの基礎&実践知識 / 山本康彦著 資料種別: 図書 出版情報: 東京 : 技術評論社, 2013.8 形態: 253p ; 23cm 著者名: 山本, 康彦(1957-) ISBN:",
  //         "DisplayUrl":"topics.libra.titech.ac.jp/recordID/catalog.bib/BB13115684",
  //         "Url":"http://topics.libra.titech.ac.jp/recordID/catalog.bib/BB13115684"
  //       }
  //     ],
  //     "__next":"https://api.datamarket.azure.com/Data.ashx/Bing/Search/v1/Web?Query=\u0027C&$skip=3&$top=3"
  //   }
  // }


}

