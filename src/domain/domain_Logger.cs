using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.domain
{
    /// <summary>
    /// Error handeling methods class
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, DefaultType = typeof(Exception))]
    [Test_IgnoreCoverage(enCode_TestIgnore.ExceptionHandling)]
    public class domain_Logger
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        //  DO throw an InvalidOperationException if the object is in an inappropriate state.

        // DO throw ArgumentException or one of its subtypes if bad arguments are passed to a member. 
        // DO set the ParamName property when throwing one of the subclasses of ArgumentException

        // Logging can be done in a sentral exception class

        // Todo: [0.5d] (R&D) DebuggerStepThrough Attribute and apply on exception classes. Test it on type methods. Test InnerExceptions() method.

        /// <summary>
        /// Gets a sequence containing the <see cref="Exception"/> object
        /// and its complete chain of nested exceptions via 
        /// <see cref="Exception.InnerException"/>.
        /// </summary>
        /// <remarks>
        /// This method uses deferred and streaming execution semantics.
        /// </remarks>
        //[DebuggerStepThrough]
        public IEnumerable<Exception> InnerExceptions(Exception ex)
        {
            if (ex == null) throw new ArgumentNullException(nameof(ex));
            return InnerExceptions_Yield(ex);
        }

        private IEnumerable<Exception> InnerExceptions_Yield(Exception ex)
        {
            for (; ex != null; ex = ex.InnerException) yield return ex;
        }

        /// <summary>Return all the inner exceptions as string.</summary>
        /// <param name="ex">The ex.</param>
        /// <param name="prefixStr">The prefix string.</param>
        /// <returns></returns>
        public string InnerExceptions_AsStr(Exception ex, string prefixStr = " <Error>: ")
        {
            var result = InnerExceptions(ex).Select(x => x.Message).ToList().zTo_Str("".NL(), prefixStr: prefixStr);
            return result;
        }

        /// <summary>Simple logger. Logs the specified message.</summary>
        /// <param name="ex">The ex.</param>
        /// <param name="lineNumber">The line number.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        public string LogLibraryMsg(Exception ex,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null,
            [CallerFilePath] string filepath = "")
        {
            string logFile;
            return LogMessage(ex.Message, out logFile, ex, enLogger_MsgType.Error, enLogger_DetailLevel.ClassLibrary, lineNumber, caller, filepath);
        }

        /// <summary>Simple logger. Logs the specified message.</summary>
        /// <param name="ex">The ex.</param>
        /// <param name="logType">Type of the log.</param>
        /// <param name="detail">The detail.</param>
        /// <param name="lineNumber">The line number.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        public string LogMessage(Exception ex, enLogger_DetailLevel detail = enLogger_DetailLevel.Application,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null,
            [CallerFilePath] string filepath = "")
        {
            string logFile;
            return LogMessage(ex.Message, out logFile, ex, enLogger_MsgType.Error, detail, lineNumber, caller, filepath);
        }

        /// <summary>Simple logger. Logs the specified message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="logFile">The log file.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="logType">Type of the log.</param>
        /// <param name="detail">The detail.</param>
        /// <param name="lineNumber">The line number.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        public string LogMessage(string message, out string logFile, Exception ex = null, enLogger_MsgType logType = enLogger_MsgType.Info, enLogger_DetailLevel detail = enLogger_DetailLevel.Application,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null,
            [CallerFilePath] string filepath = "")
        {
            string timeStr;
            logFile = _lamed.lib.IO.File.Filename_Logging(out timeStr);
            var exceptionList = "";
            var stacktrace = "";
            string source = "";
            if (ex != null)
            {
                // There was an exception, lets log more information
                source = $"  // Method:'{caller}()' at line {lineNumber} in file: '{filepath}'".NL();
                logType = enLogger_MsgType.Error;
                var line = "--------------------------------------------------".NL();
                var exceptions = InnerExceptions_AsStr(ex);
                exceptionList = line+ exceptions.NL() + line + ex.ToString().NL() + line;
                stacktrace = ""+ex.StackTrace;
                if (stacktrace != "") stacktrace += "".NL();
            }

            var msg = $"[{timeStr}] #{logType}# " + message.NL() + source + exceptionList + stacktrace + "=========================================================".NL();
            _lamed.lib.IO.RW.File_Append(logFile, msg, _logger);
            return msg;
        }
        private object _logger = new Object();
    }
}
