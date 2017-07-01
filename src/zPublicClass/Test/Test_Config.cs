using System;
using LamedalCore.zz;
using Xunit.Abstractions;

namespace LamedalCore.zPublicClass.Test
{
    /// <summary>
    /// Create simple test hookup class. This class is static for simplicity reasons. 
    /// </summary>
    public static class Test_Config
    {
        public static bool Test_ShowConfigFiles = false;  // if true, show config files
        public static string Test_Drive;  // The drive that the application is running on

        private static string _folderTestCases = "";
        private static string _folderApplication;
        private static pcTest_ConfigData _config;
        private static string _configFile;
        private static bool _FirstTime = true;  // Flag

        /// <summary>Make sure the tests data folders are configured correctly.</summary>
        /// <param name="debug">The debug.</param>
        /// <param name="add2Path">The add2 path.</param>
        /// <returns>The test folder where the test data is located</returns>
        public static string TestFolder(string add2Path = "")
        {
            if (_FirstTime == false) return _folderTestCases + add2Path;  // Ensure that this method is only run once
            var _lamed = LamedalCore_.Instance; // system library

            var success  = LamedalCore_.Instance.lib.Test.ConfigSettings(out _folderApplication, out _folderTestCases, out _config, out _configFile);
            if (success == false)
            {
                var msg = "Error! Unit test folder settings are incorrect.".NL() +
                    "  Please correct. (Opening the running folder and the 'Config.json' file.".NL()+
                    $"  + Test case folder: '{_folderTestCases}'".NL() +
                    $"  + Application Folder    : '{_folderApplication}'";
                var ex = new InvalidOperationException(msg);
                _lamed.Logger.LogLibraryMsg(ex);
                throw ex;
            }

            Test_Drive = _config.Test_Drive;

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
            _lamed.lib.IO.Folder.Create(result);
            return result;
        }

        /// <summary>Determines whether [is good folderOrFile format] [the specified folderOrFile].</summary>
        /// <param name="folderOrFile">The folderOrFile.</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <param name="testIfExist">if set to <c>true</c> [test if exist].</param>
        /// <returns></returns>
        public static bool IsGoodFolderOrFileFormat(string folderOrFile, out string errorMsg, bool testIfExist = true)
        {
            // Test for '\'
            errorMsg = "";
            if (folderOrFile.Contains(@"\"))
            {
                errorMsg = @"Error: Folder contains '\' characters. Folders should be of format '/'";
                return false;
            }

            // This is a file
            if (folderOrFile.Contains("."))
            {
                if (testIfExist && LamedalCore_.Instance.lib.IO.File.Exists(folderOrFile) == false)
                {
                    errorMsg = $"Error: '{folderOrFile}' does not exist!";
                    return false;
                }
                return true; // This is a file, no more tests required
            }

            // This is a folder
            if (folderOrFile.zSubStr_Right(1) != "/")
            {
                errorMsg = @"Error: Folder does not end with '/'";
                return false;
            }

            if (testIfExist && LamedalCore_.Instance.lib.IO.Folder.Exists(folderOrFile) == false)
            {
                errorMsg = $"Error: '{folderOrFile}' does not exist!";
                return false;
            }
            return true;
        }

        public static void Folder_Cleanup(string testFolder)
        {
            var lamed = LamedalCore_.Instance;
            if (lamed.lib.IO.Folder.Exists(testFolder)) lamed.lib.IO.Folder.Delete(testFolder, true);
        }

        public static void Folder_Create(string testFolder)
        {
            var lamed = LamedalCore_.Instance;
            if (lamed.lib.IO.Folder.Exists(testFolder)) lamed.lib.IO.Folder.Delete(testFolder, true);
            if (lamed.lib.IO.Folder.Exists(testFolder)) throw new InvalidOperationException($"Error! Unable to delete '{testFolder}'.");

            // Create folders ]-----------------------------------------------------------------------
            lamed.lib.IO.Folder.Create(testFolder + "test1/");
            lamed.lib.IO.Folder.Create(testFolder + "test1/"); // Redo step and no error is expected
            lamed.lib.IO.Folder.Create(testFolder + "test2/");
            lamed.lib.IO.Folder.Create(testFolder + "test3");
            lamed.lib.IO.Folder.Create(testFolder + "test4/");
            lamed.lib.IO.Folder.Create(testFolder + "test4/Sub1/Sub2/");
            lamed.lib.IO.Folder.Create(testFolder + "folder\\folder2");
        }
    }
}