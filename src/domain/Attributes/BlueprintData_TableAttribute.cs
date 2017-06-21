using System;

namespace LamedalCore.domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class BlueprintData_TableAttribute : Attribute
    {
        public string Caption;   // The caption of the table
        public readonly bool GenerateAllFields;  // Generate all fields even if the fields are not marked
        public string Description;  // Not used yet
        public int TotalPanels = 1;

        /// <summary>Initializes a new instance of the <see cref="BlueprintData_TableAttribute"/> class.</summary>
        /// <param name="caption">The table caption setting. Default value = "".</param>
        /// <param name="generateAllFields">Generate all fields indicator. Default value = false.</param>
        public BlueprintData_TableAttribute(string caption = "", bool generateAllFields = true)
        {
            Caption = caption;
            GenerateAllFields = generateAllFields;
        }

        /// <summary>Initializes a new instance of the <see cref="BlueprintData_TableAttribute"/> class.</summary>
        /// <param name="generateAllFields">Generate all fields indicator</param>
        public BlueprintData_TableAttribute(bool generateAllFields)
        {
            GenerateAllFields = generateAllFields;
        }
    }
}
