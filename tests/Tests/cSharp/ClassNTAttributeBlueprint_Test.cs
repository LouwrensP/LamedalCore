using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute.ClassNTBlueprintRule;
using Xunit;

namespace LamedalCore.Test.Tests.cSharp
{
    public partial class xUnit_cSharp // ClassNTAttributeBlueprint_Test
    {
        [Fact]
        [Test_Method("ClassNTBlueprintRule_Methods.BlueprintRule_Attributes()")]
        [Test_Method("ClassNTBlueprintRule_Methods.BlueprintRule_AttributeParameters()")]
        public void BlueprintRule_Attributes_Test1()
        {
            #region Parameters
            string name;
            List<string> parameters;
            string ignore1, ignore2, ignore3, ignore4;
            enBlueprint_ClassNetworkType classNetworkType;
            string attributeCode1;
            bool isBlueprintRule;
            string defaultGroup, groupName, ShortcutClass;
            Type defaultType;
            bool ignoreGroup, ignorePath, includeObjects;
            #endregion

            #region Test1: [BlueprintRule_Class(enClassNetwork.Node_Link)]
            // =========================================================================================================================================
            attributeCode1 = "[BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Link)]";
            isBlueprintRule = ClassNTBlueprintRule_Methods.BlueprintRule_Attributes(attributeCode1, out name, out parameters, out classNetworkType, out ignore1, out ignore2, out ignore3, out ignore4);
            Assert.Equal(true, isBlueprintRule);
            Assert.Equal(enBlueprint_ClassNetworkType.Node_Link, classNetworkType);
            Assert.Equal(1, parameters.Count);
            Assert.Equal(null, ignore1);
            Assert.Equal(null, ignore2);
            Assert.Equal(null, ignore3);
            Assert.Equal(null, ignore4);

            // Parameters
            if (isBlueprintRule)
            {
                ClassNTBlueprintRule_Methods.BlueprintRule_AttributeParameters(parameters, out defaultGroup, out defaultType, out groupName, out ignoreGroup, out ignorePath, out includeObjects, out ShortcutClass);

                Assert.Equal(null, defaultType);
                Assert.Equal(null, defaultGroup);
                Assert.Equal(null, groupName);
                Assert.Equal(false, ignoreGroup);
                Assert.Equal(false, ignorePath);
                Assert.Equal(false, includeObjects);
                Assert.Equal(null, ShortcutClass);
            }
            #endregion
        }

        [Fact]
        [Test_Method("ClassNTBlueprintRule_Methods.BlueprintRule_Attributes()")]
        [Test_Method("ClassNTBlueprintRule_Methods.BlueprintRule_AttributeParameters()")]
        public void BlueprintRule_Attributes_Test2()
        {

            #region Parameters

            string name;
            List<string> parameters;
            string ignore1, ignore2, ignore3, ignore4;
            enBlueprint_ClassNetworkType classNetworkType;
            string attributeCode1;
            bool isBlueprintRule;
            string defaultGroup, groupName, ShortcutClass;
            Type defaultType;
            bool ignoreGroup, ignorePath, includeObjects;

            #endregion

            #region Test2: [BlueprintRule_Class(enBlueprintClassNetworkType.CTIN, Ignore_Namespace1 = "Factory", Ignore_Namespace2 = "zz", Ignore_Namespace3 = "domain", Ignore_Namespace4 = "Testing")]
            // =========================================================================================================================================
            attributeCode1 = "[BlueprintRule_Class(enBlueprint_ClassNetworkType.CTIN, Ignore_Namespace1 = \"Factory\", Ignore_Namespace2 = \"zz\", Ignore_Namespace3 = \"domain\", Ignore_Namespace4 = \"Testing\")]";
            isBlueprintRule = ClassNTBlueprintRule_Methods.BlueprintRule_Attributes(attributeCode1, out name, out parameters, out classNetworkType, out ignore1, out ignore2, out ignore3, out ignore4);
            Assert.Equal(enBlueprint_ClassNetworkType.CTIN, classNetworkType);
            Assert.Equal("Factory", ignore1);
            Assert.Equal("zz", ignore2);
            Assert.Equal("domain", ignore3);
            Assert.Equal("Testing", ignore4);
            Assert.Equal(5, parameters.Count);
            Assert.Equal(true, isBlueprintRule);

            // Parameters
            if (isBlueprintRule)
            {
                ClassNTBlueprintRule_Methods.BlueprintRule_AttributeParameters(parameters, out defaultGroup, out defaultType, out groupName, out ignoreGroup, out ignorePath, out includeObjects, out ShortcutClass);

                Assert.Equal(null, defaultType);
                Assert.Equal(null, defaultGroup);
                Assert.Equal(null, groupName);
                Assert.Equal(false, ignoreGroup);
                Assert.Equal(false, ignorePath);
                Assert.Equal(false, includeObjects);
                Assert.Equal(null, ShortcutClass);
            }

            #endregion

        }

