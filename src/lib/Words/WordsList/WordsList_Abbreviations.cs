using System.Collections.Generic;

namespace LamedalCore.lib.Words.WordsList
{
    public sealed class WordsList_Abbreviations
    {
        private static List<string> _list;
        public static IList<string> AbbreviationsList_Create()
        {
           if (_list != null) return _list;
           _list = new List<string>();

            #region a-c
              _list.Add("abbr=abbreviation");
              _list.Add("agg=aggregate");
              _list.Add("app=application");
              _list.Add("arg=argument");
              _list.Add("args=arguments");
              _list.Add("async=asynchronous");
              _list.Add("attr=attribute");
              _list.Add("attrib=attribute");
              _list.Add("auth=authentication");
              _list.Add("auto=automatic");
              _list.Add("avg=average");
              _list.Add("bak=backup");
              _list.Add("bp=blueprint");
              _list.Add("calc=calculate");
              _list.Add("char=character");
              _list.Add("chr=character");
              _list.Add("clr=color");
              _list.Add("cmd=command");
              _list.Add("comms=communication");
              _list.Add("config=configuration");
              _list.Add("conn=connection");
              _list.Add("const=constant");
              _list.Add("cnt=count");
              _list.Add("ctl=control");
              _list.Add("ctrl=control");
              _list.Add("cur=current");
              _list.Add("cust=customer");
            #endregion

            #region d-i
              _list.Add("db=database");
              _list.Add("dbsetup=database setup");
              _list.Add("dbl=double");
              _list.Add("dbg=debug");
              _list.Add("dec=decimal");
              _list.Add("def=definition");
              _list.Add("del=delete");
              _list.Add("delim=delimiter");
              _list.Add("descr=description");
              _list.Add("dict=dictionary");
              _list.Add("diff=difference");
              _list.Add("dlg=dialog");
              _list.Add("doc=document");
              _list.Add("dte=Development Tools Environment");
              _list.Add("enum=enumeral");
              _list.Add("err=error");
              _list.Add("esc=escape");
              _list.Add("exe=executable");
              _list.Add("exec=execute");
              _list.Add("fld=field");
              _list.Add("fk=foreign key");
              _list.Add("pk=primary key");
              _list.Add("ak=alternate key");
              _list.Add("fn=function");
              _list.Add("func=function");
              _list.Add("fwd=forward");
              _list.Add("guid=global unique identifier");
              _list.Add("hex=hexadecimal");
              _list.Add("ico=icon");
              _list.Add("id=identifier");
              _list.Add("idx=index");
              _list.Add("impl=implementation");
              _list.Add("info=information");
              _list.Add("init=initialize");
              _list.Add("ipc=inter process communication");
            #endregion

            #region l-r
              _list.Add("lang=language");
              _list.Add("lbl=label");
              _list.Add("len=length");
              _list.Add("lib=library");
              _list.Add("lvl=level");
              _list.Add("max=maximum");
              _list.Add("mem=memory");
              _list.Add("min=minimum");
              _list.Add("MTI=method transformation information");
              _list.Add("nl=new line");
              _list.Add("nu=number");
              _list.Add("num=number");
              _list.Add("obj=object");
              _list.Add("orig=original");
              _list.Add("param=parameter");
              _list.Add("params=parameters");
              _list.Add("phys=physical");
              _list.Add("pos=position");
              _list.Add("pref=preference");
              _list.Add("prev=previous");
              _list.Add("prod=product");
              _list.Add("prop=property");
              _list.Add("prj=project");
              _list.Add("pwd=password");
              _list.Add("q=single quote");
              _list.Add("qq=double quote");
              _list.Add("rec=record");
              _list.Add("ref=reference");
              _list.Add("rel=relative");
              _list.Add("res=resource");
              _list.Add("rnd=random");
            #endregion

            #region s-z
              _list.Add("src=source");
              _list.Add("std=standard");
              _list.Add("stmt=statement");
              _list.Add("str=string");
              _list.Add("struct=structure");
              _list.Add("substr=sub-string");
              _list.Add("sync=synchronize");
              _list.Add("sys=system");
              _list.Add("tbl=table");
              _list.Add("temp=temporary");
              _list.Add("tmp=temporary");
              _list.Add("txt=text");
              _list.Add("util=utility");
              _list.Add("uri=uniform resource identifier");
              _list.Add("val=value");
              _list.Add("var=variable");
              _list.Add("xelement=xml element");
            #endregion

            _list.Sort();
            return _list;
        }
    }
}
            