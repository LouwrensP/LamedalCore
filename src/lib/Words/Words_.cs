using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.Words.WordsList;
using LamedalCore.zz;

namespace LamedalCore.lib.Words
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Link)]
    public sealed class Words_
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        #region LoadList
        /// <summary>
        /// Gets the LoadList library methods.
        /// </summary>
        public Words_LoadList LoadList
        {
            get { return _LoadList ?? (_LoadList = new Words_LoadList()); }
        }
        private Words_LoadList _LoadList;
        #endregion

        /// <summary> Function to ignore prefixes process. </summary>
        /// <code>Tested</code>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        public string Prefixes_Remove(string input)
        {
            // Ignore the prefixes
            IList<string> listPrefix = enWord_List.Prefixes.zLoadList();
            string buffer = _lamed.Types.String.Edit.Remove_Prefix(input, listPrefix.ToArray());
            return buffer;
        }

        #region Convert
        /// <summary>Return the word for the abbreviation.</summary>
        /// <param name="word">The word.</param>
        /// <param name="dictionary2Use">The dictionary2 use.</param>
        /// <returns></returns>
        public string Convert_Word(string word, enWord_Dictionary dictionary2Use)
        {
            IDictionary<string, string> wordDictionary = dictionary2Use.zLoadDictionary();
            string result;
            if (wordDictionary.TryGetValue(word, out result)) return result;

            return word;
        }

        /// <summary>Converts the abreviation to word.</summary>
        /// <param name="abbriviation">The abbriviation.</param>
        /// <returns></returns>
        public string Convert_Abreviation2Word(string abbriviation)
        {
            return Convert_Word(abbriviation, enWord_Dictionary.Abbreviation_2Word);
        }

        /// <summary>Converts the word to the abreviation.</summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public string Convert_AbreviationFromWord(string word)
        {
            return Convert_Word(word, enWord_Dictionary.Abbreviation_FromWord);
        }

        /// <summary>Converts the simple english to the complex word.</summary>
        /// <param name="simpleEnglish">The simple english.</param>
        /// <returns></returns>
        public string Convert_SimpleEnglish2Word(string simpleEnglish)
        {
            return Convert_Word(simpleEnglish, enWord_Dictionary.SimpleEnglish_2Word);
        }

        /// <summary>Converts the word to the simple english version.</summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public string Convert_SimpleEnglishFromWord(string word)
        {
            return Convert_Word(word, enWord_Dictionary.SimpleEnglish_FromWord);
        }
        #endregion

        #region Is
        /// <summary>Determines whether the specified word is acronym.</summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public bool IsAcronym(string word)
        {
            return IsInWordList(enWord_List.Acronyms, word, false);
        }

        /// <summary>Determines whether [word] is in [the specified word list].</summary>
        /// <param name="enWordList">The word list.</param>
        /// <param name="word">The word.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns></returns>
        public bool IsInWordList(enWord_List enWordList, string word, bool ignoreCase = true)
        {
            var list = (List<string>)enWordList.zLoadList();
            return _lamed.Types.String.List.Find_First(list, word, true, ignoreCase);
            //var index = list.BinarySearch(word);
            //if (index < 0) return false;
            //return true;
        }

        /// <summary>Determines whether the specified word is a common word.</summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public bool IsCommonWord(string word)
        {
            return IsInWordList(enWord_List.CommonWords, word);
        }

        /// <summary>Determines whether the specified word is a property.</summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public bool IsProperty(string word)
        {
            return IsInWordList(enWord_List.Properties, word);
        }

        /// <summary>Determines whether [is type name] [the specified word].</summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public bool IsTypeName(string word)
        {
            return IsInWordList(enWord_List.TypeNames, word);
        }

        /// <summary>Determines whether the specified word is verb.</summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public bool IsVerb(string word)
        {
            return IsInWordList(enWord_List.Verbs, word);
        }

        /// <summary>Determines whether [is verb modifier] [the specified word].</summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public bool IsVerbModifier(string word)
        {
            return IsInWordList(enWord_List.VerbModifiers, word);
        }

        /// <summary>Determines whether [is word not to use] [the specified word].</summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public bool IsWordNotToUse(string word)
        {
            return IsInWordList(enWord_List.WordsNotToUse, word);
        }
        #endregion
    }
}
