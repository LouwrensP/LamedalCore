using System;
using System.Runtime.CompilerServices;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types.Class
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Extention)]
    public sealed class Class_StateInfo
    {
        // private readonly TypeState_ _singletonTypeState = TypeState_.Instance; // Get reference to this class

        #region Singleton of TypeState_
        private static readonly Class_StateInfo _TypeState_ = new Class_StateInfo();  // This is the only instance of this class
        private Class_StateInfo()
        {
            // Private constructor prevents creation by external clients
        }

        /// <summary>
        /// Return Instance of TypeState_
        /// </summary>
        public static Class_StateInfo Instance
        {
            get { return _TypeState_; }
        }
        #endregion

        private static readonly ConditionalWeakTable<object, object> _properties = new ConditionalWeakTable<object, object>();

        /// <summary>Sets the extension key.</summary>
        /// <param name="key">The key</param>
        /// <param name="value">The valueue</param>
        public void Key_Set<T>(object key, T value)
        {
            object o;
            if (_properties.TryGetValue(key, out o))
            {
                _properties.Remove(key);
            }
            _properties.Add(key, value);
        }

        /// <summary>Gets the extension key from the key.</summary>
        /// <param name="key">The key</param>
        /// <param name="autoCreate">Automatic create the value</param>
        /// <returns>T</returns>
        public T Key_Get<T>(object key, bool autoCreate = true)
        {
            object o;
            if (_properties.TryGetValue(key, out o))
            {
                if (o is T) return (T)o;
                else
                {
                    var errMsg = ("Error! State type mismatch:".NL() + "Expected; '{0}',".NL() + " Got: '{1}'").zFormat(typeof(T).Name, o.GetType().Name);
                    throw new InvalidOperationException(errMsg);
                }
            }
            if (autoCreate == false) return default(T);

            // Create the value
            T value = CreateState<T>();
            Key_Set(key, value);
            return value;
        }

        /// <summary>Gets the extension key from the key.</summary>
        /// <param name="key">The key</param>
        /// <param name="autoCreate">Automatic create the value</param>
        /// <returns>T</returns>
        public object Key_Get(object key, bool autoCreate = true)
        {
            return Key_Get<object>(key, autoCreate);
        }

        /// <summary>
        /// Creates the type specified
        /// </summary>
        /// <returns>T</returns>
        private static T CreateState<T>()
        {
            //(T)Activator.CreateInstance(typeof(T), new object[] { constructorParameter });
            var Object = Activator.CreateInstance(typeof(T), new object[] { });
            var newState = (T)Object;
            return newState;
        }

    }
}
