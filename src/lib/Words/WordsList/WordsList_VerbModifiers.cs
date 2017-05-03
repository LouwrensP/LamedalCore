using System.Collections.Generic;

namespace LamedalCore.lib.Words.WordsList
{
    public sealed class WordsList_VerbModifiers
    {
        private static List<string> _list;
        public static List<string> VerbModifiersList_Create()
        {
           if (_list != null) return _list;
           _list = new List<string>();


            #region a-z
              _list.Add("deeply");
              _list.Add("flawlessly");
              _list.Add("frequently");
              _list.Add("incessantly");
              _list.Add("quickly");
              _list.Add("relentlessly");
              _list.Add("slowly");
              _list.Add("surely");
              _list.Add("very");
            #endregion

            _list.Sort();
            return _list;
        }
    }
}
            