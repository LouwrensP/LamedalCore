using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Extention)]
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class Types_Dictionary_Shortcut
    {
        /// <summary>
        /// Return the keys and values of the dictionary.
        /// </summary>
        /// <param name="dictionary">The dictionary dictionary</param>
        /// <param name="keys">Return the keys list</param>
        /// <param name="values">Return the values list</param>
        /// <code>CTIN_Transformation;</code>
        public static void zDictionary_KeysAndValues<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, out List<TKey> keys, out List<TValue> values)
        {
            LamedalCore_.Instance.Types.Dictionary.KeysAndValues(dictionary, out keys, out values);
        }

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
        public static void zDictionary_AddSafe<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue newValue,
            enCompare_DuplicateError onError = enCompare_DuplicateError.Ignore)
        {
            LamedalCore_.Instance.Types.Dictionary.Key_AddSafe(dictionary, key, newValue, onError);
        }

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
            ///// <code>CTIN_Transformation;</code>
            //public static TValue zDictionary_GetOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue missingValue)
            //{
            //    return  LamedalCore_.Instance.Types.Dictionary.Key_GetOrCreate(dictionary, key, missingValue);
            //}


        }
}
