using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.Types.Class
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, DefaultGroup = "Attribute")]
    public sealed class Class_Attributes
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>
        /// Determines with reflection whether the custom attributes array has attribute .
        /// </summary>
        /// <param name="customAttributes">The custom attributes array</param>
        /// <param name="filterForThisAttribute">Return the attribute filtered for</param>
        /// <returns>bool</returns>
        private bool Find_<TAttribute>(Attribute[] customAttributes, out TAttribute filterForThisAttribute) where TAttribute : Attribute
        {
            filterForThisAttribute = _lamed.Types.Object.DefaultValue<TAttribute>();
            foreach (Attribute attribute1 in customAttributes)
            {
                if (attribute1.GetType() == typeof(TAttribute))
                {
                    filterForThisAttribute = (TAttribute)attribute1;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines with reflectionwhether the member information has a specific attribute .
        /// </summary>
        /// <typeparam name="TFilterForThisAttribute">The type of the filter to use to find this attribute.</typeparam>
        /// <param name="memberInfo">The member information</param>
        /// <param name="attribute">Return the attribute</param>
        /// <returns>bool</returns>
        private bool Find_MemberInfo<TFilterForThisAttribute>(MemberInfo memberInfo, out TFilterForThisAttribute attribute) where TFilterForThisAttribute : Attribute
        {
            Attribute[] attributes = memberInfo.GetCustomAttributes().ToArray();
            return Find_(attributes, out attribute);
        }

        /// <summary>
        /// Determines whether the class field type has attribute.
        /// </summary>
        /// <param name="classType">The class type</param>
        /// <param name="attribute">The attribute reference variable</param>
        /// <returns>bool</returns>
        private bool Find_Field<TFilterForThisAttribute>(Type classType, out TFilterForThisAttribute attribute) where TFilterForThisAttribute : Attribute
        {
            // The attribute was not on the methods -> test the fields
            FieldInfo[] fields = _lamed.Types.Class.ClassInfo.Fields_AsFieldInfo(classType);
            foreach (FieldInfo field in fields)
            {
                if (Find_MemberInfo(field, out attribute)) return true;
            }
            attribute = _lamed.Types.Object.DefaultValue<TFilterForThisAttribute>();
            return false;
        }

        /// <summary>
        /// Determines whether the class field type has attribute.
        /// </summary>
        /// <param name="classType">The class type</param>
        /// <param name="attribute">The attribute reference variable</param>
        /// <returns>bool</returns>
        public bool Find_Class<TFilterForThisAttribute>(Type classType, out TFilterForThisAttribute attribute) where TFilterForThisAttribute : Attribute
        {
            // The attribute was not on the methods -> test the fields
            TypeInfo member = classType.GetTypeInfo();
            if (Find_MemberInfo(member, out attribute)) return true;
            attribute = _lamed.Types.Object.DefaultValue<TFilterForThisAttribute>();
            return false;
        }

        /// <summary>Determines whether the class field type has attribute.</summary>
        /// <typeparam name="TFilterForThisAttribute">The type of the filter for this attribute.</typeparam>
        /// <param name="classType">The class type</param>
        /// <param name="returnAllFields">if set to <c>true</c> [get all fields].</param>
        /// <param name="returnPrivate">if set to <c>true</c> [return private].</param>
        /// <returns></returns>
        public IList<Tuple<FieldInfo, TFilterForThisAttribute>> Find_Fields<TFilterForThisAttribute>(Type classType, bool returnAllFields = false, bool returnPrivate = false) 
                    where TFilterForThisAttribute : Attribute
        {
            // The attribute was not on the methods -> test the fields
            var result = new List<Tuple<FieldInfo, TFilterForThisAttribute>>();
            FieldInfo[] fields = _lamed.Types.Class.ClassInfo.Fields_AsFieldInfo(classType);
            foreach (FieldInfo field in fields)   // FieldInfo -> MemberInfo
            {
                TFilterForThisAttribute attribute;
                if (Find_MemberInfo(field, out attribute)) result.Add(new Tuple<FieldInfo, TFilterForThisAttribute>(field, attribute));
                else if (returnAllFields)
                {
                    if (returnPrivate) result.Add(new Tuple<FieldInfo, TFilterForThisAttribute>(field, null));
                    else if (field.IsPrivate == false) result.Add(new Tuple<FieldInfo, TFilterForThisAttribute>(field, null));
                }
            }
            return result;
        }

        /// <summary>Determines whether the class field type has attribute.</summary>
        /// <typeparam name="TFilterForThisAttribute">The type of the filter for this attribute.</typeparam>
        /// <param name="classType">The class type</param>
        /// <param name="returnAllMethods">if set to <c>true</c> [get all fields].</param>
        /// <param name="returnPrivate">if set to <c>true</c> [return private].</param>
        /// <returns></returns>
        public IList<Tuple<MethodInfo, TFilterForThisAttribute>> Find_Methods<TFilterForThisAttribute>(Type classType, bool returnAllMethods = false, bool returnPrivate = false)
                    where TFilterForThisAttribute : Attribute
        {
            // The attribute was not on the methods -> test the fields
            var result = new List<Tuple<MethodInfo, TFilterForThisAttribute>>();
            MethodInfo[] methods = _lamed.Types.Class.ClassInfo.Methods_AsMethodInfo(classType);
            foreach (MethodInfo method in methods)   // FieldInfo -> MemberInfo
            {
                TFilterForThisAttribute attribute;
                if (Find_MemberInfo(method, out attribute)) result.Add(new Tuple<MethodInfo, TFilterForThisAttribute>(method, attribute));
                else if (returnAllMethods)
                {
                    if (returnPrivate) result.Add(new Tuple<MethodInfo, TFilterForThisAttribute>(method, null));
                    else if (method.IsPrivate == false) result.Add(new Tuple<MethodInfo, TFilterForThisAttribute>(method, null));
                }
            }
            return result;
        }
        /// <summary>
        /// Determines whether the class method has attribute.
        /// </summary>
        /// <param name="classType">The class type</param>
        /// <param name="attribute">The attribute reference variable</param>
        /// <returns>bool</returns>
        private bool Find_Method<TFilterForThisAttribute>(Type classType, out TFilterForThisAttribute attribute) where TFilterForThisAttribute : Attribute
        {
            // The attribute was not on the type -> test the methods
            IEnumerable<MethodInfo> methods = _lamed.Types.Class.ClassInfo.Methods_AsMethodInfo(classType);
            foreach (MethodInfo method in methods)
            {
                if (Find_MemberInfo(method, out attribute)) return true;
            }
            attribute = _lamed.Types.Object.DefaultValue<TFilterForThisAttribute>();
            return false;
        }

        /// <summary>Determines whether the class constructor has attribute.</summary>
        /// <typeparam name="TfilterForThisAttribute">The type of the filter for this attribute.</typeparam>
        /// <param name="classType">The class type</param>
        /// <param name="attribute">The attribute reference variable</param>
        /// <returns>bool</returns>
        public bool Find_Constructor<TfilterForThisAttribute>(Type classType, out TfilterForThisAttribute attribute) where TfilterForThisAttribute : Attribute
        {
            // The attribute was not on the type -> test the methods
            ConstructorInfo[] constructors = _lamed.Types.Class.ClassInfo.Constructors_AsConstructorInfo(classType);
            foreach (ConstructorInfo constructor in constructors)
            {
                if (Find_MemberInfo(constructor, out attribute)) return true;
            }
            attribute = _lamed.Types.Object.DefaultValue<TfilterForThisAttribute>();
            return false;
        }

        /// <summary>
        /// Determines with reflection whether the type has a specific attribute  type.
        /// </summary>
        /// <typeparam name="TfilterForThisAttribute">The type of the filter for this attribute.</typeparam>
        /// <param name="classType">Type of the class.</param>
        /// <param name="attribute">Return the attribute</param>
        /// <returns>eAttributeLocation</returns>
        public enCode_AttributeLocation Find_ForType<TfilterForThisAttribute>(Type classType, out TfilterForThisAttribute attribute) where TfilterForThisAttribute : Attribute
        {
            if (Find_MemberInfo(classType.GetTypeInfo(), out attribute)) return enCode_AttributeLocation.Class;

            // The attribute was not on the type -> test the methods
            if (Find_Method(classType, out attribute)) return enCode_AttributeLocation.Method;

            if (Find_Field(classType, out attribute)) return enCode_AttributeLocation.Field;

            // The attribute was not on the fields -> test the properties
            if (Find_Property(classType, out attribute)) return enCode_AttributeLocation.Property;

            // The attribute was not on the constructor -> test the properties
            if (Find_Constructor(classType, out attribute)) return enCode_AttributeLocation.Constructor;

            return enCode_AttributeLocation.None;
        }

        /// <summary>Determines whether the class property has attribute.</summary>
        /// <typeparam name="TfilterForThisAttribute">The type of the filter for this attribute.</typeparam>
        /// <param name="classType">The class type</param>
        /// <param name="attribute">The attribute reference variable</param>
        /// <returns>bool</returns>
        private bool Find_Property<TfilterForThisAttribute>(Type classType, out TfilterForThisAttribute attribute) where TfilterForThisAttribute : Attribute
        {
            // The attribute was not on the fields -> test the properties
            PropertyInfo[] properties = _lamed.Types.Class.ClassInfo.Properties_AsPropertyInfo(classType);
            foreach (PropertyInfo property in properties)
            {
                if (Find_MemberInfo(property, out attribute)) return true;
            }
            attribute = _lamed.Types.Object.DefaultValue<TfilterForThisAttribute>();
            return false;
        }

        /// <summary>Return all the class properties with this attribute .</summary>
        /// <typeparam name="TfilterForThisAttribute">The type of the filter for this attribute.</typeparam>
        /// <param name="classType">The class type</param>
        /// <param name="returnAllFields">if set to <c>true</c> [return all fields].</param>
        /// <param name="returnPrivate">if set to <c>true</c> [return private].</param>
        /// <returns>bool</returns>
        public IList<Tuple<PropertyInfo,TfilterForThisAttribute>> Find_Properties<TfilterForThisAttribute>(Type classType, bool returnAllFields = false,bool returnPrivate = false) where TfilterForThisAttribute : Attribute
        {
            // The attribute was not on the fields -> test the properties
            var result = new List<Tuple<PropertyInfo,TfilterForThisAttribute>>();
            PropertyInfo[] properties = _lamed.Types.Class.ClassInfo.Properties_AsPropertyInfo(classType);
            foreach (PropertyInfo property in properties)
            {
                TfilterForThisAttribute attribute;
                if (Find_MemberInfo(property, out attribute)) result.Add(new Tuple<PropertyInfo, TfilterForThisAttribute>(property, attribute));
                else if (returnAllFields)
                {
                    if (returnPrivate) result.Add(new Tuple<PropertyInfo, TfilterForThisAttribute>(property, null));
                    else if (property.GetSetMethod() != null) result.Add(new Tuple<PropertyInfo, TfilterForThisAttribute>(property, null));
                }
            }
            return result;
        }
    }
}