        [Fact]
        [Test_Method("ClassNTBlueprintRule_Methods.BlueprintRule_Attributes()")]
        [Test_Method("ClassNTBlueprintRule_Methods.BlueprintRule_AttributeParameters()")]
        public void BlueprintRule_Attributes_Test3()
        {
            #region Parameters
            string name;
            List<string> parameters;
            string ignore1, ignore2, ignore3, ignore4;
            enBlueprint_ClassNetworkType classNetworkType;
            string attributeCode1;
            bool isBlueprintRule;
            string defaultGroup, groupName, ShortcutClass;
            Type defaultType;
            bool ignoreGroup, ignorePath, includeObjects;
            #endregion

            #region Test3: [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Action, DefaultType = typeof(string), GroupName = "Str")]
            // =========================================================================================================================================
            attributeCode1 = "[BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, DefaultType = typeof(string), GroupName = \"Str\")]";
            isBlueprintRule = ClassNTBlueprintRule_Methods.BlueprintRule_Attributes(attributeCode1, out name, out parameters, out classNetworkType, out ignore1, out ignore2, out ignore3, out ignore4);
            Assert.Equal(true, isBlueprintRule);
            Assert.Equal(enBlueprint_ClassNetworkType.Node_Action, classNetworkType);
            Assert.Equal(3, parameters.Count);
            Assert.Equal(null, ignore1);
            Assert.Equal(null, ignore2);
            Assert.Equal(null, ignore3);
            Assert.Equal(null, ignore4);

            // Parameters
            if (isBlueprintRule)
            {
                ClassNTBlueprintRule_Methods.BlueprintRule_AttributeParameters(parameters, out defaultGroup, out defaultType, out groupName, out ignoreGroup, out ignorePath, out includeObjects, out ShortcutClass);

                Assert.Equal(typeof(string), defaultType);
                Assert.Equal(null, defaultGroup);
                Assert.Equal("Str", groupName);
                Assert.Equal(false, ignoreGroup);
                Assert.Equal(false, ignorePath);
                Assert.Equal(false, includeObjects);
                Assert.Equal(null, ShortcutClass);
            }
            #endregion

        }

