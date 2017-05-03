using System.Collections.Generic;

namespace LamedalCore.lib.Words.WordsList
{
    public sealed class WordsList_Properties
    {
        private static List<string> _list;
        public static List<string> PropertiesList_Create()
        {
           if (_list != null) return _list;
           _list = new List<string>();


            #region the color of
              _list.Add("color");
              _list.Add("content");
              _list.Add("duration");
              _list.Add("height");
              _list.Add("index");
              _list.Add("kind");
              _list.Add("length");
              _list.Add("name");
              _list.Add("size");
              _list.Add("state");
              _list.Add("type");
              _list.Add("width");
            #endregion

            _list.Sort();
            return _list;
        }
    }
}
            