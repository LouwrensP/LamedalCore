using System;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.domain.Attributes
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.BlueprintRuleDef)]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public sealed class BlueprintData_DescriptionAttribute : Attribute
    {
        private readonly string description;

        public string Description
        {
            get { return description; }
        }

        public BlueprintData_DescriptionAttribute(string description)
        {
            this.description = description;
        }
    }
}
