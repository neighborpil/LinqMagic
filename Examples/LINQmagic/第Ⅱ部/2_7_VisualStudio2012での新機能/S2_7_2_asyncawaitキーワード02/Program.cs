using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

class Program
{
  static async Task<string> NumToStringAsync(int n)
  {
    await Task.Delay(100); // 一定時間待機（非同期処理）
    return n.ToString();
  }

  static string NumToString(int n)
  {
    Task<string> t = NumToStringAsync(n);
    t.Wait(); // 非同期処理の完了を待つ
    return t.Result;
  }

  static async void SelectSample()
  {
    // Select拡張メソッドではasync/awaitが使える
    IEnumerable<Task<string>> taskCollection
      = Enumerable.Range(1, 12)
                  .Select(async n => await NumToStringAsync(n));

    // ただし、Task<T>型のコレクションになってしまうので、
    // 次のようにTask.WhenAllを使って実体化する必要がある
    string[] stringCollection = await Task.WhenAll(taskCollection);

    IEnumerable<string> result3 = stringCollection.Where(s => s.Contains("1"));
    WriteLine(string.Join(", ", result3));
    // 出力：1, 10, 11, 12
  }



  static void Main(string[] args)
  {
    // ↓これはコンパイルエラー（ラムダ式の返す型がTask<bool>のため）
    //var result 
    //  = Enumerable.Range(1, 12)
    //              .Where(async n => (await NumToStringAsync(n)).Contains("1"));

    // どうしてもという場合は、ラッパーを作って同期処理にする
    var result1
      = Enumerable.Range(1, 12)
                  .Where(n => NumToString(n).Contains("1"));
    WriteLine(string.Join(", ", result1));
    // 出力：1, 10, 11, 12

    // 必要ならPLINQで高速化
    var result2
      = Enumerable.Range(1, 12).AsParallel()
                  .Where(n => NumToString(n).Contains("1"));
    WriteLine(string.Join(", ", result2));
    // 出力例：1, 11, 10, 12


    // Select拡張メソッドの中でasync/awaitを使う
    SelectSample();


#if DEBUG
    ReadKey();
#endif
  }
}
