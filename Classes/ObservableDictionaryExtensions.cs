using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExileMaps.Classes
{
    public static class ObservableDictionaryExtensions
    {
        public static ObservableDictionary<TKey, TValue> ToObservableDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            var dictionary = new ObservableDictionary<TKey, TValue>();
            foreach (var item in source)
            {
                dictionary.Add(item.Key, item.Value);
            }
            return dictionary;
        }

        public static ObservableDictionary<TKey, TValue> ToObservableDictionary<TKey, TValue>(
            this IEnumerable<TValue> source, Func<TValue, TKey> keySelector)
        {
            var dictionary = new ObservableDictionary<TKey, TValue>();
            foreach (var item in source)
            {
                dictionary.Add(keySelector(item), item);
            }
            return dictionary;
        }
    }
}
