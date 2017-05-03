﻿using System;

namespace LamedalCore.domain.Attributes
{

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class BlueprintRule_FieldAttribute : Attribute
    {
        public string Name = "";
        public string Description = null;

        // Fields ======================================================
        [BlueprintData_Description("If true then the class can contain fields.")]
        public bool Fields_OneOrMany;

        /// <summary>
        /// A Singleton field is a field to a blueprint singleton library class.
        /// </summary>
        [BlueprintData_Description("A Singleton field is a field to a blueprint singleton library class.")]
        public bool Fields_OneOrMany_SingletonFields;

        [BlueprintData_Description("If true then the class does not contain any fields.")]
        public bool Fields_None;

        // Properties ======================================================
        /// <summary>
        /// If true then the class can have properties.
        /// </summary>
        [BlueprintData_Description("If true then the class only has properties but no methods.")]
        public bool Properties_OneOrMany;

        [BlueprintData_Description("If true then the class can not contain properties.")]
        public bool Properties_None;

        // Class ======================================================
        [BlueprintData_Description("If true then the class must be singleton.")]
        public bool Class_IsSingelton = false;

        [BlueprintData_Description("If true then the class is static.")]
        public bool Class_IsStatic = false;  

        [BlueprintData_Description("If true then this class is generated.")]
        public bool Class_IsGenerated;

        public bool Class_HasConstructor_Private;
        public bool Class_HasConstructor_Public;
        public bool Class_HasNoConstructor;


        // Methods ======================================================
        //[Description("If true then the class can contains one method always.")]
        public bool Methods_1Static;

        [BlueprintData_Description("If true then the class can contain methods.")]
        public bool Methods_OneOrMany;
        [BlueprintData_Description("If true then the class cannot contain any methods.")]
        public bool Methods_None;


        [BlueprintData_Description("If true then this class implements method of form 'public static stateProcess zzState(this Process process)'.")]
        public bool Methods_zzState = false;


    }
}