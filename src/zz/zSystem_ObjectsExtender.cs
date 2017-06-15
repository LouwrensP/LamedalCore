using System;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Connector)]
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public sealed class zSystem_ObjectsExtender
    {
        public readonly object Object;

        /// <summary>
        /// Initializes a new instance of the <see cref="zSystem_ObjectsExtender"/> class.
        /// </summary>
        /// <param name="object">The object.</param>
        public zSystem_ObjectsExtender(object @object)
        {
            Object = @object;
        }

        /// <summary>
        /// Check if Objects is null.
        /// </summary>
        /// <param name="errorMsg">The error MSG.</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        /// <returns></returns>
        public bool IsNull(string errorMsg = "", bool showError = false)
        {
            return LamedalCore_.Instance.Types.Object.IsNull(Object, showError, errorMsg);
        }

        #region Conversion "As"
        /// <summary>
        /// Word_FromAbbreviation object to string.
        /// </summary>
        /// <param name="minWidth">The minimum width.</param>
        /// <param name="fillchar">The fill char.</param>
        /// <param name="zeroValue">The zero value.</param>
        /// <param name="returnNullIfObject">if set to <c>true</c> [return null if object].</param>
        /// <returns></returns>
        public string AsStr(int minWidth = 0, char fillchar = '0', string zeroValue = "0", bool returnNullIfObject = false)
        {
            return LamedalCore_.Instance.Types.Convert.Str_FromObj(Object, minWidth, fillchar, zeroValue);
        }

        /// <summary>
        /// Word_FromAbbreviation object to nullable int.
        /// </summary>
        /// <returns></returns>
        [Pure]
        public int AsInt()
        {
            return LamedalCore_.Instance.Types.Convert.Int_FromObj(Object);
        }

        /// <summary>
        /// Word_FromAbbreviation object to nullable int?.
        /// </summary>
        /// <param name="nullValue">The null value.</param>
        /// <returns></returns>
        [Pure]
        public int? AsInt(int? nullValue)
        {
            return LamedalCore_.Instance.Types.Convert.Int_FromObj2(Object, nullValue);
        }

        /// <summary>
        /// Word_FromAbbreviation object to bool.
        /// </summary>
        /// <returns></returns>
        [Pure]
        public bool AsBool()
        {
            return LamedalCore_.Instance.Types.Convert.Bool_FromObj(Object);
        }

        /// <summary>
        /// Word_FromAbbreviation Object value to Date.
        /// </summary>
        /// <returns></returns>
        [Pure]
        public DateTime AsDateTime()
        {
            return LamedalCore_.Instance.Types.Convert.DateTime_FromObj(Object);
        }

        /// <summary>
        /// Function to convert an object to double.
        /// </summary>
        /// <returns></returns>
        [Pure]
        public double AsDouble()
        {
            return LamedalCore_.Instance.Types.Convert.Double_FromObj(Object);
        }
        #endregion

        /// <summary>
        /// Return true if object is number.
        /// </summary>
        /// <returns></returns>
        [Pure]
        public bool IsNumber()
        {
            return LamedalCore_.Instance.Types.Object.IsNumber(Object);
        }

        /// <summary>
        /// Check if Objects is null.
        /// </summary>
        /// <param name="errorMsg">The error MSG.</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        /// <returns></returns>
        [Pure]
        public bool IsObjectNull(string errorMsg = "", bool showError = false)
        {
            return LamedalCore_.Instance.Types.Object.IsNull(Object, showError, errorMsg);
        }

        /// <summary>
        /// Test if the specified object is a string.
        /// </summary>
        /// <returns></returns>
        public bool IsString()
        {
            return LamedalCore_.Instance.Types.Object.IsString(Object);
        }

        /// <summary>
        /// Function to add single quote string to the object.
        /// </summary>
        /// <param name="addN">Add n indicator. Default inputStr = false.</param>
        /// <returns>string</returns>
        public string SQL_Q(bool addN = false)
        {
            return LamedalCore_.Instance.Types.String.Quote.SQL_Q(Object, addN);
        }

        #region State

        /// <summary>
        /// Function to gets the methods state from the host.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="autoCreate">if set to <c>true</c> [automatic create].</param>
        /// <returns>
        /// object
        /// </returns>
        public T State_Get<T>(bool autoCreate = true)
        {
            return LamedalCore_.Instance.Types.Class.StateInfo.Key_Get<T>(Object, autoCreate);
        }

        /// <summary>
        /// Sets the methods state.
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="autoDispose">Automatic dispose indicator</param>
        public void State_Set(object value, bool autoDispose = false)
        {
            LamedalCore_.Instance.Types.Class.StateInfo.Key_Set(Object, value);
        }
        
        #endregion
    }
}
