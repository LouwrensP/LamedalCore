using System.Collections.Generic;

namespace LamedalCore.lib.Words.WordsList
{
    public sealed class WordsList_TypeNames
    {
        private static List<string> _list;
        public static List<string> TypeNamesList_Create()
        {
           if (_list != null) return _list;
           _list = new List<string>();


            #region a-z
              _list.Add("AutoMark");
              _list.Add("CheckBox");
              _list.Add("ComboBox");
              _list.Add("DataSet");
              _list.Add("Dexter");
              _list.Add("FileStream");
              _list.Add("IList");
              _list.Add("ListBox");
              _list.Add("ListView");
              _list.Add("MemoryStream");
              _list.Add("MessageBox");
              _list.Add("PictueBox");
              _list.Add("RadioButton");
              _list.Add("TreeView");
              _list.Add("TextBox");
              _list.Add("WebBrowser");
            #endregion

            _list.Sort();
            return _list;
        }
    }
}
            