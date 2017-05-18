using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq; // Rxを使う
using System.Reactive.Concurrency; // Rxのスケジューラを使う
using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    // LINQ to Objectsのような使い方
    // ※「2-3-2.偶数だけを取り出す」と比較してみてください
    IObservable<int> result
      = Observable.Range(1, 10).Where(n => n % 2 == 0);
    // ※ 上のWhere拡張メソッドはRxのもの
    // IObservable<T>はToEnumerable拡張メソッドでIEnumerable<T>に変換できる
    foreach (int n in result.ToEnumerable())
      Write($"{n} ");
    // 出力：
    // 2 4 6 8 10

    WriteLine();

    // 最終段のforeachループを、RxではSubscribe拡張メソッドで行う
    // ※ Subscribeでは他に、例外発生時と完了時の処理を書ける
    Observable.Range(1, 10)
              .Where(n => n % 2 != 0)
              .Subscribe(n => Write($"{n} "));
    // 出力：
    // 1 3 5 7 9

    WriteLine();

    // Publishでデータの配信先を分配できる
    // ※ただし、この例のようにオンメモリのデータに対しては
    //   LINQを2度回す（下記）より遥かに遅い。
    (new int[] { -2, 1, 3 })
      .ToObservable()
      .Select(n =>
        {
          WriteLine($"Select {n}");
          return n * n;
        })
      .Publish(n => 
        n.Min().Zip(
          n.Max(), 
          (min, max) => new { Min=min, Max=max }))
      .Subscribe(
        a => WriteLine($"Min={a.Min}, Max={a.Max}")
      );
    // 出力：
    // Select -2
    // Select 1
    // Select 3
    // Min = 1, Max = 9

    // 上と同じことをLINQでやろうとすると…
    IEnumerable<int> squares
      =(new int[] { -2, 1, 3 })
        .Select(n =>
        {
          WriteLine($"Select {n}");
          return n * n;
        });
    WriteLine($"Min={squares.Min()}, Max={squares.Max()}");
    // 出力：
    // Select - 2
    // Select 1
    // Select 3
    // Select - 2
    // Select 1
    // Select 3
    // Min = 1, Max = 9
    // ※ Selectが2回ずつ実行されてしまう!

    WriteLine();


    // 時間軸に沿って発生するイベントを扱う例
    WriteLine($"START - {DateTimeOffset.Now:HH:mm:ss}");
    Observable.Timer(
                 TimeSpan.FromSeconds(3.0),
                 TimeSpan.FromSeconds(1.0)
               ) // 3秒後に動き始める、1秒間隔のタイマー
      .Take(3) // 最初の3個だけで終了
      //.ObserveOn(Scheduler.CurrentThread) // 実行スレッドの指定（旧来の書き方）
      .ObserveOn(CurrentThreadScheduler.Instance) // 実行スレッドの指定（新しい書き方）
      .Subscribe(
        // イベントごとの処理
        i => WriteLine(
          $"{i} - {DateTimeOffset.Now:HH:mm:ss}"),
        // 完了時の処理
        () => WriteLine(
          $"END - {DateTimeOffset.Now:HH:mm:ss}")
      );
    WriteLine("タイマーセット完了");
    // 出力例：
    // START - 16:37:00
    // タイマーセット完了
    // 0 - 16:37:03
    // 1 - 16:37:04
    // 2 - 16:37:05
    // END - 16:37:05

    ReadKey();
  }
}

