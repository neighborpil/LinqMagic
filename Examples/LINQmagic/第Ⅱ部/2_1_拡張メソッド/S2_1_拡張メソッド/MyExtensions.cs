using System;

namespace StringExtension
{
  public static class MyExtensions
  {
    public static string Reverse(this string s)
    {
      char[] c = s.ToCharArray(); //stringをcharの配列に書き出し、
      Array.Reverse(c); //配列の順序を逆転
      return new string(c); //charの配列から文字列を生成して返す
    }

    public static string Head(this string s, int maxLength)
    {
      if (s == null)
        return s;
      if (s.Length <= maxLength)
        return s;
      return s.Substring(0, maxLength);
    }
  }
}
