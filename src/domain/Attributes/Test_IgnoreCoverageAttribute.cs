using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.domain.Attributes
{
    /// <summary>
    /// This attribute to indicate methods that need to be ignored in coverage test
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [BlueprintRule_Class(enBlueprintClassNetworkType.BlueprintRuleDef)]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Class 
        | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class Test_IgnoreCoverageAttribute : Attribute
    {
        public enTestIgnore Reason;

        [Test_IgnoreCoverage(enTestIgnore.CodeIsUsedForTesting)]
        public Test_IgnoreCoverageAttribute(enTestIgnore reason)
        {
            Reason = reason;
        }
    }
}
