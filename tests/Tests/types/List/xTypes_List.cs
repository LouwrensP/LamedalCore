﻿using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.Test;
using Xunit;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests.types.List
{
    [Trait("Category", "Types")]
    [Trait("Category", "Types List")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xTypes_List : pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        public xTypes_List(ITestOutputHelper debug = null) : base(debug) { }

    }
}