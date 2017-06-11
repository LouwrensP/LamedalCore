using System;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.domain.Attributes
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.BlueprintRuleDef)]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class Blueprint_enumAttribute : Attribute
    {
        // ========================
        // CodeValue
        public string CodeValue
        {
            get { return _codeValue; }
        }
        private readonly string _codeValue;

        // ========================
        // Value
        public int Value
        {
            get { return _value; }
        }
        private readonly int _value;


        public Blueprint_enumAttribute(string codeValue)
        {
            this._codeValue = codeValue;
        }

        public Blueprint_enumAttribute(int value)
        {
            this._value = value;
        }

        public Blueprint_enumAttribute(int value, string codeValue)
        {
            this._codeValue = codeValue;
            this._value = value;
        }

    }
}
