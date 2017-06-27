using System;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;
using Xunit.Abstractions;

namespace LamedalCore.zPublicClass.Test
{
    /// <summary>
    /// Public class for testing purposes. This gives one point to extent Xunit debug.console messages.
    /// </summary>
    [Test_IgnoreCoverage(enCode_TestIgnore.CodeIsUsedForTesting)]
    public class pcTest
    {
        #region Debug Output

        /// <summary>
        /// Test debug method
        /// </summary>
        /// <param name="debug"></param>
        //public pcTest(ITestOutputHelper debug = null)
        public pcTest(ITestOutputHelper debug = null)
        {
            // public Class_Name(ITestOutputHelper debug = null) : base(debug) { } 
            if (debug == null) throw new ArgumentNullException(nameof(debug));  // On error copy above line to inherited class and change 'Class_Name' with the class name.
                                                                                // Child class need to call this class
            this._Debug = debug;
        }
        protected readonly ITestOutputHelper _Debug;

        /// <summary>Logs Debug messages. This allow for test methods to be called from GUI interface</summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="underline">if set to <c>true</c> [underline].</param>
        /// <param name="reset">if set to <c>true</c> [reset].</param>
        protected void DebugLog(string msg, bool underline = false, bool reset = false)
        {
            _Debug.WriteLine(msg);
            if (underline)
            {
                _Debug.WriteLine("-".zRepeat(msg.Length));
                _Debug.WriteLine("");
            }
            if (reset) Tests_ToString = "";
            Tests_ToString += msg.NL();
        }
        public string Tests_ToString = "";

        #endregion

    }
}
