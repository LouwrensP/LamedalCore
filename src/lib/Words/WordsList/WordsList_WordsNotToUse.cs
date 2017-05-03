using System.Collections.Generic;

namespace LamedalCore.lib.Words.WordsList
{
    public sealed class WordsList_WordsNotToUse
    {
        private static List<string> _list;
        public static List<string> WordsNotToUseList_Create()
        {
           if (_list != null) return _list;
           _list = new List<string>();


            #region a-z
              _list.Add("a");
              _list.Add("all");
              _list.Add("an");
              _list.Add("another");
              _list.Add("any");
              _list.Add("anything");
              _list.Add("as");
              _list.Add("at");
              _list.Add("down");
              _list.Add("for");
              _list.Add("from");
              _list.Add("her");
              _list.Add("his");
              _list.Add("it");
              _list.Add("if");
              _list.Add("its");
              _list.Add("my");
              _list.Add("me");
              _list.Add("our");
              _list.Add("some");
              _list.Add("something");
              _list.Add("the");
              _list.Add("their");
              _list.Add("to");
              _list.Add("up");
              _list.Add("you");
              _list.Add("your");
            #endregion

            _list.Sort();
            return _list;
        }
    }
}
            