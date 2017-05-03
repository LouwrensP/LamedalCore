using System.Collections.Generic;
using System.Reflection;
using LamedalCore.zz;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LamedalCore.lib.IO
{
    /// <summary>
    /// Ths class helps with filtering out fields for json serialisation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
    public sealed class IO_Json_ContractResolver<T> : DefaultContractResolver
    {
        private readonly string[] _filterFields;
        private readonly List<string> _identifiedFields= new List<string>();
        public IO_Json_ContractResolver(params string[] fields) : base()
        {
            _filterFields = fields;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            // This code will not be reached because it is tested before this class in assigned. This test is commented out.
            //if (_filterFields.Length == 0)
            //{
            //    property.Ignored = false;
            //    return property;
            //}

            property.Ignored = true;
            int index;
            if (_filterFields.zSearchValue(member.Name, out index))
            {
                if (property.DeclaringType.GetTypeInfo().IsAssignableFrom(typeof(T)))
                {
                    _identifiedFields.Add(member.Name);
                    property.Ignored = false;
                }

            }

            return property;
        }

        /// <summary>Indicate if all the fields were found.</summary>
        /// <returns></returns>
        public bool AllFieldsWereFound()
        {
            return (_filterFields.Length == _identifiedFields.Count);
        }

        /// <summary>Return the fields that was missed.</summary>
        /// <returns></returns>
        public List<string> MissedFields()
        {
            var result = new List<string>();
            if (AllFieldsWereFound() == false)
            {
                foreach (string filterField in _filterFields)
                {
                    if (_identifiedFields.zFind_First(filterField) == false) result.Add(filterField);
                }
            }
            return result;
        }

        /// <summary>Return the missed fields as string.</summary>
        /// <returns>string</returns>
        public string MissedFields_AsStr()
        {
            var missed = MissedFields();
            var result = missed.zTo_Str(", ");
            return result;
        }
    }
}