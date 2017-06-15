using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.Types.List
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class List_Queue
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>
        /// Treats list like a queue, appending <paramref name="value"/>.
        /// </summary>
        [DebuggerStepThrough]
        public void Enqueue<T>(IList<T> list, T value)
        {
            _lamed.Types.List.Stack.Push(list,value);
        }

        /// <summary>
        /// Treats list like a queue, removing and returning the
        /// first value.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if list is empty.
        /// </exception>
        [DebuggerStepThrough]
        public T Dequeue<T>(IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (list.Count == 0) return _lamed.Types.Object.DefaultValue<T>();

            var value = list.First();
            list.RemoveAt(0);
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

            return list.First();
        }

    }
}
