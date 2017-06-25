using System;
using System.Collections.Generic;
using System.Linq;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;
using Xunit;


namespace LamedalCore.Test.Tests.domain
{
    public sealed class domain_Exceptions_Test
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        [Fact]
        [Test_Method("InnerExceptions()")]
        public void InnerExceptions_Test()
        {
            // Create exception
            var ex = new NotImplementedException("Error1: Not implemented.");
            var ex2 = new Exception("Error2", ex);
            var ex3 = new Exception("Error3", ex2);

            #region  Test the exception errors
            List<Exception> exList = _lamed.Logger.InnerExceptions(ex3).ToList();
            Assert.Equal("Error1: Not implemented.", exList[2].Message);
            Assert.Equal("Error2", exList[1].Message);
            Assert.Equal("Error3", exList[0].Message);
            var errStr = _lamed.Logger.InnerExceptions_AsStr(ex3, " <Error>: ");

            // Check inner exception messages
            var resultError =
                @" <Error>: Error3
 <Error>: Error2
 <Error>: Error1: Not implemented.";
            Assert.Equal(resultError, errStr);
            #endregion

            #region Prepare logging - Check that file exists and delete it.
            string file1; 
            _lamed.Logger.LogMessage("New Error!", out file1);
            Assert.True(_lamed.lib.IO.File.Exists(file1));
            _lamed.lib.IO.File.Delete(file1);
            Assert.False(_lamed.lib.IO.File.Exists(file1));
            #endregion

            #region Log error and check it
            string file2;
            var error2a = _lamed.Logger.LogMessage(ex3.Message, out file2, ex3);
            var error2b = _lamed.lib.IO.RW.File_Read2Str(file1);

            Assert.Equal(file1, file2);
            Assert.Equal(error2a, error2b);
            _lamed.lib.IO.File.Delete(file1);
            Assert.False(_lamed.lib.IO.File.Exists(file1));

            // Call overload -> logging message should be the same
            var error2c = _lamed.Logger.LogMessage(ex3);  
            var time = _lamed.Types.DateTime.To_Str(DateTime.UtcNow);
            var error3 = _lamed.lib.IO.RW.File_Read2Str(file1);

            Assert.Equal(error2c, error3);
            #endregion

            var error2Result =
                @"[time] #Error# Error3
  // Method:'InnerExceptions_Test()' at line 82 in file: 'D:\Dev\GitHub\LamedalCore\tests\Tests\domain\domain_Exceptions_Test.cs'
--------------------------------------------------
 <Error>: Error3
 <Error>: Error2
 <Error>: Error1: Not implemented.
--------------------------------------------------
System.Exception: Error3 ---> System.Exception: Error2 ---> System.NotImplementedException: Error1: Not implemented.
   --- End of inner exception stack trace ---
   --- End of inner exception stack trace ---
--------------------------------------------------".NL();

            error2Result = error2Result.Replace("[time]", $"[{time}]");
            // error2Result = error2Result.Replace(@"D:\Dev\GitHub\", @"C:\");
            Assert.Equal(error2Result,error2c);
            Assert.Equal(error2Result, error3);
        }
    }
}
