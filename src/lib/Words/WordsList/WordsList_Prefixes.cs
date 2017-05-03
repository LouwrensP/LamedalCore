using System.Collections.Generic;

namespace LamedalCore.lib.Words.WordsList
{
    public sealed class WordsList_Prefixes
    {
        private static List<string> _list;
        public static List<string> PrefixesList_Create()
        {
           if (_list != null) return _list;
           _list = new List<string>();


            #region a-z
              _list.Add("bp");
              _list.Add("z");
              _list.Add("zz");
            #endregion

            _list.Sort();
            return _list;
        }
    }
}
            