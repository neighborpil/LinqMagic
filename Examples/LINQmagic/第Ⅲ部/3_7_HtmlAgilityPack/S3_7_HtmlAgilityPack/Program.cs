using System.Linq;
using static System.Console;

// サンプルに使うWebページ
// https://gihyo.jp/dp?query=C%23
/*
そのHTMLの一部を示す

<ul …省略… id="listBook" class="list-book"> 
  <li …省略…>
    <a itemprop="url" href="/dp/ebook/2013/978-4-7741-5907-2">
      <img itemprop="image" src=…省略…/>
      <p itemprop="name" class="title">Ｃ<wbr/>#<wbr/>による マルチコアのための非同期／<wbr/>並列処理プログラミング</p>
      <p itemprop="author" class="author">山本康彦　著</p>
      …省略…
    </a>
  </li>
  …省略…
</ul>
 */


class Program
{
  static void Main(string[] args)
  {
    // サンプルに使うWebページ
    string url = "https://gihyo.jp/dp?query=C%23";
    // 注意：
    // Webページの内容は、変更される可能性があります。
    // 以下のコードは本書執筆時点では正しく動作しましたが、
    // 将来にわたって動作することを保証するものではありません。

    // Html Agility PackにWebページを読み込ませる
    HtmlAgilityPack.HtmlDocument htmlDoc
      = (new HtmlAgilityPack.HtmlWeb()).Load(url);
    
    // 「id="listBook"」という属性を持つ<ul>要素を探し、
    // その中の<li>要素を全て取り出す（XPath）。
    HtmlAgilityPack.HtmlNodeCollection books
      = htmlDoc.DocumentNode
               .SelectNodes(@"//ul[@id=""listBook""]/li");
    WriteLine($"{books.Count}冊の本が見つかりました。");
    // 出力例：
    // 5冊の本が見つかりました。

    // <li>要素の中には、
    // <a>要素が一つあり、href属性を持っている。
    // さらに、その中には、
    // 「itemprop="name"」属性を持った<p>要素（＝書名）がある。
    // booksの中から、書名に「マルチコア」を含むものを探す
    var result
      = books.Select(li =>
                new {
                  relativeUrl 
                    = li.SelectSingleNode(@"./a")?
                        .GetAttributeValue("href", string.Empty),
                  title 
                    = li.SelectSingleNode(@".//p[@itemprop=""name""]")?
                        .InnerText,
                }
              )
              .Where(book => book.title?.Contains("マルチコア")??false)
              .FirstOrDefault();
    WriteLine($"書名：{result?.title}");
    WriteLine($"URLパス：{result?.relativeUrl}");
    // 出力例：
    // 書名：Ｃ#による マルチコアのための非同期／並列処理プログラミング
    // URLパス：/dp/ebook/2013/978-4-7741-5907-2

#if DEBUG
    ReadKey();
#endif
  }
}
