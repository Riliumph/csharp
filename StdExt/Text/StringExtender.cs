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
        public static string Substr(
            this string s,
            int? begin = null,
            int? end = null
        )
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            int from = begin ?? 0;
            int to = end ?? s.Length;

            if (from < 0)
            {
                from += s.Length;
                to += s.Length;
            }
            if (to < 0)
            {
                to += s.Length;
            }

            from = Math.Clamp(from, 0, s.Length);
            to = Math.Clamp(to, 0, s.Length);
            if (to < from)
            {
                return string.Empty;
            }
#if VERSION_LESSER_8
            return s.Substring(from, to - from);
#else
            return s[from..to];
#endif
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
