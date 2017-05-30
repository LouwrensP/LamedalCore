using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types.List
{
    public sealed class List_Action
    {

        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>Adds a range of values to the list.</summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="newValues">The new values.</param>
        public void AddRange<T, S>(ICollection<T> list, params S[] newValues) where S : T
        {
            foreach (S value in newValues) list.Add(value);
        }

        /// <summary>Copies items from one list to the other list.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toList">The list.</param>
        /// <param name="fromList">From list.</param>
        /// <param name="clearList">if set to <c>true</c> [clear list].</param>
        /// <param name="iiStart">The ii start.</param>
        /// <param name="iiEnd">The ii end.</param>
        public void Copy_From<T>(IList<T> toList, IList<T> fromList, bool clearList = true, int iiStart = 0, int iiEnd = -1)
        {
            Copy_To(fromList, toList, clearList, iiStart, iiEnd);
        }

        /// <summary>Copies array to List.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toList">To list.</param>
        /// <param name="fromArray">From array.</param>
        /// <param name="clearList">if set to <c>true</c> [clear list].</param>
        public void Copy_FromArray<T>(List<T> toList, bool clearList = true, params T[] fromArray)
        {
            if (clearList) toList.Clear();
            toList.AddRange(fromArray);
        }

        /// <summary>
        /// Copies items from one list to the other list.
        /// </summary>
        /// <param name="fromList">From list.</param>
        /// <param name="toList">To list.</param>
        /// <param name="clearList">if set to <c>true</c> [clear list].</param>
        /// <param name="indexStart">The ii start.</param>
        /// <param name="indexEnd">The ii end.</param>
        public void Copy_To<T>(IList<T> fromList, IList<T> toList, bool clearList = true, int indexStart = 0, int indexEnd = -1)
        {
            // Check arguments
            if (fromList == null) throw new ArgumentNullException(nameof(fromList)); 
            if (toList == null)   throw new ArgumentNullException(nameof(toList));
            if (indexStart < 0) indexStart = 0;
            if (indexEnd < 0) indexEnd = -1;

            if (clearList) toList.Clear();
            if (indexStart == 0 && indexEnd == -1)   // Copy all from fromList
            {
                ((List<T>)toList).AddRange(fromList);
                return;  //<========================================
            }

            // Only copy part of fromList; First make sure iiStart and indexEnd are within excepted bounds

            if (indexStart > fromList.Count - 1) indexStart = fromList.Count - 1;  // Make sure iiStart is within range
            if (indexEnd == -1 || indexEnd > fromList.Count - 1) indexEnd = fromList.Count - 1;  // Make sure indexEnd is within range
            for (var ii = indexStart; ii <= indexEnd; ii++)
            {
                var item = fromList[ii];
                toList.Add(item);
            }
        }

        /// <summary>Merge the values from two lists.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1">The list1.</param>
        /// <param name="list2">The list2.</param>
        /// <returns></returns>
        public IList<T> Merge<T>(IList<T> list1, IList<T> list2)
        {
            var result = new List<T>(list1.Count + list2.Count);
            Copy_To(list1, result);
            Copy_To(list2, result);
            return result;
        }

        /// <summary>
        /// Move the elements in an array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The array.</param>
        /// <param name="oldIndex">The old index.</param>
        /// <param name="newIndex">The new index.</param>
        public void MoveElements<T>(IList<T> list, int oldIndex, int newIndex)
        {
            if (oldIndex == newIndex) return; // No-op
            var old1 = list[oldIndex];
            list[oldIndex] = list[newIndex];
            list[newIndex] = old1;
        }

        /// <summary>Shuffles the specified source list.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public IEnumerable<T> Shuffle<T>(IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var rng = new Random();
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }

        /// <summary>Sorts the specified list.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="sort">if set to <c>true</c> [acending].</param>
        /// <returns></returns>
        public IList<T> Sort<T>(IList<T> list, enCompareSort sort = enCompareSort.Ascending)
        {
            switch (sort)
            {
                case enCompareSort.Ascending: return list.OrderBy(q => q).ToList();
                case enCompareSort.Descending: return list.OrderByDescending(q => q).ToList();
                case enCompareSort.NoSort: return list;
                default: throw new Exception($"Argument '{nameof(sort)}' error.");
            }
            return list;
        }

        /// <summary>Return a unique list.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">list</exception>
        public IList<T> Unique<T>(IList<T> list)
        {
            if (list == null) return null;   //throw new ArgumentNullException(nameof(list));
            IList<T> result = list.Distinct(EqualityComparer<T>.Default).ToList();
            return result;
        }

        /// <summary>Return a unique list.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">list</exception>
        public IList<string> Unique(IList<string> list)
        {
            // This method is here to prevent Unique<T>() to execute for strings.
            return Unique(list, enCompareSort.NoSort, false);
        }

        /// <summary>Return a unique list.</summary>
        /// <param name="list">The list.</param>
        /// <param name="sortType">if set to <c>true</c> [sort].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">list</exception>
        [BlueprintRule_MethodAliasDef(MirrorClass = typeof(List_String))]   // This implies the name and parameters stay the same
        public IList<string> Unique(IList<string> list, enCompareSort sortType = enCompareSort.NoSort, bool ignoreCase = false)
        {
            if (list == null) return null;   // throw new ArgumentNullException(nameof(list));

            var comparer = (ignoreCase) ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;
            var result = list.Distinct(comparer).ToList();
            return Sort(result,sortType);
        }

    }
}
