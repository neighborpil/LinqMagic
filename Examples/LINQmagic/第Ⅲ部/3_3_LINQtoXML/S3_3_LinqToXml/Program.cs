using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq; // LINQ to XML
using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    // ※ XMLファイルから読み込むには、
    //    一般的にはXDocument.Loadメソッドを使う
    //    ここでは、サンプルとしてXDocumentオブジェクトを
    //    直接生成する。

    // XMLドキュメントオブジェクトのサンプル
    XDocument xdoc 
      = new XDocument(
          new XDeclaration("1.0", "utf-8", "yes"),
          new XElement("Persons",
            new XElement("Person",
              new XElement("Id", "1"),
              new XElement("Name", "高橋")
            ),
            new XElement("Person",
              new XElement("Id", "2"),
              new XElement("Name", "山本")
            )
          )
        );
    WriteLine(xdoc.Declaration);
    WriteLine(xdoc);
    // 出力：
    // <?xml version="1.0" encoding="utf-8" standalone="yes"?>
    // <Persons>
    //   <Person>
    //     <Id>1</Id>
    //     <Name>高橋</Name>
    //   </Person>
    //   <Person>
    //     <Id>2</Id>
    //     <Name>山本</Name>
    //   </Person>
    // </Persons>


    // LINQ to XMLの拡張メソッドを使って、Personのコレクションを取り出す
    IEnumerable<XElement> persons 
      = xdoc.Descendants("Person");
    // LINQを使って、Id="2"のデータを取り出す
    var result 
      = persons.Where(xe => xe.Element("Id").Value == "2")
               .Select(xe => 
                 new {
                   id = xe.Element("Id").Value,
                   name = xe.Element("Name").Value,
                 } 
               )
               .FirstOrDefault();
    WriteLine($"{result.id}, {result.name}");
    // 出力：
    // 2, 山本

#if DEBUG
    ReadKey();
#endif
  }
}

