using System.ComponentModel;

namespace StdExt.Text
{
    public static class StringExtender
    {
        /// <summary>
        /// Pythonのような負値を取るSubstring
        /// </summary>
        /// <param name="s">対象の文字列</param>
        /// <param name="begin">開始地点</param>
        /// <param name="end">終了地点</param>
        /// <returns></returns>
        public static string Substr(this string s, int begin, int end)
        {
            begin = begin < 0 ? s.Length + begin : begin;
            end = end < 0 ? s.Length + end : end;
            return s.Substring(begin, end);
        }

        /// <summary>
        /// Pythonのような連結メソッド
        /// </summary>
        /// <example>
        /// <code>
        /// var list = new List<string>(){"aaa","bbb","ccc"};
        /// ",".Join( list ) => aaa,bbb,ccc
        /// </code>
        /// </example>
        /// <typeparam name="T"></typeparam>
        /// <param name="s">連結子</param>
        /// <param name="e">連結されるインスタンス</param>
        /// <returns></returns>
        public static string Join<T>(this string s, IEnumerable<T> e)
        {
            return string.Join(s, e);
        }

        public static string? JoinSafe<T>(this string s, IEnumerable<T> e)
        {
            try
            {
                return string.Join(s, e);
            }
            catch
            {
                return null;
            }
        }
    }
}
