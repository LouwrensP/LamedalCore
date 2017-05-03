using System.Collections.Generic;

namespace LamedalCore.lib.Words.WordsList
{
    public sealed class WordsList_CommonWords
    {
        private static List<string> _list;
        public static List<string> CommonWordsList_Create()
        {
           if (_list != null) return _list;
           _list = new List<string>();


            #region a-z
              _list.Add("a");
              _list.Add("able");
              _list.Add("about");
              _list.Add("across");
              _list.Add("after");
              _list.Add("all");
              _list.Add("almost");
              _list.Add("also");
              _list.Add("am");
              _list.Add("among");
              _list.Add("an");
              _list.Add("and");
              _list.Add("any");
              _list.Add("are");
              _list.Add("as");
              _list.Add("at");
              _list.Add("be");
              _list.Add("because");
              _list.Add("been");
              _list.Add("but");
              _list.Add("by");
              _list.Add("can");
              _list.Add("cannot");
              _list.Add("could");
              _list.Add("dear");
              _list.Add("did");
              _list.Add("do");
              _list.Add("does");
              _list.Add("either");
              _list.Add("else");
              _list.Add("ever");
              _list.Add("every");
              _list.Add("for");
              _list.Add("from");
              _list.Add("get");
              _list.Add("got");
              _list.Add("had");
              _list.Add("has");
              _list.Add("have");
              _list.Add("he");
              _list.Add("her");
              _list.Add("hers");
              _list.Add("him");
              _list.Add("his");
              _list.Add("how");
              _list.Add("however");
              _list.Add("i");
              _list.Add("if");
              _list.Add("in");
              _list.Add("into");
              _list.Add("is");
              _list.Add("it");
              _list.Add("its");
              _list.Add("just");
              _list.Add("least");
              _list.Add("let");
              _list.Add("like");
              _list.Add("likely");
              _list.Add("may");
              _list.Add("me");
              _list.Add("might");
              _list.Add("most");
              _list.Add("must");
              _list.Add("my");
              _list.Add("neither");
              _list.Add("no");
              _list.Add("nor");
              _list.Add("not");
              _list.Add("of");
              _list.Add("off");
              _list.Add("often");
              _list.Add("on");
              _list.Add("only");
              _list.Add("or");
              _list.Add("other");
              _list.Add("our");
              _list.Add("own");
              _list.Add("rather");
              _list.Add("said");
              _list.Add("say");
              _list.Add("says");
              _list.Add("she");
              _list.Add("should");
              _list.Add("since");
              _list.Add("so");
              _list.Add("some");
              _list.Add("than");
              _list.Add("that");
              _list.Add("the");
              _list.Add("their");
              _list.Add("them");
              _list.Add("then");
              _list.Add("there");
              _list.Add("these");
              _list.Add("they");
              _list.Add("this");
              _list.Add("tis");
              _list.Add("to");
              _list.Add("too");
              _list.Add("twas");
              _list.Add("us");
              _list.Add("wants");
              _list.Add("was");
              _list.Add("we");
              _list.Add("were");
              _list.Add("what");
              _list.Add("when");
              _list.Add("where");
              _list.Add("which");
              _list.Add("while");
              _list.Add("who");
              _list.Add("whom");
              _list.Add("why");
              _list.Add("will");
              _list.Add("with");
              _list.Add("would");
              _list.Add("yet");
              _list.Add("you");
              _list.Add("your");
            #endregion

            _list.Sort();
            return _list;
        }
    }
}
            