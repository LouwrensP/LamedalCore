using System;
using System.Collections;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [Test_IgnoreCoverage(enTestIgnore.MethodIsShortCut)]
    public static class Types_Enum_Shortcut
    {
        
        /// <summary>
        /// Determines whether the value is part of an enumeral list.
        /// </summary>
        /// <param name="val">The value</param>
        /// <param name="values">The values optional array</param>
        /// <returns>bool</returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zIn<T>(this T val, params T[] values) where T : struct
        {
            return LamedalCore_.Instance.Types.Object.In(val, values);
        }

        /// <summary>
        /// Determines whether any of the given bit fields are set in the
        /// current instance.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <param name="andEvaluation">if set to <c>false</c> then check of any flag.If set to <c>true</c> tests for all values.</param>
        /// <param name="enumFlags">The enum value.</param>
        /// <returns></returns>
        public static bool zFlag_IsSet(this Enum enumValue, bool andEvaluation = false, params Enum[] enumFlags)
        {
            return LamedalCore_.Instance.Types.Enum.Flag_IsSet(enumValue, andEvaluation, enumFlags);
        }

        /// <summary>
        /// Determines whether the bit field are set in the 
        /// current instance.
        /// </summary>
        /// <code>CTIN_Transformation;</code>
        public static bool zFlag_IsSet(this Enum value, Enum flag1)
        {
            return LamedalCore_.Instance.Types.Enum.Flag_IsSet(value, flag1);
        }

        /// <summary>
        /// Converts enumeral to string array.
        /// </summary>
        /// <param name="enumToConvert">Enumeral to converts the</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="postfix">The postfix.</param>
        /// <param name="replaceUnderscoreWith">The replace underscore with.</param>
        /// <returns>
        /// string[]
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static string[] zEnum_To_StrArray(this Type enumToConvert, string prefix = "", string postfix = "", string replaceUnderscoreWith = "_")
        {
            return LamedalCore_.Instance.Types.Enum.enum_2ArrayStr(enumToConvert, prefix, postfix, replaceUnderscoreWith);
        }
        /// <summary>
        /// Converts enumeral to IList. <br></br>
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="enumToConvert">typeof(myEnum) <br></br> The enum to convert.</param>
        /// <param name="clearList">if set to <c>true</c> [clear list].</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="postfix">The postfix.</param>
        /// <param name="replaceUnderscoreWith">The replace underscore with.</param>
        /// <code Shortcut="Enums" GenerateParameter1="enumToConvert"></code>
        /// <code>CTIN_Transformation;</code>
        public static void zEnum_To_IList(this IList list, Type enumToConvert, bool clearList = true, string prefix = "", string postfix = "", string replaceUnderscoreWith = "_")
        {
            LamedalCore_.Instance.Types.Enum.enum_2IList(list, enumToConvert, clearList, prefix, postfix, replaceUnderscoreWith);
        }
        /// <summary>
        /// Converts enumeral to IList. <br></br>
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="enumToConvert">typeof(myEnum) <br></br> The enum to convert.</param>
        /// <param name="clearList">if set to <c>true</c> [clear list].</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="postfix">The postfix.</param>
        /// <param name="replaceUnderscoreWith">The replace underscore with.</param>
        /// 
        /// <code>CTIN_Transformation;</code>
        public static void zEnum_To_IList(this Type enumToConvert, IList list, bool clearList = true, string prefix = "", string postfix = "", string replaceUnderscoreWith = "_")
        {
            LamedalCore_.Instance.Types.Enum.enum_2IList(enumToConvert, list, clearList, prefix, postfix, replaceUnderscoreWith);
        }
        /// <summary>
        /// Word_FromAbbreviation enumeral string value to the enumeral type value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value</param>
        /// <param name="ignoreCase">Ignore case indicator. Default value = false.</param>
        /// <param name="removeStr">The remove string.</param>
        /// <returns>
        /// T
        /// </returns>
        /// <code Shortcut="Enums"></code>
        /// <code>CTIN_Transformation;</code>
        public static T zEnum_To_EnumValue<T>(this string value, bool ignoreCase = false, string removeStr = "")
        {
            return LamedalCore_.Instance.Types.Enum.Str_2EnumValue<T>(value, ignoreCase, removeStr);
        }
        /// <summary>
        /// Word_FromAbbreviation the object value to Enumeral value.
        /// </summary>
        /// <param name="value">The object string.</param>
        /// <param name="type">The type</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <param name="ignoreStrPart">The ignore string part.</param>
        /// <returns>
        /// object
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static object zEnum_To_EnumValue(this string value, Type type, bool ignoreCase = false, string ignoreStrPart = "")
        {
            return LamedalCore_.Instance.Types.Enum.Str_2EnumValue(value, type, ignoreCase, ignoreStrPart);
        }
        /// <summary>
        /// Function to get the description value of the enumerator.
        /// </summary>
        /// <param name="value">The enumber</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zTo_Description(this Enum value)
        {
            return LamedalCore_.Instance.Types.Enum.enum_Description(value);
        }
    }
}
