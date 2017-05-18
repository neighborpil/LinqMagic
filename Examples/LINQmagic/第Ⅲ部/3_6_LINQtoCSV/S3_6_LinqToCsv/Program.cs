using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

// 扱うデータの定義
// ※ CsvColumn属性は、LINQ to CSVのもの
public class SampleData
{
  [CsvColumn(Name = "UserName", FieldIndex = 1)]
  public string Person { get; set; }

  [CsvColumn(FieldIndex = 2, CanBeNull = false)]
  public int Value { get; set; }
}

class Program
{
  static void Main(string[] args)
  {
    // CSVデータの読み取りストリーム
    // ※ 先頭の行はフィールド名。
    //    「"」で囲まれた文字列の中に「,」がある。
    //    また、「"」で囲まれた数値もある。
    string sampleCsv =
@"UserName, Value
Atobe, 1000
""Yo Takahashi"", ""2000""
""Yamamoto, Yasuhiko"", ""1,500""
";
    StreamReader reader 
      = new StreamReader(
              new MemoryStream(
                    Encoding.UTF8.GetBytes(sampleCsv)
                  )
            );

    // CSVファイルのフォーマット指定
    CsvFileDescription inputFileDescription
      = new CsvFileDescription
            {
              SeparatorChar = ',',
              FirstLineHasColumnNames = true,
              TextEncoding = Encoding.UTF8,
            };

    // CSVファイルを読み込む
    // ※ 一般的にはReadメソッドにファイル名を直接指定する。
    //    なお、この時点では実際には読み込まれない。
    IEnumerable<SampleData> data
      = (new CsvContext()).Read<SampleData>(reader, inputFileDescription);

    // LINQ to Objectsで処理
    // Personが"Yamamoto, Yasuhiko"であるデータのValueを得る
    // ※ このループ処理中にファイルから1行ずつ読み込まれる
    try
    {
      int? value
        = data.Where(s =>
                     s.Person.Contains("Yamamoto, Yasuhiko"))
              .FirstOrDefault()?
              .Value;
      WriteLine(value);
      // 出力：
      // 1500
    }
    catch (Exception ex)
    {
      // CSVファイル読み込み中のエラーもここでキャッチ
      WriteLine(ex.Message);
      throw;
    }

#if DEBUG
    ReadKey();
#endif
  }
}

