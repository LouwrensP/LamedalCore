using System;
using System.Collections.Generic;
using System.Reflection;

namespace LamedalCore.domain.Attributes
{
    /// <summary>
    /// This class return blueprint rule and data attributes.
    /// </summary>
    public sealed class BlueprintAttribute_Controller
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        // Class
        private readonly BlueprintData_TableAttribute _classData;
        private readonly BlueprintRule_ClassAttribute _classRule;
        private readonly Type _classType;

        // Data
        private readonly IList<Tuple<FieldInfo, BlueprintData_FieldAttribute>> _dataFields;
        private readonly IList<Tuple<PropertyInfo, BlueprintData_FieldAttribute>> _dataProperties;

        // Rules
        private readonly IList<Tuple<FieldInfo, BlueprintRule_FieldAttribute>> _ruleFields;
        private readonly IList<Tuple<PropertyInfo, BlueprintRule_FieldAttribute>> _ruleProperties;
        private readonly IList<Tuple<MethodInfo, BlueprintRule_MethodAttribute>> _ruleMethods;
        private readonly IList<Tuple<MethodInfo, BlueprintRule_MethodAliasDefAttribute>> _ruleMethodsAlias;

        /// <summary>Initializes a new instance of the <see cref="BlueprintAttribute_Controller"/> class.</summary>
        /// <param name="classType">Type of the class.</param>
        public BlueprintAttribute_Controller(Type classType)
        {
            _classType = classType;

            // Rules
            _ruleFields = _lamed.Types.Class.ClassAttributes.Find_Fields<BlueprintRule_FieldAttribute>(classType);
            _ruleProperties = _lamed.Types.Class.ClassAttributes.Find_Properties<BlueprintRule_FieldAttribute>(classType);
            _ruleMethods = _lamed.Types.Class.ClassAttributes.Find_Methods<BlueprintRule_MethodAttribute>(classType);
            _ruleMethodsAlias = _lamed.Types.Class.ClassAttributes.Find_Methods<BlueprintRule_MethodAliasDefAttribute>(classType);
            _lamed.Types.Class.ClassAttributes.Find_Class(classType, out _classRule);

            // Data
            _dataFields = _lamed.Types.Class.ClassAttributes.Find_Fields<BlueprintData_FieldAttribute>(classType);
            _dataProperties = _lamed.Types.Class.ClassAttributes.Find_Properties<BlueprintData_FieldAttribute>(classType);
            _lamed.Types.Class.ClassAttributes.Find_Class(classType, out _classData);
        }

        /// <summary>Gets the table information.</summary>
        /// <value>The table information.</value>
        public BlueprintData_TableAttribute Class_DataTableInfo {get { return _classData; } }

        /// <summary>Get the Blueprint data for the property or field.</summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public BlueprintData_FieldAttribute Data_Property(string fieldName)
        {
            // Searches the fields
            BlueprintData_FieldAttribute result = null;
            Tuple<MemberInfo, BlueprintData_FieldAttribute> fieldInfo;
            if (Data_FindAttribute(fieldName, out fieldInfo)) result = fieldInfo.Item2;
            return result;
        }

        /// <summary>Gets the class blueprint rule.</summary>
        public BlueprintRule_ClassAttribute Class_Rule { get { return _classRule; } }

        /// <summary>Get the Blueprint rule for the property or field.</summary>
        /// <param name="property_or_FieldName">Name of the field.</param>
        /// <returns></returns>
        public BlueprintRule_FieldAttribute Rule_PropertyField(string property_or_FieldName)
        {
            // Searches the fields
            BlueprintRule_FieldAttribute result = null;
            Tuple<MemberInfo, BlueprintRule_FieldAttribute> fieldInfo;
            if (Rule_FindAttribute(property_or_FieldName, out fieldInfo)) result = fieldInfo.Item2;
            return result;
        }

        /// <summary>Return the method rule attribute.</summary>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        public BlueprintRule_MethodAttribute Rule_Method(string methodName)
        {
            BlueprintRule_MethodAttribute result = null;
            foreach (var method in _ruleMethods)
            {
                if (method.Item1.Name == methodName)
                {
                    result = method.Item2;
                    break;
                }
            }
            return result;
        }

        /// <summary>Return the method allias attribute.</summary>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        public BlueprintRule_MethodAliasDefAttribute Rule_MethodAlias(string methodName)
        {
            BlueprintRule_MethodAliasDefAttribute result = null;
            foreach (var method in _ruleMethodsAlias)
            {
                if (method.Item1.Name == methodName)
                {
                    result = method.Item2;
                    break;
                }
            }
            return result;
        }

        /// <summary>Get the property of field member information.</summary>
        /// <param name="property_or_FieldName">Name of the field.</param>
        /// <returns></returns>
        public MemberInfo PropertyField_Info(string property_or_FieldName)
        {
            return _lamed.Types.Class.ClassInfo.PropertyField_Info(_classType, property_or_FieldName);
        }

        /// <summary>Searches for field or property with the blueprint attribute.</summary>
        /// <param name="property_or_FieldName">Name of the field.</param>
        /// <param name="fieldInfo">The field information.</param>
        /// <returns></returns>
        private bool Rule_FindAttribute(string property_or_FieldName, out Tuple<MemberInfo, BlueprintRule_FieldAttribute> fieldInfo)
        {
            var result = false;
            fieldInfo = null;
            // Searches the fields
            foreach (var field in _ruleFields)
            {
                if (field.Item1.Name == property_or_FieldName)
                {
                    fieldInfo = new Tuple<MemberInfo, BlueprintRule_FieldAttribute>(field.Item1, field.Item2);
                    result = true;
                    break;
                }
            }
            if (result == false)
            {
                foreach (var property in _ruleProperties)
                {
                    if (property.Item1.Name == property_or_FieldName)
                    {
                        fieldInfo = new Tuple<MemberInfo, BlueprintRule_FieldAttribute>(property.Item1, property.Item2);
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>Searches for field or property with the blueprint attribute.</summary>
        /// <param name="property_or_FieldName">Name of the field.</param>
        /// <param name="fieldInfo">The field information.</param>
        /// <returns></returns>
        private bool Data_FindAttribute(string property_or_FieldName, out Tuple<MemberInfo, BlueprintData_FieldAttribute> fieldInfo)
        {
            fieldInfo = null;
            bool result = false;
            // Searches the fields
            foreach (var field in _dataFields)
            {
                if (field.Item1.Name == property_or_FieldName)
                {
                    fieldInfo = new Tuple<MemberInfo, BlueprintData_FieldAttribute>(field.Item1, field.Item2);
                    result = true;
                    break;
                }
            }
            
            if (result == false)
            {
                // fieldname was not found in fields -> search the properties
                foreach (var property in _dataProperties)
                {
                    if (property.Item1.Name == property_or_FieldName)
                    {
                        fieldInfo = new Tuple<MemberInfo, BlueprintData_FieldAttribute>(property.Item1, property.Item2);
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
    }
}