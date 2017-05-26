using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.Words.WordsList;
using LamedalCore.zz;

namespace LamedalCore.lib.Words
{
    /// <summary>
    /// Load the word lists for use. This is a generated class
    /// </summary>
    public sealed partial class Words_LoadList
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>Loads the word list.</summary>
        /// <param name="wordList">The word list.</param>
        /// <returns></returns>
        public IList<string> LoadList(enWord_List wordList)
        {
            IList<string> result = null;
            switch (wordList)
            {
              case enWord_List.Abbreviations : result = WordsList_Abbreviations.AbbreviationsList_Create(); break;
              case enWord_List.Acronyms : result = WordsList_Acronyms.AcronymsList_Create(); break;
                case enWord_List.CommonWords : result = WordsList_CommonWords.CommonWordsList_Create(); break;
                case enWord_List.Prefixes : result = WordsList_Prefixes.PrefixesList_Create(); break;
                case enWord_List.Properties : result = WordsList_Properties.PropertiesList_Create(); break;
                case enWord_List.SimpleEnglishWords : result = WordsList_SimpleEnglishWords.SimpleEnglishWordsList_Create(); break;
                case enWord_List.TypeNames : result = WordsList_TypeNames.TypeNamesList_Create(); break;
                case enWord_List.VerbModifiers : result = WordsList_VerbModifiers.VerbModifiersList_Create(); break;
                case enWord_List.Verbs : result = WordsList_Verbs.VerbsList_Create(); break;
                case enWord_List.WordsNotToUse : result = WordsList_WordsNotToUse.WordsNotToUseList_Create(); break;
                default: throw new Exception($"Argument '{nameof(wordList)}' error.");
            }
            return result;
        }
    }
}