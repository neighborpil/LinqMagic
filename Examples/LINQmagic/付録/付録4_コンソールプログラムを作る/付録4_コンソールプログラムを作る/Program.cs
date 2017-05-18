using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 付録4_コンソールプログラム
{
  class Program
  {
    static void Main(string[] args)
    {
      // コンソールのタイトルバーに文字列を設定する
      Console.Title = "My First Console Program";

      // コンソールに"Hello, console!"という文字列を出力する
      Console.WriteLine("Hello, console!");

#if DEBUG
      // キー入力を一つ読み取る（入力されるまで待機）
      Console.ReadKey();
#endif
    }
  }
}
