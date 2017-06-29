using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zPublicClass.Test
{
    /// <summary>
    /// Public class used for test configurations
    /// </summary>
    [Test_IgnoreCoverage(enCode_TestIgnore.CodeIsUsedForTesting)]
    public sealed class pcTest_ConfigData
    {
        public string Folder_TestCase_About = "Please specify the folder where the test cases are located. Use '/' to separate folders. Path should end with '/'";
        public string Folder_TestCase = "c:/projects/lamedalcore/tests/TestData/";
        public string Test_Drive = "C:/";
    }
}