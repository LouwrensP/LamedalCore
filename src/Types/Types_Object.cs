using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types
{
    /// <summary>
    /// Is comparisons 
    /// private readonly Types_Is Is = Blueprint_.Instance.Types.Is;
    /// </summary>
    /// <code>CTI;</code>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class Types_Object
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>Test if a value is betweens the start and end values.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The actual.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <returns></returns>
        public bool Between<T>(T actual, T lower, T upper) where T : IComparable<T>
        {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) <= 0;
        }

        /// <summary>Cast object to T.</summary>
        /// <param name="Object">The objectect</param>
        /// <returns>T</returns>
        public T CastTo<T>(object Object)
        {
            return (T)Object;
        }

        /// <summary>Cast object to type.</summary>
        /// <param name="Object">The objectect</param>
        /// <param name="type">The type</param>
        /// <returns>object</returns>
        public object CastTo(object Object, Type type)
        {
            return Convert.ChangeType(Object, type);
        }

        /// <summary>Use default comparison between generic types.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public bool Compare<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }

        /// <summary>Creates type T.</summary>
        public T Create<T>(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }

        /// <summary>
        /// Default value for the type.
        /// </summary>
        /// <param name="t">The type</param>
        /// <returns>object</returns>
        public object DefaultValue(Type t)
        {
            if (t.GetTypeInfo().IsValueType) return Activator.CreateInstance(t);

            return null;
        }

        /// <summary>
        /// Default value for the type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T DefaultValue<T>()
        {
            return default(T);
        }

        /// <summary>
        /// Determines whether the value is part of a list.
        /// </summary>
        /// <param name="val">The value</param>
        /// <param name="values">The values optional array</param>
        /// <returns>bool</returns>
        public bool In<T>(T val, params T[] values) where T : struct
        {
            return values.Contains(val);
        }

        /// <summary>Determines whether the specified object is a class.</summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        public bool IsClass(object Object)
        {
            Type type = Object.GetType();
            TypeInfo typeInfo = type.GetTypeInfo();
            return typeInfo.IsClass;
        }

        /// <summary>
        /// Test if the object is a complex type like class, array, dictionary, list or struct.
        /// </summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        [Pure]
        public bool IsComplexType(object Object)
        {
            Type type = Object.GetType();
            TypeInfo typeInfo = type.GetTypeInfo();

            return !IsSimpleType(type)
                   && (typeInfo.IsClass
                       || type.IsArray
                       || IsIDictionary(Object)
                       || IsIList(Object)
                       || IsStruct(Object)
                       );
        }

        /// <summary>
        /// Is the type a dictionary.
        /// </summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        [Pure]
        public bool IsIDictionary(object Object)
        {
            Type type = Object.GetType();
            var typeInfo = type.GetTypeInfo();
            return (typeof(IDictionary).GetTypeInfo().IsAssignableFrom(typeInfo));
        }

        /// <summary>Determines whether two objects are equal using Json serialisation.</summary>
        /// <param name="Object1">The first object</param>
        /// <param name="Object2">The second object</param>
        /// <param name="errorMsg">The error message</param>
        /// <returns>bool</returns>
        public bool IsEqual(object Object1, object Object2, out string errorMsg)
        {
            return _lamed.lib.IO.Json.Object_IsEqual(Object1, Object2, out errorMsg);
        }

        /// <summary>
        /// Determines whether the type is IList .
        /// </summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        [Pure]
        public bool IsIList(object Object)
        {
            var typeInfo = Object.GetType().GetTypeInfo();
            return (typeof(IList).GetTypeInfo().IsAssignableFrom(typeInfo));
        }

        /// <summary>
        /// Return true if object is number.
        /// </summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        [Pure]
        public bool IsNumber(object Object)
        {
            if (Object is int || Object is long || Object is decimal || Object is double) return true;
            return false;
        }

        /// <summary>
        /// Determines whether the specified type is simple type.
        /// Primitive types is Boolean, Byte, SByte, Int16, UInt16, Int32, UInt32, Int64, UInt64, IntPtr, UIntPtr, Char, Double, Single, DateTime, decimal, string, Guid
        /// </summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        [Pure]
        public bool IsSimpleType(object Object)
        {
            if (Object == null) return false;

            Type type = Object.GetType();
            TypeInfo typeInfo = type.GetTypeInfo();

            if (typeInfo.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>))) type = Nullable.GetUnderlyingType(type);

            return typeInfo.IsPrimitive
                   || type == typeof(DateTime)
                   || type == typeof(decimal)
                   || type == typeof(string)
                   || type == typeof(Guid);
        }

        /// <summary>
        /// Test if the specified object is a string.
        /// </summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        public bool IsString(object @Object)
        {
            var value = @Object is string;
            return value;
        }

        #region IsNull

        /// <summary>
        /// Check if Objects is null.
        /// </summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        public bool IsNull(object Object)
        {
            string errorMsg = "";
            return IsNull(Object, out errorMsg, errorMsg, false);
        }

        /// <summary>
        /// Check if Objects is null.
        /// </summary>
        /// <param name="Object">The object.</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <param name="defaultErrorMsg">The default error MSG.</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        /// <returns></returns>
        public bool IsNull(object Object, out string errorMsg, string defaultErrorMsg = "Error! object == null.", bool showError = true)
        {
            if (!_lamed.Types.Test.IsValidStr(defaultErrorMsg)) defaultErrorMsg = "";

            //.if (Object == null || Word_FromAbbreviation.IsDBNull(Object))
            var result = false;
            if (Object == null) result = true;
            else
            {
                // Check for null strings
                var resultStr = Object as string;
                if (resultStr != null)
                {
                    if (resultStr == "\u0002" || resultStr == "\0") result = true;
                }
            }
             
            if (result)
            {
                errorMsg = defaultErrorMsg;
                if (errorMsg != "" && showError) _lamed.Exceptions.Show(errorMsg);
                
            } else errorMsg = "";

            return result;

        }

        /// <summary>Check if Objects is null.</summary>
        /// <param name="Object">The object.</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <returns></returns>
        [Pure]
        public bool IsNull(object Object, bool showError, string errorMsg = "Error! object == null.")
        {
            string notUsed;
            return IsNull(Object, out notUsed, errorMsg, showError);
        }

        #endregion

        /// <summary>
        /// Determines whether the specified type is structure.
        /// </summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        [Pure]
        public bool IsStruct(object Object)
        {
            TypeInfo typeInfo = Object.GetType().GetTypeInfo();
            return typeInfo.IsValueType && !IsSimpleType(Object);
        }
    }
}
