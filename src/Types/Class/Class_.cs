using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.Types.Class
{
    [Test_IgnoreCoverage(enTestIgnore.ClassIsNodeLink)]
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

    }
}
