using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace StdExt.Collections
{
    public static class GroupBy
    {
        public static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>(List<Dictionary<TKey, TValue>> list)
            where TKey : notnull
        {
            var result = new Dictionary<TKey, List<TValue>>();
            foreach (var dict in list)
            {
                foreach (var kvp in dict)
                {
                    if (!result.TryGetValue(kvp.Key, out var values))
                    {
                        values = new List<TValue>();
                        result[kvp.Key] = values;
                    }
                    values.Add(kvp.Value);
                }
            }

            return result;
        }
        // OrderedDictionary 版
        public static OrderedDictionary ToOrderedDictionary<TKey, TValue>(List<Dictionary<TKey, TValue>> list)
                    where TKey : notnull
        {
            var result = new OrderedDictionary();

            foreach (var dict in list)
            {
                foreach (var kvp in dict)
                {
                    if (!result.Contains(kvp.Key))
                    {
                        result[kvp.Key] = new List<TValue>();
                    }
                    ((List<TValue>)result[kvp.Key]!).Add(kvp.Value);
                }
            }

            return result;
        }
    }
}
