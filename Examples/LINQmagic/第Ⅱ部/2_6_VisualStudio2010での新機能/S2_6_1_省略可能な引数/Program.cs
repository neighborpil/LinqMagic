using System.Runtime.InteropServices;
using static System.Console;

class Program
{
  static int Increment1(int n, int step = 1)
  // 引数nは必須、引数stepは省略可能（この例では、省略時は1）
  // 省略可能な引数は、必須の引数の後ろにしか書けない
  {
    return n + step;
  }

  // 従来はOptional属性（System.Runtime.InteropServices名前空間）を使っていた
  static int Increment2(int n,
                        [Optional, DefaultParameterValue(1)] int step)
  {
    return n + step;
  }

  static void Main(string[] args)
  {
    // 引数をすべて指定
    int n1 = Increment1(1, 2);
    WriteLine($"Increment1(1, 2)={n1}");
    // 出力：
    // Increment1(1, 2)=3

    // 引数を省略
    int n2 = Increment1(1);
    WriteLine($"Increment1(1)={n2}");
    // 出力：
    // Increment1(1)=2

    // 従来の方法
    int n3 = Increment2(2);
    WriteLine($"Increment2(2)={n3}");
    // 出力：
    // Increment2(2)=3

#if DEBUG
    ReadKey();
#endif
  }
}
