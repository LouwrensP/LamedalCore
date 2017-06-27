using System;
using LamedalCore.zz;
using Xunit.Abstractions;

namespace LamedalCore.zPublicClass.Test
{
    /// <summary>
    /// Create simple test hookup class
    /// </summary>
    public class Config_Info
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        public static bool Test_ShowConfigFiles = false;
        public static string Test_Drive = "D:/";

        private static bool   _FirstTime = true;
        private static string _folderTestCases = "";
        private static string _folderApplication;
        private static string _configFile;
        private static pcTest_ConfigData _config;
        private static ITestOutputHelper _Debug;

        /// <summary>Make sure the tests data folders are configured correctly.</summary>
        /// <param name="debug">The debug.</param>
        /// <param name="add2Path">The add2 path.</param>
        /// <returns>The test folder where the test data is located</returns>
        public string Config_File_Test(ITestOutputHelper debug, string add2Path = "")
        {
            if (_FirstTime == false) return _folderTestCases + add2Path;  // Ensure that this method is only run once

            _Debug = debug;
            var success  = LamedalCore_.Instance.lib.Test.ConfigSettings(out _folderApplication, out _folderTestCases, out _config, out _configFile);
            if (success == false)
            {
                var msg = "Error! Unit test folder settings are incorrect.".NL() +
                    "  Please correct. (Opening the running folder and the 'Config.json' file.".NL()+
                    $"  + Excel test case folder: '{_folderTestCases}'".NL() +
                    $"  + Application Folder    : '{_folderApplication}'";
                var ex = new InvalidOperationException(msg);
                _lamed.Logger.LogLibraryMsg(ex);
                throw ex;
            }

            // Testcase folder specified
            if (_lamed.lib.IO.Folder.Exists(_folderTestCases) == false)
            {
                var msg = $"Error! Test case folder '{_folderTestCases}' does not exist.".NL() +
                          $"  Please correct in 'Config.json' file in folder '{_folderApplication}'";
                var ex = new InvalidOperationException(msg);
                _lamed.Logger.LogLibraryMsg(ex);
                throw ex;
            }

            _FirstTime = false;   // Only make flag false once we have tested everything works fine.

            var result = _folderTestCases + add2Path;
            LamedalCore_.Instance.lib.IO.Folder.Create(result);
            return result;
        }
    }
}