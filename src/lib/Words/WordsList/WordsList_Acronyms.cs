using System.Collections.Generic;

namespace LamedalCore.lib.Words.WordsList
{
    public sealed class WordsList_Acronyms
    {
        private static List<string> _list = null;
        public static List<string> AcronymsList_Create()
        {
           if (_list != null) return _list;

             _list = new List<string>();

            #region a-f
              _list.Add("ADO");
              _list.Add("ANSI");
              _list.Add("AK");
              _list.Add("ASCII");
              _list.Add("API");
              _list.Add("ASP");
              _list.Add("ARGB");
              _list.Add("BLOB");
              _list.Add("BOID");
              _list.Add("CAB");
              _list.Add("CDO");
              _list.Add("CLSID");
              _list.Add("COM");
              _list.Add("CTI");
              _list.Add("DAO");
              _list.Add("DCOM");
              _list.Add("DES");
              _list.Add("DOM");
              _list.Add("DSA");
              _list.Add("DTE");
              _list.Add("ECMA");
              _list.Add("EBCDIC");
              _list.Add("EMF");
              _list.Add("EOF");
              _list.Add("ETP");
              _list.Add("EULA");
              _list.Add("FK");
              _list.Add("FAQ");
            #endregion

            #region g-m
              _list.Add("GDI");
              _list.Add("GIF");
              _list.Add("GUID");
              _list.Add("GUI");
              _list.Add("IDE");
              _list.Add("IDL");
              _list.Add("IIS");
              _list.Add("IME");
              _list.Add("ISAPI");
              _list.Add("IO");
              _list.Add("JIT");
              _list.Add("JPEG");
              _list.Add("LDAP");
              _list.Add("MDI");
              _list.Add("MIME");
              _list.Add("MSIL");
              _list.Add("MPEG");
              _list.Add("MRU");
              _list.Add("MSDE");
              _list.Add("MTA");
              _list.Add("MUI");
            #endregion

            #region o-z
              _list.Add("ODBC");
              _list.Add("OLE");
              _list.Add("POP3");
              _list.Add("PK");
              _list.Add("RAD");
              _list.Add("RESX");
              _list.Add("RSA");
              _list.Add("SAX");
              _list.Add("SDI");
              _list.Add("SOAP");
              _list.Add("UDP");
              _list.Add("UI");
              _list.Add("URL");
              _list.Add("URI");
              _list.Add("UTC");
              _list.Add("UTF8");
              _list.Add("UTF16");
              _list.Add("UUID");
              _list.Add("VSA");
              _list.Add("VSIP");
              _list.Add("WMI");
              _list.Add("XML");
            #endregion

            _list.Sort();
            return _list;
        }
    }
}
            