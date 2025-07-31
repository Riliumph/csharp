using System;
using System.Collections.Generic;
using System.Linq;

namespace StdExt.Enumerable
{
    public static class EnumerableExtender
    {
        /// <summary>
        /// IEnumerableが空もしくはnullである状態を検知します。
        /// </summary>
        /// <typeparam name="T">IEnumerable type</typeparam>
        /// <param name="instance">チェック対象</param>
        /// <returns>
        ///		<c>true</c> チェック対象がnull / empty
        ///		<c>false</c>チェック対象がそれ以外
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> instance)
        {
            if (instance == null)
            {
                return true;
            }
            // IEnumerable.Count() => O(n) / ICollection.Count =>O(1)
            if (instance is ICollection<T> collection)
            {
                return collection.Count < 1;
            }
            return !instance.Any();
        }
    }
}
