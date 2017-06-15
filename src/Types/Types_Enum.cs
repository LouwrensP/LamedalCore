using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, DefaultType = typeof(Enum), GroupName = "Enum", ShortcutClass = "Enum_Blueprint")]
    public sealed class Types_Enum
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>
        /// Test if type is IsEnumerable.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        [Pure]
        public bool IsEnumerable(Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();
            return typeInfo.IsEnum;

            //if (type.ReflectedType == null) return type.IsEnum;
            //return type.ReflectedType == typeof(IsEnumerable);
        }

        /// <summary>
        /// Convert enumeral string value to the enumeral type value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value</param>
        /// <param name="ignoreCase">Ignore case indicator. Default value = false.</param>
        /// <param name="ignoreStrPart">The ignore string part.</param>
        /// <returns>
        /// T
        /// </returns>
        /// <code Shortcut="Enums"></code>
        public T Str_2EnumValue<T>(string value, bool ignoreCase = false, string ignoreStrPart = "")
        {
            var result = Str_2EnumValue(value, typeof(T), ignoreCase, ignoreStrPart);
            // if (result == null) return default(T);  // Unable to create unit test for this condition.

            return (T)result;
        }

        /// <summary>
        /// Convert the object value to Enumeral value.
        /// </summary>
        /// <param name="objectValue">The object value</param>
        /// <param name="type">The type</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <param name="ignoreStrPart">The ignore string part.</param>
        /// <returns>
        /// object
        /// </returns>
        public object Object_2EnumValue(object objectValue, Type type, bool ignoreCase = false, string ignoreStrPart = "")
        {
            string objectStr = objectValue.zObject().AsStr();
            return Str_2EnumValue(objectStr, type, ignoreCase, ignoreStrPart);
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
        public object Str_2EnumValue(string value, Type type, bool ignoreCase = false, string ignoreStrPart = "")
        {
            // Check parameters
            if (ignoreStrPart != "") value = value.Replace(ignoreStrPart, "");
            if (value != null && value.Contains("."))
            {
                var valueOld = value;
                var typeName = valueOld.zvar_Id(".");
                value = valueOld.zvar_Value(".");
                if (typeName != type.Name) throw new ArgumentException($"Error! '{value}' is not part of '{type.Name}'.", nameof(value));
            }

            // Try the conversion
            try
            {
                var result = Enum.Parse(type, value, ignoreCase);
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                var typeName = type.ToString();
                var errMsg = "ERROR: Value '{0}' was not found in type {1}".zFormat(value, typeName);
                e.zException_Show(errMsg, enCode_ExceptionAction.reThrowError);
            }
            return null;
            //var result2 = Convert.ChangeType(null, type);
            //return result2;
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
        /// <code>CTIM_Generation;</code>
        [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
        public void enum_2IList(Type enumToConvert, IList list, bool clearList = true, string prefix = "", string postfix = "", string replaceUnderscoreWith = "_")
        {
            //=================
            // Generated @ 2015/02/03
            // Generated from 'Blueprint.Rules.Types.Copy_To'() -> the parameter order was changed to ensure better MTIN results after transformations.
            enum_2IList(list, enumToConvert, clearList, prefix, postfix, replaceUnderscoreWith);
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
        [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
        public void enum_2IList(IList list, Type enumToConvert, bool clearList = true, string prefix = "", string postfix = "", string replaceUnderscoreWith = "_")
        {
            _lamed.Types.List.Convert.IList_FromEnum(list, enumToConvert, clearList, prefix, postfix, replaceUnderscoreWith);
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
        public string[] enum_2ArrayStr(Type enumToConvert, string prefix = "", string postfix = "", string replaceUnderscoreWith = "_")
        {
            var list = new List<string>();
            enum_2IList(list, enumToConvert, false, prefix, postfix, replaceUnderscoreWith);
            return list.ToArray();
        }

        /// <summary>
        /// Function to get the value of the enumerator.
        /// </summary>
        /// <param name="enumValue">The enumber</param>
        /// <returns>string</returns>
        public string enum_Description(Enum enumValue)
        {
            // Add [Description("")] flag to enumeral

            Type enumType = enumValue.GetType();
            string enumStr = enumValue.ToString();
            FieldInfo fieldInfo = enumType.GetRuntimeField(enumStr);
            Type attributeType = typeof(BlueprintData_DescriptionAttribute);
            var attributes = (BlueprintData_DescriptionAttribute[])fieldInfo.GetCustomAttributes(attributeType, false);

            return (attributes.Length > 0) 
                        ? attributes[0].Description 
                        : enumValue.ToString();
        }


        #region Flag_IsSet

        /// <summary>
        /// Determines whether the bit field are set in the 
        /// current instance.
        /// </summary>
        public bool Flag_IsSet(Enum value, Enum flag1)
        {
            return value.HasFlag(flag1);
        }

        /// <summary>
        /// Determines whether any of the given bit fields are set in the
        /// current instance.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <param name="andEvaluation">if set to <c>false</c> then check of any flag.If set to <c>true</c> tests for all values.</param>
        /// <param name="enumFlags">The enum value.</param>
        /// <returns></returns>
        public bool Flag_IsSet(Enum enumValue, bool andEvaluation = false, params Enum[] enumFlags)
        {
            bool result;
            if (andEvaluation)
            {
                // And ]========================
                result = true;
                foreach (Enum enum1 in enumFlags)
                {
                    if (enumValue.HasFlag(enum1) == false)
                    {
                        result = false;
                        break;  // <------------------------------------------
                    }
                }
            }
            else
            {
                // Or ]==========================
                result = false;
                foreach (Enum enum1 in enumFlags)
                {
                    if (enumValue.HasFlag(enum1))
                    {
                        result = true;
                        break; // <------------------------------------------
                    }
                }  
            }
            return result;

        }
        #endregion

        /// <summary>
        /// Returns a sequence of the enumeration members that are flagged
        /// in the given enumeration value.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// <typeparam name="T"/> is not an enumeration.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="value"/> argument is not an instance of 
        /// the enumeration <typeparamref name="T"/>.
        /// </exception>
        public IEnumerable<T> Flags<T>(Enum value)
        {

            var type = value.GetType();
            var typeInfo = type.GetTypeInfo();

            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new NotSupportedException(string.Format(
                    @"{0} is not an enumeration and therefore an invalid type argument for {1}.",
                    typeof(T), "Flags"));
            }

            TypeInfo typeInfoTest = typeof (T).GetTypeInfo();
            if (!typeInfoTest.IsAssignableFrom(typeInfo)) throw new ArgumentException(null, "value");

            return typeInfo.IsDefined(typeof(FlagsAttribute), false)
                 ? from Enum flag in Enum.GetValues(type)
                   where value.HasFlag(flag)
                   select (T)(object)flag
                 : Enum.IsDefined(type, value)
                 ? Enumerable.Repeat((T)(object)value, 1)
                 : Enumerable.Empty<T>();
        }

        /// <summary>
        /// Add a flag to an enum
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Flag_Add<T>(Enum type, T value)
        {
            T result = default(T);
            var underlyingType = Enum.GetUnderlyingType(value.GetType());
            try
            {
                if (underlyingType == typeof(int))
                {
                    result =(T)(object)(((int)(object)type | (int)(object)value));
                }
                else if (underlyingType == typeof(uint))
                {
                    result = (T)(object)(((uint)(object)type | (uint)(object)value));
                }
            } 
            catch (Exception ex)
                  {ex.zException_Show($"Could not append value '{value}' to enumerated type 'typeof(T).Name)'.");}
            return result;
        }

        /// <summary>
        /// Remove a flag from an enum type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Flag_Remove<T>(Enum type, T value)
        {
            T result = default(T);
            var underlyingType = Enum.GetUnderlyingType(value.GetType());
            try
            {
                if (underlyingType == typeof(int))
                {
                    result = (T)(object)(((int)(object)type & ~(int)(object)value));
                }
                else if (underlyingType == typeof(uint))
                {
                    result = (T)(object)(((uint)(object)type & ~(uint)(object)value));
                }
            }
            catch (Exception ex)
                  {ex.zException_Show($"Could not remove value '{value}' from enumerated type '{typeof(T).Name}'.");}

            return result;
        }
    }
}
