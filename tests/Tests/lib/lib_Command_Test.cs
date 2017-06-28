﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass;
using Xunit;
using Xunit.Abstractions;
using HtmlAgilityPack;
using LamedalCore.zPublicClass.Test;

namespace LamedalCore.Test.Tests.lib
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public sealed class lib_Command_Test: pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        public lib_Command_Test(ITestOutputHelper debug = null) : base(debug) { }

        
        [Fact]
        [Test_Method("Execute_Notepad()")]
        public void Execute_Notepad_Test()
        {
            string folderTest = pcTest_Config.TestFolder();
            string folderApplication;
            string folderTestCases;
            pcTest_ConfigData config;
            string configFile;
            bool result = _lamed.lib.Test.ConfigSettings(out folderApplication, out folderTestCases, out config, out configFile);
            if (result == false)
            {
                // This code will not be tested
                _lamed.lib.Command.Sleep(1000);  // Sleep 1 more seconds and try again 
                result = _lamed.lib.Test.ConfigSettings(out folderApplication, out folderTestCases, out config, out configFile);
                if (result == false) return; //<======================================[ Lets give up
            }

            // Lets do the tests
            Assert.Equal(folderTest, folderTestCases);
            Assert.True(_lamed.lib.IO.File.Exists(configFile));

            if (pcTest_Config.Test_ShowConfigFiles) _lamed.lib.Command.Execute_Notepad(configFile);   // Hide / show config files

            // Todo
            // Test if notepad is running
            // Kill notepad
            // Test if notepad is running
        }
    }
}
