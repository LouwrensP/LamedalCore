using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.Types.Class
{
    [Test_IgnoreCoverage(enCode_TestIgnore.ClassIsNodeLink)]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class Class_
    {
        #region ClassAttributes
        /// <summary>
        /// Gets the Is library methods.
        /// </summary>
        public Class_Attributes ClassAttributes
        {
            get { return _ClassAttributes ?? (_ClassAttributes = new Class_Attributes()); }
        }
        private Class_Attributes _ClassAttributes;
        #endregion

        #region ClassInfo
        /// <summary>
        /// Gets the ClassInfo library methods.
        /// </summary>
        public Class_Info ClassInfo { get { return Class_Info.Instance; } }
        #endregion

        #region StateInfo
        /// <summary>
        /// Gets the StateInfo library methods.
        /// </summary>
        public Class_StateInfo StateInfo
        {
            get { return Class_StateInfo.Instance; }
        }
        #endregion

        /// <summary>
        /// Word_FromAbbreviation the specified object properties to printable string.
        /// </summary>
        /// <param name="classObject">The element.</param>
        /// <param name="indentSize">Size of the indent.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="maxItemCount">The maximum item count2.</param>
        /// <returns>System.String.</returns>
        public static string AsString(object classObject, int indentSize = 2, int maxLength = 1000, int maxItemCount = 20)
        {
            return Class_AsString.AsString(classObject, indentSize, maxLength, maxItemCount);
        }
    }
}
