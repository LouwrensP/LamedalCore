using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.lib.Words
{
    public sealed partial class Words_LoadList
    {
        /// <summary>Return dictionary of abbreviation to word.</summary>
        /// <returns></returns>
        public IDictionary<string, string> WordConversionDictionary(enWord_Dictionary wordDictionary)
        {
            IDictionary<string, string> result = null;
            switch (wordDictionary)
            {
                case enWord_Dictionary.Abbreviation_2Word:
                    result = _abbr2WordDict ?? (_abbr2WordDict = _lamed.Types.List.String.ToDictionary(enWord_List.Abbreviations.zLoadList(), "="));
                    break;
                case enWord_Dictionary.Abbreviation_FromWord:
                    result = _abbrFromWordDict ?? (_abbrFromWordDict = _lamed.Types.List.String.ToDictionary(enWord_List.Abbreviations.zLoadList(), "=", true));
                    break;
                case enWord_Dictionary.SimpleEnglish_2Word:
                    result = _simpEngl2WordDict ?? (_simpEngl2WordDict = _lamed.Types.List.String.ToDictionary(enWord_List.SimpleEnglishWords.zLoadList(), "=", true));
                    break;
                case enWord_Dictionary.SimpleEnglish_FromWord:
                    result = _simpEnglFromWordDict ?? (_simpEnglFromWordDict = _lamed.Types.List.String.ToDictionary(enWord_List.SimpleEnglishWords.zLoadList(), "="));
                    break;
            }
            return result;
        }
        private static IDictionary<string, string> _abbr2WordDict = null;
        private static IDictionary<string, string> _abbrFromWordDict = null;
        private static IDictionary<string, string> _simpEngl2WordDict = null;
        private static IDictionary<string, string> _simpEnglFromWordDict = null;
    }

    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Connector)]
    public static class Words_LoadList_Static
    {
        // <summary>Loads the word list.</summary>
        /// <param name="wordList">The word list.</param>
        /// <returns></returns>
        public static IList<string> zLoadList(this enWord_List wordList)
        {
            return LamedalCore_.Instance.lib.Words.LoadList.LoadList(wordList);
        }

        // <summary>Loads the word list.</summary>
        /// <param name="wordDictionary">The word list.</param>
        /// <returns></returns>
        public static IDictionary<string, string> zLoadDictionary(this enWord_Dictionary wordDictionary)
        {
            return LamedalCore_.Instance.lib.Words.LoadList.WordConversionDictionary(wordDictionary);
        }
    }

}
