//#define TEST

#if TEST
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.Test.Tests.cSharp;
using LamedalCore.Test.Tests.domain;
using LamedalCore.Test.Tests.lib;
using LamedalCore.Test.Tests.lib.XML;
using LamedalCore.Test.Tests.libIO;
using LamedalCore.Test.Tests.types.Class;
using LamedalCore.Test.Tests.types.List;
using LamedalCore.Test.Tests.types.other;
using LamedalCore.Test.Tests.types.String;
using LamedalCore.Test.Tests.zPublicClass;
using Xunit.Abstractions;
#endif

namespace LamedalCore.Test
{
#if TEST
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class cSharp_Test : xUnit_cSharp
    {
        public cSharp_Test(ITestOutputHelper debug = null) : base(debug) { }
    }

    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class domain_Test : xDomain
    {
    }

    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class lib_Test : xLib
    {
        public lib_Test(ITestOutputHelper debug = null) : base(debug) { }
    }

    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class libIO_Test : xLibIO
    {
        public libIO_Test(ITestOutputHelper debug = null) : base(debug) { }
    }

    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class libXML_Test : xLibXML
    {
        public libXML_Test(ITestOutputHelper debug = null) : base(debug) { }
    }

    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class TypesClass_Test : xTypes_Class
    {
        public TypesClass_Test(ITestOutputHelper debug = null) : base(debug) { }
    }

    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class TypesList_Test : xTypes_List
    {
        public TypesList_Test(ITestOutputHelper debug = null) : base(debug) { }
    }

    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class TypesOther_Test : xTypes_Other
    {
    }

    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class TypesString_Test : xTypes_String
    {
        public TypesString_Test(ITestOutputHelper debug = null) : base(debug) { }
    }

    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class zPublicClass_Test : xPublicClass
    {
        public zPublicClass_Test(ITestOutputHelper debug = null) : base(debug) { }
    }
#endif
}