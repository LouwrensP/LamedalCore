using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.domain.Attributes
{
    /// <summary>
    /// This attribute is to save the name of the method that is tested
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.BlueprintRuleDef)]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class Test_MethodAttribute: Attribute
    {
        public string MethodName;

        [Test_IgnoreCoverage(enCode_TestIgnore.CodeIsUsedForTesting)]
        public Test_MethodAttribute(string methodName)
        {
            MethodName = methodName;
        }
    }
}
