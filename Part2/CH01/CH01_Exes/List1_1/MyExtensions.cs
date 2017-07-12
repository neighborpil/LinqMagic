using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class MyExtensions
    {
        /// <summary>
        /// 문자열 Reverse
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Reverse(this string s)
        {
            char[] c = s.ToCharArray(); // string을 char의 배열로 뽑아 낸다
            Array.Reverse(c);
            return new string(c);    //임시 구현
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
