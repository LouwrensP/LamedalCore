using System;

namespace LamedalCore.domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class BlueprintData_FieldAttribute : Attribute
    {
        /// <summary>The identifier</summary>
        public int Id;
        /// <summary>The caption. Put {0} where you want the value to be in the caption</summary>
        public string Caption;

        public string Description;
        public bool IsVisible = true;
        public bool IsRequired = false;
        public bool IsPassword = false;
        public int LengthMin = 0;
        public int LengthMax = 0;
        public int ValueMin = 0;
        public int ValueMax = 0;


        /// <summary>Initializes a new instance of the <see cref="BlueprintData_FieldAttribute"/> class.</summary>
        /// <param name="caption">The caption.</param>
        public BlueprintData_FieldAttribute(string caption = "")
        {
            Caption = caption;
        }

    }
}
