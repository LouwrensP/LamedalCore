using System;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.domain.Attributes
{
    /// <summary>
    /// Add rules to a method to assist with transformations.
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.BlueprintRuleDef)]
    [AttributeUsage(AttributeTargets.Method)]
    public class BlueprintRule_MethodAliasDefAttribute : Attribute
    {
        // Create mirror method using the parameter specified as the first parameter
        public string MirrorParameter1;
        public Type MirrorClass;          // If specified -> add this method in the mirror class
        public string MirrorMethodName;     // If specified -> use this method name in the mirror class if specified. If no mirror class specified use the current class
    }
}
