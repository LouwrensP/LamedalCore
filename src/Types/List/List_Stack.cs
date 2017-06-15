using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types.List
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class List_Stack
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>
        /// Treats list like a stack, pushing <paramref name="value"/>
        /// on to the list; in other words adding it to the end of 
        /// the list.
        /// </summary>
        [DebuggerStepThrough]
        public void Push<T>(IList<T> list, T value)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            list.Add(value);
        }

        /// <summary>
        /// Treats list like a stack, popping (removing and returning)
        /// the last value on the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerStepThrough]
        public T Pop<T>(IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (list.Count == 0) return _lamed.Types.Object.DefaultValue<T>();

            var value = list.Last();
            list.RemoveAt(list.Count -1);
            return value;
        }


        /// <summary>Treats list like a stack, peeking and return the last value on the list.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">list</exception>
        [DebuggerStepThrough]
        public T Peek<T>(IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (list.Count == 0) return _lamed.Types.Object.DefaultValue<T>();

            return list.Last();
        }


    }
}
