using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using LamedalCore.zz;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LamedalCore.lib.IO
{
    public sealed class IO_Json
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>Converts the class object to json string.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="classObject">The class object. It must be of the original type</param>
        /// <param name="DoReferences">if set to <c>true</c> [do referenced] objects also.</param>
        /// <param name="filterFields">The filter fields.</param>
        /// <returns>string</returns>
        public string Convert_FromObject<T>(T classObject, bool DoReferences = false, params string[] filterFields)
        {
            if (classObject == null) return string.Empty;

            // Settings
            var settings = new JsonSerializerSettings();
            if (DoReferences) settings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            else settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Filter for fields ===================
            IO_Json_ContractResolver<T> contract = null;
            if (filterFields.Length != 0)
            {
                contract = new IO_Json_ContractResolver<T>(filterFields);
                settings.ContractResolver = contract;
            }

            string json = JsonConvert.SerializeObject(classObject, Formatting.Indented, settings);

            // Error handling
            if (contract != null && contract.AllFieldsWereFound() == false)
            {
                var ex = new ArgumentException($"Error! The following fields were not found: {contract.MissedFields_AsStr()}", nameof(filterFields));
                _lamed.Logger.L
                ().zException_Show();
            }
            return json;
        }

        /// <summary>Creates the object from json string.</summary>
        /// <param name="json">The json</param>
        /// <returns>T</returns>
        public T Convert_ToType<T>(string json)
        {
            // Check for bad escape sequance

            var Object = JsonConvert.DeserializeObject<T>(json);
            return Object;
        }

        /// <summary>Clone object type using Json.</summary>
        /// <param name="Object">The objectect</param>
        /// <returns>T</returns>
        public T Convert_CloneType<T>(T Object)
        {
            var json = Convert_FromObject(Object);
            var result = Convert_ToType<T>(json);
            return result;
        }

        /// <summary>Determines whether two objects are equal using Json serialisation.</summary>
        /// <param name="Object1">The first object</param>
        /// <param name="Object2">The second object</param>
        /// <param name="errorMsg">The error message</param>
        /// <returns>bool</returns>
        public bool Object_IsEqual(object Object1, object Object2, out string errorMsg)
        {
            errorMsg = "";
            string json1 = Convert_FromObject(Object1);
            string json2 = Convert_FromObject(Object2);

            bool result = (json1 == json2);

            if (result == false)  // Show where the differences are
            {
                var lines1 = json1.zConvert_Str_ToListStr("".NL());
                var lines2 = json2.zConvert_Str_ToListStr("".NL());

                var result2 = lines1.zIsEqual(lines2, out errorMsg);
            }

            return result;
        }

        /// <summary>Object synchronize from the JSon string.</summary>
        /// <param name="Object">The objectect</param>
        /// <param name="jsonStr">The json string</param>
        public void Object_Set(object Object, string jsonStr)
        {
            JObject json = JObject.Parse(jsonStr); 
            Object_Set(Object, json);
        }

        /// <summary>Object synchronize from the JSon string.</summary>
        /// <param name="Object">The object.</param>
        /// <param name="json">The json.</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        /// <returns></returns>
        public bool Object_Set(object Object, JObject json, bool showError = true)
        {
            string name = Object.ToString();
            string objectName = Object_GetName(json);
            foreach (KeyValuePair<string, JToken> item in json)
            {
                string property_orFieldName = item.Key;
                //if (property_orFieldName.zIn(objectName, "Name")) continue; // <=========================================

                // Search for property
                if (_Object_SetProperty(Object, property_orFieldName, item.Value) == false)
                {
                    // Property not found -> lets try to find a field
                    if (Object_SetField(Object, property_orFieldName, item.Value) == false)
                    {
                        if (property_orFieldName.ToLower() == "name") continue;  // If the class do not have a name -> ignore this
                        if (showError)
                        {
                            var ex = new ArgumentException($"Error! Property / Field '{property_orFieldName}' does not exist in object: '{name}'.", nameof(Object));
                            _lamed.Logger.LogMessage(ex);
                            throw ex;
                        }
                        // <========================================================================================
                    } 
                }
            }
            return true;
        }

        /// <summary>
        /// Finds the field in the object specified in the json string and update it.
        /// </summary>
        /// <param name="Object">The objectect</param>
        /// <param name="jsonStr">The json string</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        /// <returns></returns>
        public bool Object_SetField(object Object, string jsonStr, bool showError = true)
        {
            JObject json;
            var fieldName = _lamed.lib.IO.Json.Object_GetName(jsonStr, out json);
            var field = _lamed.Types.Class.ClassInfo.Field_Get(Object, fieldName);
            return _lamed.lib.IO.Json.Object_Set(field, json, showError);
        }

        /// <summary>Name of the object from the json string.</summary>
        /// <param name="jsonStr">The json string</param>
        /// <param name="json">Return the json</param>
        /// <returns>string</returns>
        public string Object_GetName(string jsonStr, out JObject json)
        {
            json = JObject.Parse(jsonStr);
            var name = Object_GetName(json);
            return name;
        }

        /// <summary>Name of the object from the json.</summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public string Object_GetName(JObject json)
        {
            return (string) json["Name"];
        }

        /// <summary>Sets the property of the object to the json token. Return false if the property was not found</summary>
        /// <param name="Object">The objectect</param>
        /// <param name="propertyName">The propertyerty name</param>
        /// <param name="propertyValue">The propertyerty valueue</param>
        public bool _Object_SetProperty(object Object, string propertyName, JToken propertyValue)
        {
            var objectType = Object.GetType();
            PropertyInfo propertyInfo = _lamed.Types.Class.ClassInfo.Property_AsPropertyInfo(objectType, propertyName);
            if (propertyInfo == null) return false;
            if (propertyName.ToLower() == "name") return true;  // We will not set name properties
            // ==========================================================================

            Type propertyType = propertyInfo.PropertyType;

            if (propertyInfo.CanWrite == false)
            {
                // property can not be created
                var property = propertyInfo.GetValue(Object);
                if (property is IList)
                {
                    IList listCurrent = _lamed.Types.Object.CastTo<IList>(property);
                    var listCurrent2 = _lamed.Types.List.Convert.IList_2IListT<string>(listCurrent);
                    List<string> listNew = propertyValue.ToObject<List<string>>();
                    _lamed.Types.List.Action.Copy_From_T(listCurrent2, listNew);
                    //listCurrent2.zFrom_IList(listNew);
                }
            }
            else
            {
                var value = propertyValue.ToObject(propertyType);
                propertyInfo.SetValue(Object, value, null);
            }
            return true;
        }

        /// <summary>Sets the property of the object to the json token. Return false if the property was not found</summary>
        /// <param name="Object">The objectect</param>
        /// <param name="fieldName">The propertyerty name</param>
        /// <param name="propertyValue">The propertyerty valueue</param>
        private bool Object_SetField(object Object, string fieldName, JToken propertyValue)
        {
            var fieldInfo = _lamed.Types.Class.ClassInfo.Field_AsFieldInfo(Object.GetType(), fieldName);
            if (fieldInfo == null) return false;

            Type fieldType = fieldInfo.FieldType;

            var value = propertyValue.ToObject(fieldType);
            fieldInfo.SetValue(Object, value);
            return true;
        }
    }
}
