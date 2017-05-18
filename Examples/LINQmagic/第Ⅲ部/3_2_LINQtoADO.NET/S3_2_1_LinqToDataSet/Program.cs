using System;
using System.Data;
using System.Linq;
using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    // DataTableを用意する
    var idColumn = new DataColumn("ID", typeof(UInt32));
    var nameColumn = new DataColumn("NAME", typeof(string));
    var dt = new DataTable();
    dt.Columns.Add(idColumn);
    dt.Columns.Add(nameColumn);
    dt.Rows.Add(1, "高橋");
    dt.Rows.Add(2, "山本");

    // LINQ to DataSetを使わない場合
    {
      // ID=2のデータを取り出す
      DataRow[] result = dt.Select("ID=2");
      WriteLine($"得られた結果の数：{result.Length}");
      object id = result[0]["ID"];
      object name = result[0]["NAME"];
      WriteLine($"ID={id}, NAME={name}");
      // 出力：
      // 得られた結果の数：1
      // ID = 2, NAME = 山本

      // 問題点：
      // DataTableクラスのSelectメソッドで可能な処理は少ない
      // DataTableクラスのSelectメソッドは文字列リテラル
      // DataRowクラスの各フィールドはobject型
    }

    // LINQ to DataSetを使う場合
    {
      // ID=2のデータを取り出す
      var result
        = dt.AsEnumerable()
            .Where(row => row.Field<UInt32>(idColumn) == 2)
            .Select(row => new
            {
              id = row.Field<UInt32>(idColumn),
              name = row.Field<string>(nameColumn)
            });
      WriteLine($"得られた結果の数：{result.Count()}");
      uint id = result.First().id;
      string name = result.First().name;
      WriteLine($"ID={id}, NAME={name}");
      // 出力：
      // 得られた結果の数：1
      // ID = 2, NAME = 山本
    }


#if DEBUG
    ReadKey();
#endif
  }
}

