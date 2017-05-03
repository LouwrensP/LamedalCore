using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.Types
{
    /// <summary>
    /// 
    /// </summary>
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Action)]
    public sealed class Types_Dictionary
    {
        ///// <summary>
        ///// Returns the value associated with the specified key if there
        ///// already is one, or inserts the specified value and returns it.
        ///// </summary>
        ///// <typeparam name="TKey">Type of key</typeparam>
        ///// <typeparam name="TValue">Type of value</typeparam>
        ///// <param name="dictionary">Dictionary to access</param>
        ///// <param name="key">Key to lookup</param>
        ///// <param name="missingValue">Value to use when key is missing</param>
        ///// <returns>Existing value in the dictionary, or new one inserted</returns>
        //public TValue Key_GetOrCreate<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key, TValue missingValue)
        //{
        //    TValue result;
        //    if (dictionary.TryGetValue(key, out result) == false)
        //    {
        //        result = missingValue;
        //        dictionary[key] = result;
        //    }
        //    return result;
        //}

        /// <summary>
        /// Returns the value associated with the specified key if there
        /// already is one, or inserts the specified value and returns it.
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <typeparam name="TValue">Type of value</typeparam>
        /// <param name="dictionary">Dictionary to access</param>
        /// <param name="key">Key to lookup</param>
        /// <param name="newValue">Value to use when key is missing</param>
        /// <param name="onError">The on error.</param>
        public void Key_AddSafe<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key, TValue newValue, 
                    enDuplicateError onError = enDuplicateError.Ignore)
        {
            TValue result;
            if (dictionary.TryGetValue(key, out result) == true)
            {
                switch (onError)
                {
                    case enDuplicateError.Replace: dictionary[key] = newValue; return; // <============================
                    case enDuplicateError.Ignore: return;
                    case enDuplicateError.Error: throw new ArgumentException("newValue");
                }
            }
            dictionary.Add(key, newValue);
        }

        /// <summary>
        /// Return the keys and values of the dictionary.
        /// </summary>
        /// <param name="dictionary">The dictionary dictionary</param>
        /// <param name="keys">Return the keys list</param>
        /// <param name="values">Return the values list</param>
        public void KeysAndValues<TKey, TValue>(IDictionary<TKey, TValue> dictionary, out List<TKey> keys, out List<TValue> values)
        {
            keys = dictionary.Keys.ToList();
            values = dictionary.Values.ToList();
        }

        /// <summary>Sorts the dictionary on values.</summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <returns></returns>
        public IOrderedEnumerable<KeyValuePair<TKey, TValue>> SortOnValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary, bool ascending = true)
        {
            IOrderedEnumerable<KeyValuePair<TKey, TValue>> result;
            if (ascending)
                result = from entry in dictionary orderby entry.Value ascending select entry;
            else result = from entry in dictionary orderby entry.Value descending select entry;

            return result;
        }

        /// <summary>Create a Dictionary that ignore the case of the key.</summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns></returns>
        public IDictionary<string, TValue> Create_IgnoreCase<TValue>(IDictionary<string, TValue> dictionary = null)
        {
            if (dictionary == null) return new Dictionary<string, TValue>(StringComparer.OrdinalIgnoreCase);

            return new Dictionary<string, TValue>(dictionary, StringComparer.OrdinalIgnoreCase);
        }

        // Returns a new dictionary of this ... others merged leftward.
        // Keeps the type of 'this', which must be default-instantiable.
        // Example: 
        //   result = map.MergeLeft(other1, other2, ...)
        public IDictionary<K, V> Merge<K, V>(IDictionary<K, V> me, params IDictionary<K, V>[] others)
        {
            var newMap = new Dictionary<K, V>();
            foreach (IDictionary<K, V> src in (new List<IDictionary<K, V>> { me }).Concat(others))
            {
                // ^-- echk. Not quite there type-system.
                foreach (KeyValuePair<K, V> p in src)
                {
                    newMap[p.Key] = p.Value;
                }
            }
            return newMap;
        }

        /// <summary>Convert object to dictionary.</summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        public Dictionary<string, object> Object_ToDictionary(object Object)
        {
            var dictionary = new Dictionary<string, object>();

            foreach (var propertyInfo in Object.GetType().GetTypeInfo().GetProperties())
            {
                if (propertyInfo.GetIndexParameters().Length == 0)
                {
                    dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(Object, null));
                }
            }

            return dictionary;
        }

        /// <summary>Converts a string dictionary into XML.</summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="replaceSpaceWith">The replace space with.</param>
        /// <returns></returns>
        public string XML_FromDictionary(IDictionary<string, string> dictionary, string replaceSpaceWith = "_")
        {
            XElement element = new XElement("root", dictionary.Select(x => new XElement(x.Key.Replace(" ", replaceSpaceWith), x.Value)));
            return element.ToString();
        }

        /// <summary>Converts XML to a string dictionary.</summary>
        /// <param name="xml">The XML.</param>
        /// <param name="restoreSpaceFrom">The restore space from.</param>
        /// <returns></returns>
        public IDictionary<string, string> XML_ToDictionary(string xml, string restoreSpaceFrom = "_")
        {
            XElement rootElement = XElement.Parse(xml);
            var dictionary = new Dictionary<string, string>();
            foreach (var element in rootElement.Elements())
            {
                dictionary.Add(element.Name.LocalName.Replace(restoreSpaceFrom, " "), element.Value);
            }
            return dictionary;
        }
    }
}
