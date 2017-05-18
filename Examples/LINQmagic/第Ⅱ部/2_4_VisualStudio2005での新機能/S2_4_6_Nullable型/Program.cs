using System;
using static System.Console;

class Program
{
  static void Main(string[] args)
  {
    // 整数のnull許容型を宣言し、123で初期化
    Nullable<int> num1 = 123;

    // 整数のnull許容型を宣言し、nullで初期化
    Nullable<int> num2 = null;

    // 「?」を使って省略表現（こちらが一般的）
    int? num3 =  null;

    // nullかどうかの判定
    if (num1.HasValue)
      WriteLine("num1はnullではありません");

    // 従来のようにnullと比較してもよい
    if (num2 == null)
      WriteLine("num2はnullです");

    // nullのときの置き換え
    int result1 = num1 ?? -1;
    int result2 = num2 ?? -1;
    WriteLine($"num1={result1}, num2={result2}");
    // 出力:
    // num1 = 123, num2 = -1

    // 「??」演算子は次の三項演算子を使ったコードと同じ
    int result3 = num3.HasValue ? num3.Value : -1;
    WriteLine($"num3={result3}");

    // 「??」演算子は従来の参照型にも使える
    string s4 = "abc";
    string s5 = null;
    string result4 = s4 ?? "(NULL)";
    string result5 = s5 ?? "(NULL)";
    WriteLine($"s4={result4}, s5={result5}");
    // 出力:
    // s4 = abc, s5 = (NULL)


#if DEBUG
    ReadKey();
#endif
  }
}
