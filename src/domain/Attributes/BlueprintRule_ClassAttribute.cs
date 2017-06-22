using System;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.domain.Attributes
{
    /// <summary>
    /// See project mindmap for explanation
    /// </summary>
    /// <seealso cref="System.Attribute" 
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.BlueprintRuleDef)]
    [AttributeUsage(AttributeTargets.Class)]
    public class BlueprintRule_ClassAttribute : Attribute
    {
        public enBlueprint_ClassNetworkType ClassType;
        public string DefaultGroup = "";    // If the mehtod is of the default type -> use this default group. Usually it should be empty
        public Type DefaultType;            // If a method first parameter is the default type, the default type will be part of the method name
        public string GroupName = "";       // The default value for the groupname will be the classname. This override the default classname as the group
        public bool IgnoreGroup;            // The classname will be ignored in transformations 
        public bool IgnoreGroupPath;        // The classname will be remomved from the method name (if it exists) in transformations
        public bool IncludeObjects;         // Object methods will be included in transformations

        // Ignore Namespaces
        public string Ignore_Namespace1 = "domain";        // Namespaces to ignore like Factory and zz
        public string Ignore_Namespace2 = "parts";         // Ignore no 2
        public string Ignore_Namespace3;
        public string Ignore_Namespace4;

        //// Commen Shortcut classes can be directed to other shortcut class
        //public string ShortcutClass_String;     // <code ShortcutClass_String ="String_Shortcut"></code> 
        //public string ShortcutClass_Object;     // <code ShortcutClass_Object ="String_Object"></code> 
        public string ShortcutClass;              // <code ShortcutClass ="Enum_Shortcut"></code>  // Override default method filter behavior -> move this method to the Enums_Shortcut class

        public BlueprintRule_ClassAttribute(enBlueprint_ClassNetworkType classType = enBlueprint_ClassNetworkType.Undefined)
        {
            ClassType = classType;
        }

        [Test_IgnoreCoverage(enCode_TestIgnore.ConstructorIsPrivate)]
        private BlueprintRule_ClassAttribute()
        {
            // Only available in inherited class
        }
    }
}
