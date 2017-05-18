using System.Collections.Generic;
using System.Linq;
using static System.Console;


public class Point
{
  public int x { get; set; }
  public int y { get; set; }
}

class Program
{
  static void Main(string[] args)
  {
    // y = x ^ 2 (x,yは整数)となる点の並びを作る

    // オブジェクト初期化子を利用する
    IEnumerable<Point> points1
      = Enumerable.Range(0, 3)
                  .Select(n => new Point { x = n, y = n * n,});
    foreach (var p in points1)
      WriteLine($"x={p.x}, y={p.y}");

    // オブジェクト初期化子を利用しない(式木には使えない)
    IEnumerable<Point> points2
      = Enumerable.Range(0, 3)
                  .Select(n =>
                          {
                            var p = new Point();
                            p.x = n;
                            p.y = n * n;
                            return p;
                          });
    foreach (var p in points2)
      WriteLine($"x={p.x}, y={p.y}");
    // 出力：
    // x=0, y=0
    // x = 1, y = 1
    // x = 2, y = 4

#if DEBUG
    ReadKey();
#endif
  }
}
