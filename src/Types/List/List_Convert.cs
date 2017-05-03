using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamedalCore.Types.List
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Action, DefaultType = typeof(Array), IgnoreGroup = true, GroupName = "Word_FromAbbreviation")]
    public sealed class List_Convert
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>1 Demensional array converted to 2D array. Used in Excel operations</summary>
        /// <param name="array">The array to be converted</param>
        /// <param name="width">The width of the array</param>
        /// <returns>T[,]</returns>
        public T[,] Array_2TwoDimensionArray<T>(T[] array, int width)
        {
            int height = (int)Math.Ceiling(array.Length / (double)width);
            T[,] result = new T[height, width];

            for (int index = 0; index < array.Length; index++)
            {
                int rowIndex = index / width;
                int colIndex = index % width;
                result[rowIndex, colIndex] = array[index];
            }
            return result;
        }

        /// <summary>Conver Int list values to string ranges.</summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns></returns>
        public IEnumerable<string> Int_ToStrRanges(params int[] numbers)
        {
            int rangeStart = 0;
            int previous = 0;

            if (numbers.Any() == false) yield break;

            rangeStart = previous = numbers.FirstOrDefault();

            foreach (int n in numbers.Skip(1))
            {
                if (n - previous > 1) // sequence break - yield a sequence
                {
                    if (previous > rangeStart)
                        yield return string.Format("{0}-{1}", rangeStart, previous);
                    else yield return rangeStart.ToString();

                    rangeStart = n;
                }
                previous = n;
            }

            if (previous > rangeStart)
                yield return string.Format("{0}-{1}", rangeStart, previous);
            else yield return rangeStart.ToString();
        }

        /// <summary>
        /// Word_FromAbbreviation object list to string list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public IList<T> IListObject_2IListT<T>(IList<object> list)
        {
            List<T> stringList = list.Select(s => (T)s).ToList();
            return stringList;
        }

        /// <summary>Create List<T> from IList.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public IList<T> IList_2IListT<T>(IList list)
        {
            List<T> result = list.Cast<T>().ToList();
            return result;
        }

        /// <summary>Create List<T> from IList.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public List<T> IList_2ListT<T>(IList list)
        {
            var result = list.Cast<T>().ToList();
            return result;
        }

        /// <summary>Create List<T> from IList<T>.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public List<T> IListT_2ListT<T>(IList<T> list)
        {
            return ((List<T>)list);
        }


        /// <summary>Converts enumeral to IList.</summary>
        /// <param name="enumToConvert">typeof(myEnum) <br></br> The enum to convert.</param>
        /// <param name="clearList">if set to <c>true</c> [clear list].</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="postfix">The postfix.</param>
        /// <param name="replaceUnderscoreWith">The replace underscore with.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">list</exception>
        /// <code ShortcutClass="Enums" GenerateParameter1="enumToConvert"></code>
        [Test_IgnoreCoverage(enTestIgnore.MethodIsShortCut)]
        [BlueprintRule_MethodAliasDef(MirrorClass = typeof(Types_Enum), MirrorMethodName = "To_IList")]
        public IList<string> IList_FromEnum(Type enumToConvert, bool clearList = true, string prefix = "",
            string postfix = "", string replaceUnderscoreWith = "_")
        {
            var result = new List<string>();
            IList_FromEnum(result, enumToConvert, clearList, prefix, replaceUnderscoreWith);
            return result;
        }

        /// <summary>
        /// Converts enumeral to IList. 
        /// </summary>
        /// <param name="toList">The list.</param>
        /// <param name="enumToConvert">typeof(myEnum) <br></br> The enum to convert.</param>
        /// <param name="clearList">if set to <c>true</c> [clear list].</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="postfix">The postfix.</param>
        /// <param name="replaceUnderscoreWith">The replace underscore with.</param>
        /// <exception cref="System.ArgumentNullException">list</exception>
        /// <code ShortcutClass="Enums" GenerateParameter1="enumToConvert"></code>
        [BlueprintRule_MethodAliasDef(MirrorClass = typeof(Types_Enum), MirrorMethodName = "To_IList", MirrorParameter1 = "enumToConvert")]
        public void IList_FromEnum(IList toList, Type enumToConvert, bool clearList = true, string prefix = "", string postfix = "", string replaceUnderscoreWith = "_")
        {
            if (toList == null) throw new ArgumentNullException(nameof(toList));

            if (clearList) toList.Clear();
            foreach (var enumValue in Enum.GetNames(enumToConvert))
            {
                toList.Add(prefix + enumValue.Replace("_", replaceUnderscoreWith) + postfix);
            }
        }
    }
}