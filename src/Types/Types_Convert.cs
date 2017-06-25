using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types
{
    /// <summary>
    /// Do type conversions; group=As;
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class Types_Convert
    {
        private readonly Types_Object _object = LamedalCore_.Instance.Types.Object;
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        #region bool

        /// <summary>
        /// Determines whether the string value is a true or false bool value.
        /// </summary>
        /// <param name="strValue">The string value</param>
        /// <returns>bool</returns>
        [Pure]
        public bool Bool_FromStr(string strValue)
        {
            // || Word_FromAbbreviation.IsDBNull(strValue)
            if (string.IsNullOrEmpty(strValue)  || strValue == "0") return false;
            if (strValue == "1") return true;
            return Convert.ToBoolean(strValue);
        }

        /// <summary>
        /// Determines wheter the object is a true or false bool value.
        /// </summary>
        /// <param name="Object">The object</param>
        /// <returns>bool</returns>
        [Pure]
        public bool Bool_FromObj(object Object)
        {
            if (this._object.IsNull(Object)) return false;

            var result = false; // Default value
            try
            {
                result = Convert.ToBoolean(Object);
            }
            catch (Exception)
            {
                try
                {
                    var strValue = Str_FromObj(Object);
                    result = Bool_FromStr(strValue);
                }
                catch (Exception ex)
                {
                    ex.zLogLibraryMsg();
                    throw;
                }
            }
            return result;
        }

        /// <summary>
        /// Function to convert object to nullable bool.
        /// </summary>
        /// <param name="Object">The object</param>
        /// <param name="nullValue">The null value setting. Default value = null.</param>
        /// <returns>bool?</returns>
        [Pure]
        public bool? Bool_FromObj2(object Object, bool? nullValue = null)
        {
            if (this._object.IsNull(Object) || Str_FromObj(Object) == "") return nullValue;

            return Bool_FromObj(Object);
        }

        #endregion

        /// <summary>Function to convert object value to date.</summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        [Pure]
        public DateTime DateTime_FromObj(object Object)
        {
            if (this._object.IsNull(Object)) return DateTime.MinValue;
            if (Object is DateTime) return Convert.ToDateTime(Object);

            DateTime result; // = _lamed.Types.DateTime.null_;
            try
            {
                result = Convert.ToDateTime(Object);
            }
            catch (Exception e)
            {
                var ex = new FormatException("Error! Unable to convert object to DateTime!",e);
                ex.zLogLibraryMsg();
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Function to convert an object to double.
        /// </summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        [Pure]
        public double Double_FromObj(object Object)
        {
            return Convert.ToDouble(Object);
        }

        /// <summary>
        /// Function to return a global unique identifier from the string value.
        /// </summary>
        /// <param name="strValue">The string value</param>
        /// <returns>Guid</returns>
        [Pure]
        public Guid Guid_FromStr(string strValue)
        {
            if (strValue == "-1" || strValue == "") return Guid.Empty;
            Guid guidValue;
            Guid.TryParse(strValue, out guidValue);
            return guidValue;
        }

        /// <summary>
        /// Function to return a global unique identifier from the object.
        /// </summary>
        /// <param name="Object">The object</param>
        /// <returns>Guid</returns>
        [Pure]
        public Guid Guid_FromObj(object Object)
        {
            if (_object.IsNull(Object)) return Guid.Empty;
            if (Object is Guid) return Guid.Parse(Object.ToString());
            return Guid.Empty;
        }

        #region Int

        /// <summary>
        /// Function to return int  from the string value.
        /// </summary>
        /// <param name="strValue">The string value</param>
        /// <param name="nullValue">The null value setting. Default value = 0.</param>
        /// <returns>int</returns>
        [Pure]
        public int Int_FromStr(string strValue, int nullValue = 0)
        {
            int iValue;
            var result = int.TryParse(strValue, out iValue);
            if (!result)
            {
                double dValue;
                result = double.TryParse(strValue, out dValue);
                if (result) iValue = (int)(dValue + 0.5);
            }

            return result ? iValue : nullValue;
        }

        /// <summary>
        /// Function to return int  from the string value.
        /// </summary>
        /// <param name="charValue">The string value</param>
        /// <returns>int</returns>
        [Pure]
        public int Int_FromChar(char charValue)
        {
            var result = (int)Char.GetNumericValue(charValue);
            return result;
        }

        /// <summary>
        /// Function to return int value from the object.
        /// </summary>
        /// <param name="Object">The object</param>
        /// <returns>int</returns>
        [Pure]
        public int Int_FromObj(object Object)
        {
            return (int)Int_FromObj2(Object, 0);
        }

        /// <summary>
        /// Function to return nullable int from the object.
        /// </summary>
        /// <param name="Object">The object</param>
        /// <param name="nullValue">The null value setting. Default value = null.</param>
        /// <returns>int?</returns>
        [Pure]
        public int? Int_FromObj2(object Object, int? nullValue = null)
        {
            if (this._object.IsNull(Object)) return nullValue;
            if (Object is bool) return (bool)Object ? 1 : 0;
            if (this._object.IsNumber(Object)) return Convert.ToInt32(Object); // Even doubles need to be converted to in
            if (Object is string) return Int_FromStr(Object.ToString());

            return nullValue;
        }

        #endregion


        #region Str

        /// <summary>
        /// Function to return string from the object.
        /// </summary>
        /// <param name="Object">The object</param>
        /// <param name="minWidth">The minimum width setting. Default value = 0.</param>
        /// <param name="fillchar">The fillchar setting. Default value = '0'.</param>
        /// <param name="zeroValue">The ero value setting. Default value = "0".</param>
        /// <returns>
        /// string
        /// </returns>
        [Pure]
        public string Str_FromObj(object Object, int minWidth = 0, char fillchar = '0', string zeroValue = "0")
        {
            var result = "";
            if (this._object.IsNull(Object) == false)
            {
                if (Object is string) result = Object as string;
                else if (Object is bool) result = Str_FromBool((bool)Object);
                else if (Object is int) result = Str_FromInt((int)Object);
                else if (Object is Enum)
                {
                    result = Object.ToString();
                    result = result.Replace("_", " ");
                }
                else if (Object is Type)
                {
                    if (typeof(string) == (Type)Object) return "string";
                    if (typeof(Enum) == (Type) Object) return "Enum";
                    return Object.ToString();
                }
                else if (Object is IList)
                {
                    //IList<string> list = _lamed.Types.List.Convert.IList_2IListT<string>((IList)Object);
                    result = "[" +_lamed.Types.List.String.ToString((IList)Object, ",") + "]";
                }
                else if (_lamed.Types.Object.IsClass(Object))
                {
                    var dict = _lamed.Types.Dictionary.Object_ToDictionary(Object);
                    var lines = dict.Select(x => $"{x.Key} = {x.Value.zObject().AsStr()}").ToList();
                    var str = lines.zTo_Str(", ");
                    return str;
                }
                else if (Object is DateTime)
                {
                    var dateValue = DateTime_FromObj(Object);
                    result = dateValue.ToString("yyyy-MM-dd");
                    var resultTime = dateValue.ToString("HH:mm:ss tt");
                    if (resultTime != "00:00:00 AM") result += " " + resultTime;
                }
                else
                {
                    result = Object.ToString();
                }
            }

            Str_Format(ref result, minWidth, fillchar, zeroValue);
            return result;
        }
        /// <summary>
        /// Function to return string  from the int value.
        /// </summary>
        /// <param name="intValue">The int value</param>
        /// <param name="minWidth">The minimum width setting. Default value = 0.</param>
        /// <param name="fillchar">The fillchar setting. Default value = &apos;0&apos;.</param>
        /// <param name="zeroValue">The ero value setting. Default value = &quot;0&quot;.</param>
        /// <returns>string</returns>
        [Pure]
        public string Str_FromInt(int intValue, int minWidth = 0, char fillchar = '0', string zeroValue = "0")
        {
            var result = intValue.ToString();
            Str_Format(ref result, minWidth, fillchar, zeroValue);
            return result;
        }

        /// <summary>
        /// Function to return string  from bool value indicator.
        /// </summary>
        /// <param name="boolValue">Bool_FromStr value indicator</param>
        /// <returns>string</returns>
        [Pure]
        public string Str_FromBool(bool boolValue)
        {
            return (boolValue) ? "true" : "false";
        }

        /// <summary>
        /// Format the string to number value.
        /// </summary>
        /// <param name="result">The result reference variable</param>
        /// <param name="minWidth">The minimum width setting. Default value = 0.</param>
        /// <param name="fillChar">The fill character setting. Default value = &apos;0&apos;.</param>
        /// <param name="zeroValue">The zero value setting. Default value = &quot;0&quot;.</param>
        public void Str_Format(ref string result, int minWidth = 0, char fillChar = '0', string zeroValue = "0")
        {
            if (zeroValue != "0" && result == "0") result = result.Replace("0", zeroValue); // Define the 0 char
            if (minWidth != 0) result = result.PadLeft(minWidth, fillChar); // Add the fill char
        }
        #endregion

        /// <summary>
        /// Converts the stringtype name to type.
        /// </summary>
        /// <param name="strType2">The string type</param>
        /// <returns>Type</returns>
        public Type Type_FromStr(string strType)
        {
            if (strType == "string") strType = "System.String";
            else if (strType.zIn("string", "Enum", "Exception", "Array")) strType = "System." + strType;
            else if (strType == "Assembly") return typeof(Assembly);

            var result = Type.GetType(strType);
            if (result == null)
            {
                var ex = new InvalidOperationException($"Error! Unable to find type '{strType}'.");
                ex.zLogLibraryMsg();
                throw ex;
            }
            return result;
        }

    }
}
