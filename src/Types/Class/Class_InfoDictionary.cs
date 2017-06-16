using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types.Class

{
    /// <summary>
    /// This class is used internally to optimise reflection opperations
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    internal sealed class Class_InfoDictionary
    {
        //private readonly LaMedal.Portable.Types.Types_ _types = LaMedal.Portable.LaMedalPortable.Instance.Types;

        // Caching of reflection items in order to speedup usage.
        #region Dictionary fields

        //BlueprintAttribute_Controller
        /// <summary>ConstructorInfo quick reference.</summary>
        private static readonly Dictionary<Type, BlueprintAttribute_Controller> _blueprintAttributes = new Dictionary<Type, BlueprintAttribute_Controller>();

        /// <summary>ConstructorInfo quick reference.</summary>
        private static readonly Dictionary<Type, ConstructorInfo[]> _constructorInfos = new Dictionary<Type, ConstructorInfo[]>();

        /// <summary>MethodInfo quick reference.</summary>
        private static readonly Dictionary<Type, MethodInfo[]> _methodInfos = new Dictionary<Type, MethodInfo[]>();

        /// <summary>FieldInfo quick reference.</summary>
        private readonly Dictionary<Type, FieldInfo[]> _fieldInfo = new Dictionary<Type, FieldInfo[]>();

        /// <summary>PropertyInfo quick reference.</summary>
        private readonly Dictionary<Type, PropertyInfo[]> _propertyInfos = new Dictionary<Type, PropertyInfo[]>();

        #endregion

        private BindingFlags _bindingAttributes = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        //private BindingFlags BindingFlagsSetup(bool addBase = true, bool addPublic = true, bool addNonPublic = true)
        //{
        //    var flags = BindingFlags.Static;
        //    if (addPublic) flags = flags | BindingFlags.Public;
        //    if (addNonPublic) flags = flags | BindingFlags.NonPublic;
        //    if (addBase) flags = flags | BindingFlags.Instance;
        //    return flags;
        //}

        /// <summary>
        /// Generic blueprint rule and data caching.
        /// </summary>
        /// <param name="classType">The class type</param>
        /// <returns>FieldInfo[]</returns>
        public BlueprintAttribute_Controller Blueprint_Attributes(Type classType)
        {
            if (_blueprintAttributes.ContainsKey(classType)) return _blueprintAttributes[classType];

            // Add classType to the quick reference list
            var blueprint = new BlueprintAttribute_Controller(classType);
            _blueprintAttributes.Add(classType, blueprint);
            return blueprint;
        }

        #region ConstructorInfo
        /// <summary>
        /// Get the cached methods for a type
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public ConstructorInfo[] ConstructorInfo_Get(Type classType)
        {
            if (_constructorInfos.ContainsKey(classType)) return _constructorInfos[classType];

            ConstructorInfo[] constructorInfos = classType.GetTypeInfo().GetConstructors(_bindingAttributes);
            _constructorInfos.Add(classType, constructorInfos);
            return constructorInfos;
        }

        public ConstructorInfo ConstructorInfo_Get(Type classType, string constructorName)
        {
            return ConstructorInfo_Get(classType).FirstOrDefault(m => m.DeclaringType.Name == constructorName);
        }
        #endregion

        #region FieldInfo
        /// <summary>
        /// Generic field information for the type.
        /// </summary>
        /// <param name="classType">The class type</param>
        /// <returns>FieldInfo[]</returns>
        public FieldInfo[] FieldInfo_Get(Type classType)
        {
            if (_fieldInfo.ContainsKey(classType)) return _fieldInfo[classType];

            // Add classType to the quick reference list
            TypeInfo typeInfo = classType.GetTypeInfo();
            FieldInfo[] fieldInfos = typeInfo.GetFields(_bindingAttributes);
            _fieldInfo.Add(classType, fieldInfos);

            //// Add base types
            //Type baseType = classType.BaseType; // Get the first parent
            //if (baseType != null) FieldInfo_Get(baseType);

            return fieldInfos;
        }

        public FieldInfo FieldInfo_Get(Type classType, string fieldName)
        {
            var result = FieldInfo_Get(classType).FirstOrDefault(m => m.Name == fieldName);
            if (result != null) return result;

            // Search the base types for the property
            Type baseType = classType.GetTypeInfo().BaseType; // Get the first parent
            if (baseType != null) result = FieldInfo_Get(baseType, fieldName);

            return result;
        }
        #endregion

        #region MethodInfo
        /// <summary>
        /// Get a method by name
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public MethodInfo MethodInfo_Get(Type classType, string methodName)
        {
            return MethodInfo_Get(classType).FirstOrDefault(m => m.Name == methodName);
        }

        /// <summary>
        /// Get the cached methods for a type
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public MethodInfo[] MethodInfo_Get(Type classType)
        {
            if (_methodInfos.ContainsKey(classType)) return _methodInfos[classType];

            var methodInfos = classType.GetTypeInfo().GetMethods(_bindingAttributes);
            List<MethodInfo> list = new List<MethodInfo>();
            foreach (var method in methodInfos)
            {
                if (method.Name.zIn("Equals", "GetHashCode", "GetType", "Finalize", "MemberwiseClone", "ToString")) continue;
                if (method.IsSpecialName == false) list.Add(method);
            }
            methodInfos = list.ToArray();  // Remove geters and setters

            _methodInfos.Add(classType, methodInfos);
            return methodInfos;
        }
        #endregion

        #region PropertyInfo
        /// <summary>
        /// Generic properties for the type.
        /// </summary>
        /// <param name="classType">The class type</param>
        /// <returns>PropertyInfo[]</returns>
        public PropertyInfo[] PropertyInfo_Get(Type classType)
        {
            if (_propertyInfos.ContainsKey(classType)) return _propertyInfos[classType];

            // Add classType to the quick reference list
            TypeInfo classTypeInfo = classType.GetTypeInfo();
            PropertyInfo[] propertyInfos = classTypeInfo.GetProperties(_bindingAttributes);
            _propertyInfos.Add(classType, propertyInfos);

            //// Add base types
            //Type baseType = classType.BaseType; // Get the first parent
            //if (baseType != null) PropertyInfo_Get(baseType);

            return propertyInfos;
        }

        /// <summary>
        /// Get a method by name
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public PropertyInfo PropertyInfo_Get(Type classType, string propertyName)
        {
            PropertyInfo result = PropertyInfo_Get(classType).FirstOrDefault(m => m.Name == propertyName);
            if (result != null) return result;

            // Search the base types for the property
            Type baseType = classType.GetTypeInfo().BaseType; // Get the first parent
            if (baseType != null) result = PropertyInfo_Get(baseType, propertyName);

            return result;
        }
        #endregion
    }
}
