using System;
using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    WriteLine("Hello, using static!");
    // これは次と同じ
    Console.WriteLine("Hello, using static!");

#if DEBUG
    ReadKey();
#endif
  }
}
