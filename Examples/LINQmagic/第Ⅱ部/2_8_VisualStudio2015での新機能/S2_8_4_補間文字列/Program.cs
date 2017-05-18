using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    int n = 1;

    // 従来の書き方
    WriteLine(string.Format("従来の書き方 {1}, {0}", n + 2, n + 1));
    // 出力：従来の書き方 2, 3
    // ※ 序数のアンマッチや過不足のミスをしやすい

    // String interpolation
    // 文字列の前に「$」記号を付け、「{}」内に変数や式を書く
    WriteLine($"String interpolation {n + 1}, {n + 2}");
    // 出力：String interpolation 2, 3

    // 書式指定は従来通り
    // 「{」を出力するには「{{」と書く（「}」も同様）
    // 文字列の前の「@」（逐語的リテラル文字列）との併用も可能
    WriteLine(
$@"{{n}}→{n:000}
{{n+1}}→{n+1:000}"
    );
    // 出力：
    // {n}→001
    // {n+1}→002

    // 式中の「:」が書式指定と解釈されるのを防ぐには、式を括弧で囲む
    WriteLine($"{(n==1 ? 10 : 20):000}");
    // 出力：010
    // ※ この例では最初の「:」は三項演算子、二つめは書式指定と解釈される


#if DEBUG
    ReadKey();
#endif
  }
}
