using LinqToWiki.Generated; // LINQ-to-Wiki 
using System.Linq;
using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    var wiki 
      = new Wiki("LinqToWiki.Samples", "ja.wikipedia.org");
    var results 
      = wiki.Query
            .search("LINQ").Pages
            .Select(page => 
              new {
                Title = page.info.title,
                Url = page.info.fullurl
              }
            )
            .ToEnumerable()
            .Where(a => a.Title.Contains("言語"));
    foreach (var a in results)
      WriteLine($"{a.Title} - {a.Url}");
    // 出力例
    // 統合言語クエリ - http://ja.wikipedia.org/wiki/%E7%B5%B1%E5%90%88%E8%A8%80%E8%AA%9E%E3%82%AF%E3%82%A8%E3%83%AA
    // アセンブリ (共通言語基盤) - http://ja.wikipedia.org/wiki/%E3%82%A2%E3%82%BB%E3%83%B3%E3%83%96%E3%83%AA_(%E5%85%B1%E9%80%9A%E8%A8%80%E8%AA%9E%E5%9F%BA%E7%9B%A4)
    // メタデータ (共通言語基盤) - http://ja.wikipedia.org/wiki/%E3%83%A1%E3%82%BF%E3%83%87%E3%83%BC%E3%82%BF_(%E5%85%B1%E9%80%9A%E8%A8%80%E8%AA%9E%E5%9F%BA%E7%9B%A4)

#if DEBUG
    ReadKey();
#endif
  }
}