        [Fact]
        [Test_Method("ClassNTBlueprintRule_Methods.BlueprintRule_Attributes()")]
        [Test_Method("ClassNTBlueprintRule_Methods.BlueprintRule_AttributeParameters()")]
        public void BlueprintRule_Attributes_Test4()
        {
            #region Parameters
            string name;
            List<string> parameters;
            string ignore1, ignore2, ignore3, ignore4;
            enBlueprint_ClassNetworkType classNetworkType;
            string attributeCode1;
            bool isBlueprintRule;
            string defaultGroup, groupName, ShortcutClass;
            Type defaultType;
            bool ignoreGroup, ignorePath, includeObjects;
            #endregion

            #region Test4: [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Action, DefaultType = typeof(Enum), GroupName = "Enum", ShortcutClass = "Enum_Blueprint")]
            // =========================================================================================================================================
            attributeCode1 = "[BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, DefaultType = typeof(Enum), GroupName = \"Enum\", ShortcutClass = \"Enum_Blueprint\")]";
            isBlueprintRule = ClassNTBlueprintRule_Methods.BlueprintRule_Attributes(attributeCode1, out name, out parameters, out classNetworkType, out ignore1, out ignore2, out ignore3, out ignore4);
            Assert.Equal(true, isBlueprintRule);
            Assert.Equal(enBlueprint_ClassNetworkType.Node_Action, classNetworkType);
            Assert.Equal(4, parameters.Count);
            Assert.Equal(null, ignore1);
            Assert.Equal(null, ignore2);
            Assert.Equal(null, ignore3);
            Assert.Equal(null, ignore4);

            // Parameters
            if (isBlueprintRule)
            {
                ClassNTBlueprintRule_Methods.BlueprintRule_AttributeParameters(parameters, out defaultGroup, out defaultType, out groupName, out ignoreGroup, out ignorePath, out includeObjects, out ShortcutClass);

                Assert.Equal(typeof(Enum), defaultType);
                Assert.Equal(null, defaultGroup);
                Assert.Equal("Enum", groupName);
                Assert.Equal(false, ignoreGroup);
                Assert.Equal(false, ignorePath);
                Assert.Equal(false, includeObjects);
                Assert.Equal("Enum_Blueprint", ShortcutClass);
            }
            #endregion
        }

        [Fact]
        [Test_Method("ClassNTBlueprintRule_Methods.BlueprintRule_Attributes()")]
        [Test_Method("ClassNTBlueprintRule_Methods.BlueprintRule_AttributeParameters()")]
        public void BlueprintRule_Attributes_Test5()
        {
            #region Parameters
            string name;
            List<string> parameters;
            string ignore1, ignore2, ignore3, ignore4;
            enBlueprint_ClassNetworkType classNetworkType;
            string attributeCode1;
            bool isBlueprintRule;
            string defaultGroup, groupName, ShortcutClass;
            Type defaultType;
            bool ignoreGroup, ignorePath, includeObjects;
            #endregion

            #region Test5: [BlueprintRule_Class(enBlueprintClassNetworkType.Transformation_Extention, DefaultGroup = "default group", DefaultType = typeof(string), GroupName = "group name", IgnoreGroup = true, IgnoreGroupPath = true, Ignore_Namespace1 = "ignore 1", ShortcutClass = "Shortcut Class")]
            // =========================================================================================================================================
            attributeCode1 = "[BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Extention, DefaultGroup = \"default group\", DefaultType = typeof(string), GroupName = \"group name\", IgnoreGroup = true, IgnoreGroupPath = true, Ignore_Namespace1 = \"ignore 1\", ShortcutClass = \"Shortcut Class\")]";
            isBlueprintRule = ClassNTBlueprintRule_Methods.BlueprintRule_Attributes(attributeCode1, out name, out parameters, out classNetworkType, out ignore1, out ignore2, out ignore3, out ignore4);
            Assert.Equal(true, isBlueprintRule);
            Assert.Equal(enBlueprint_ClassNetworkType.Transformation_Extention, classNetworkType);
            Assert.Equal(8, parameters.Count);
            Assert.Equal("ignore 1", ignore1);
            Assert.Equal(null, ignore2);
            Assert.Equal(null, ignore3);
            Assert.Equal(null, ignore4);

            // Parameters
            if (isBlueprintRule)
            {
                ClassNTBlueprintRule_Methods.BlueprintRule_AttributeParameters(parameters, out defaultGroup, out defaultType, out groupName, out ignoreGroup, out ignorePath, out includeObjects, out ShortcutClass);
                Assert.Equal("default_group", defaultGroup);
                Assert.Equal(typeof(string), defaultType);
                Assert.Equal("group_name", groupName);
                Assert.Equal(true, ignoreGroup);
                Assert.Equal(true, ignorePath);
                Assert.Equal(false, includeObjects);
                Assert.Equal("Shortcut_Class", ShortcutClass);
            }
            #endregion
        }
    }
}
