using System;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.domain.Attributes
{
    /// <summary>
    /// Add rules to a method to assist with transformations.
    /// </summary>
    [BlueprintRule_Class(enBlueprintClassNetworkType.BlueprintRuleDef)]
    [AttributeUsage(AttributeTargets.Method)]
    public class BlueprintRule_MethodAttribute : Attribute
    {
        public bool Ignore;                 // Indicate the method can be ignored in CTI transformation
        public string ShortcutClassName;    // Override default method filter behavior -> move this method to the ShortcutClass class
        public string ShortcutMethodName;   // Override default method naming
    }
}
