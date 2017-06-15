using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.Types.Class
{
    public sealed class Class_Info
    {
        /// <summary>Gets the class information reference.</summary>
        private Class_Info_Dictionary Dictionary { get; } = new Class_Info_Dictionary();

        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        #region Singleton of Access2System_
        private static readonly Class_Info _Types_ClassInfo = new Class_Info();  // This is the only instance of this class
        private Class_Info()
        {
            // Private constructor prevents creation by external clients
        }

        /// <summary>
        /// Return Instance of Types_ClassInfo
        /// </summary>
        public static Class_Info Instance
        {
            get { return _Types_ClassInfo; }
        }
        #endregion

        /// <summary>
        /// Generic blueprint rule and data caching.
        /// </summary>
        /// <param name="classType">The class type</param>
        /// <returns>FieldInfo[]</returns>
        public BlueprintAttribute_Controller Blueprint_Attributes(Type classType)
        {
            return Dictionary.Blueprint_Attributes(classType);
        }

        #region PropertyField_ - Combine properties and fields to provide one simple interface

        /// <summary>Get the property of field member information.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="fieldOrPropertyName">Name of the field or property.</param>
        /// <param name="memberType">Type of the member.</param>
        /// <returns></returns>
        public MemberInfo PropertyField_Info(Type objectType, string fieldOrPropertyName, out enCode_ClassMemberType memberType)
        {
            memberType = enCode_ClassMemberType.Undefined;
            // Field
            MemberInfo result = Field_AsFieldInfo(objectType, fieldOrPropertyName);
            if (result != null) memberType = enCode_ClassMemberType.ClassField;
            else
            {
                // Property
                result = Property_AsPropertyInfo(objectType, fieldOrPropertyName);
                if (result != null) memberType = enCode_ClassMemberType.ClassProperty;
            }
            return result;
        }

        /// <summary>Get the property of field member information.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="fieldOrPropertyName">Name of the field or property.</param>
        /// <returns></returns>
        public MemberInfo PropertyField_Info(Type objectType, string fieldOrPropertyName)
        {
            enCode_ClassMemberType memberType;
            var result = PropertyField_Info(objectType, fieldOrPropertyName, out memberType);
            return result;
        }

        #endregion

        #region Properties
        /// <summary>Set the property of the object class to the value.</summary>
        /// <param name="Object">The objectect</param>
        /// <param name="propertyName">The propertyerty</param>
        /// <param name="value">The valueue</param>
        public void Property_Set(object Object, string propertyName, object value)
        {
            var objectType = Object.GetType();
            PropertyInfo propertyInfo = Dictionary.PropertyInfo_Get(objectType, propertyName);
            var value2 = _lamed.Types.Object.CastTo(value, propertyInfo.PropertyType);
        
            propertyInfo.SetValue(Object, value2, null);
        }

        /// <summary>Gets the value of a property.</summary>
        /// <param name="Object">The object.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public object Property_Get(object Object, string propertyName)
        {
            PropertyInfo propertyInfo = Property_AsPropertyInfo(Object.GetType(), propertyName);
            var result = propertyInfo.GetValue(Object);
            return result;
        }

        /// <summary>Gets the Property information.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public PropertyInfo Property_AsPropertyInfo(Type objectType, string propertyName)
        {
            PropertyInfo propertyInfo = Dictionary.PropertyInfo_Get(objectType, propertyName);
            return propertyInfo;
        }

        /// <summary>Gets the value of a property.</summary>
        /// <param name="Object">The object.</param>
        /// <param name="propertyName">Name of the field.</param>
        /// <returns></returns>
        public T Property_Get<T>(object Object, string propertyName)
        {
            var result = Property_Get(Object, propertyName);
            return (T) result;
        }

        /// <summary>Return all the property names.</summary>
        /// <param name="classType">Type of the clas.</param>
        /// <returns></returns>
        public List<string> Properties_AsStrList(Type classType)
        {
            PropertyInfo[] properties = Properties_AsPropertyInfo(classType);
            var result = properties.Select(x => x.Name).ToList();
            return result;
        }

        /// <summary>
        /// Generic properties for the type.
        /// </summary>
        /// <param name="classType">The class type</param>
        /// <returns>PropertyInfo[]</returns>
        public PropertyInfo[] Properties_AsPropertyInfo(Type classType)
        {
            PropertyInfo[] properties = Dictionary.PropertyInfo_Get(classType);
            return properties;
        }

        #endregion

        #region Fields
        /// <summary>Set the field of the object class to the value.</summary>
        /// <param name="Object">The object.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        public void Field_Set(object Object, string fieldName, object value)
        {
            var objectType = Object.GetType();
            var fieldInfo = Dictionary.FieldInfo_Get(objectType, fieldName);
            var value2 = _lamed.Types.Object.CastTo(value, fieldInfo.FieldType);

            fieldInfo.SetValue(Object, value2);
        }

        /// <summary>Get the field value of the object class.</summary>
        /// <param name="Object">The object.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public object Field_Get(object Object, string fieldName)
        {
            FieldInfo fieldInfo = Field_AsFieldInfo(Object.GetType(), fieldName);
            return fieldInfo.GetValue(Object);
        }

        /// <summary>Gets the Field Information.</summary>
        /// <param name="Object">The object.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public FieldInfo Field_AsFieldInfo(Type classType, string fieldName)
        {
            FieldInfo fieldInfo = Dictionary.FieldInfo_Get(classType, fieldName);
            return fieldInfo;
        }

        /// <summary>Get the field value of the object class.</summary>
        /// <param name="Object">The object.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public T Field_Get<T>(object Object, string fieldName)
        {
            var result = Field_Get(Object, fieldName);
            return (T) result;
        }

        /// <summary>Return all the Field names.</summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        public List<string> Fields_AsStrList(Type classType)
        {
            var fields = Fields_AsFieldInfo(classType);
            var result = fields.Select(x => x.Name).ToList();
            return result;
        }

        /// <summary>
        /// Generic field information for the type.
        /// </summary>
        /// <param name="classType">The class type</param>
        /// <returns>FieldInfo[]</returns>
        public FieldInfo[] Fields_AsFieldInfo(Type classType)
        {
            FieldInfo[] fieldInfos = Dictionary.FieldInfo_Get(classType);
            return fieldInfos;
        }
        #endregion

        #region Methods
        /// <summary>Return all the Method names.</summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        public List<string> Methods_AsStrList(Type classType)
        {
            MethodInfo[] methods = Methods_AsMethodInfo(classType);
            List<string> result = methods.Select(x => x.Name).ToList();
            return result;

        }

        /// <summary>
        /// Get the cached methods for a type
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public MethodInfo[] Methods_AsMethodInfo(Type classType)
        {
            MethodInfo[] methods = Dictionary.MethodInfo_Get(classType);
            return methods;
        }

        /// <summary>Get the cached methods for a type</summary>
        /// <param name="classType">Type of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        public MethodInfo Method_AsMethodInfo(Type classType, string methodName)
        {
            var methods = Dictionary.MethodInfo_Get(classType, methodName);
            return methods;
        }

        /// <summary>Executes a method.</summary>
        /// <param name="classObj">The class object.</param>
        /// <param name="method">The method.</param>
        /// <param name="parameters">The parameters.</param>
        public void Method_Execute(object classObj, MethodInfo method, params object[] parameters)
        {
            if (method != null) method.Invoke(classObj, parameters);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Get the cached methods for a type
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public ConstructorInfo[] Constructors_AsConstructorInfo(Type classType)
        {
            ConstructorInfo[] constructors = Dictionary.ConstructorInfo_Get(classType);
            return constructors;
        }

        /// <summary>Gets the Field Information.</summary>
        /// <param name="classType">Type of the class.</param>
        /// <param name="constructorName">Name of the field.</param>
        /// <returns></returns>
        public ConstructorInfo Constructor_AsConstructorInfo(Type classType, string constructorName)
        {
            ConstructorInfo result = Dictionary.ConstructorInfo_Get(classType, constructorName);
            return result;
        }
        #endregion

    }
}
