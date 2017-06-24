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
        public void Exception_Show_Test()
        {
            Assert.Throws<InvalidOperationException>(() => Exception_Show1());
            Assert.Throws<InvalidOperationException>(() => Exception_Show2());
            Assert.Throws<InvalidOperationException>(() => Exception_Show3());
        }
        #region Exception_Show
        private void Exception_Show1()
        {
            "Error message".zException_Show();
        }

        private void Exception_Show2()
        {
            "Error message".zException_Show(enCode_ExceptionAction.reThrowError);
        }

        private void Exception_Show3()
        {
            var ex = "".zException_New();
            ex.zException_Show("new error");
        }
        #endregion

        [Fact]
        public void Exception_Arguments_Test()
        {
            Assert.Throws<ArgumentException>(() => ExceptionArguments());
            Assert.Throws<ArgumentNullException>(() => ExceptionArgumentsIsNull());
            Assert.Throws<ArgumentOutOfRangeException>(() => ExceptionArgumentsIsOutOfRange());
        }
        #region ExceptionArguments
        private void ExceptionArguments(string parmName = null)
        {
            throw new ArgumentException(nameof(parmName));
        }

        private void ExceptionArgumentsIsNull(string parmName = null)
        {
            throw new ArgumentNullException(nameof(parmName));
        }
        private void ExceptionArgumentsIsOutOfRange(string parmName = null)
        {
            throw new ArgumentNullException(nameof(parmName));
        }
        #endregion

        [Fact]
        [Test_Method("InnerExceptions()")]
        public void InnerExceptions_Test()
        {
            // Create exception
            var ex = new NotImplementedException("Error1: Not implemented.");
            var ex2 = new Exception("Error2", ex);
            var ex3 = new Exception("Error3", ex2);

            #region  Test the exception errors
            List<Exception> exList = _lamed.Exceptions.InnerExceptions(ex3).ToList();
            Assert.Equal("Error1: Not implemented.", exList[2].Message);
            Assert.Equal("Error2", exList[1].Message);
            Assert.Equal("Error3", exList[0].Message);
            var errStr = exList.Select(x => x.Message).ToList().zTo_Str("".NL(), prefixStr:" <Error>: ");

            var resultError =
                @" <Error>: Error3
 <Error>: Error2
 <Error>: Error1: Not implemented.";
            Assert.Equal(resultError, errStr);
            #endregion

            #region Test logging of the error
            var file1 = _lamed.Logger.LogMessage("New Error!");
            Assert.True(_lamed.lib.IO.File.Exists(file1));
            _lamed.lib.IO.File.Delete(file1);
            Assert.False(_lamed.lib.IO.File.Exists(file1));
            var file2 = _lamed.Logger.LogMessage("New Error!", ex3);
            Assert.Equal(file1, file2);
            var error2 = _lamed.lib.IO.RW.File_Read2Str(file1);

            _lamed.lib.IO.File.Delete(file1);
            Assert.False(_lamed.lib.IO.File.Exists(file1));
            var file3 = _lamed.Logger.LogMessage(ex3);  // Call overload -> logging message should be the same
            var error3 = _lamed.lib.IO.RW.File_Read2Str(file3);

            Assert.Equal(file1, file2);
            Assert.Equal(file1, file3);

            var error2Result =
                @"[2017-06-24 17:53:00.666] #Error# New Error!
  // Method:'InnerExceptions_Test()' at line 92 in file: 'D:\Dev\GitHub\LamedalCore\tests\Tests\domain\domain_Exceptions_Test.cs'
--------------------------------------------------
 <Error>: Error3
 <Error>: Error2
 <Error>: Error1: Not implemented.
--------------------------------------------------
System.Exception: Error3 ---> System.Exception: Error2 ---> System.NotImplementedException: Error1: Not implemented.
   --- End of inner exception stack trace ---
   --- End of inner exception stack trace ---
--------------------------------------------------";
            // error2Result = error2Result.Replace(@"D:\Dev\GitHub\", @"C:\");
            Assert.Equal(error2Result,error2);
            Assert.Equal(error2Result, error3);
            #endregion
        }

    }
}
