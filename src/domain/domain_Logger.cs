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

        /// <summary>Simple logger. Logs the specified message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="logType">Type of the log.</param>
        /// <param name="lineNumber">The line number.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="filepath">The filepath.</param>
        public string LogMessage(Exception ex, enCode_LogType logType = enCode_LogType.Info,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null,
            [CallerFilePath] string filepath = "")
        {
            return LogMessage(ex.Message, ex, logType, lineNumber, caller, filepath);
        }

        /// <summary>Simple logger. Logs the specified message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="logType">Type of the log.</param>
        /// <param name="lineNumber">The line number.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="filepath">The filepath.</param>
        public string LogMessage(string message, Exception ex = null, enCode_LogType logType = enCode_LogType.Info,
                    [CallerLineNumber] int lineNumber = 0,
                    [CallerMemberName] string caller = null,
                    [CallerFilePath] string filepath = "")
        {
            string timeStr;
            var logfile = _lamed.lib.IO.File.Filename_Logging(out timeStr);
            var stack = "";
            string source = "";
            if (ex != null)
            {
                // There was an exception, lets log more information
                source = "".NL() +  $"  // Method:'{caller}()' at line {lineNumber} in file: '{filepath}'".NL();
                logType = enCode_LogType.Error;
                var line = "--------------------------------------------------".NL();
                var exceptions = InnerExceptions(ex).Select(x => x.Message).ToList().zTo_Str("".NL(), prefixStr: " <Error>: ");
                stack = line+ exceptions.NL() + line + ex.ToString().NL() + line;
            }

            var msg = $"[{timeStr}] #{logType}# " + message + source + stack;
            _lamed.lib.IO.RW.File_Append(logfile, msg, _logger);
            return logfile;
        }
        private object _logger = new Object();

        /// <summary>Shows the Exception message</summary>
        /// <param name="ex">The exception</param>
        /// <param name="errMsg">The error msg setting. Default value = "".</param>
        /// <param name="action">The exception action setting. Default value = ExceptionAction.ThrowError.</param>
        [DebuggerStepThrough]
        public virtual void Show(Exception ex, string errMsg = "", enCode_ExceptionAction action = enCode_ExceptionAction.reThrowError)
        {
            //_system.lib.Tools.Form_Remove_TopMost();

            errMsg = (errMsg == "") ? "" : "".NL() + errMsg.NL(2);   // The first 2 new lines help with a new rethrow error message in unit tests. 
            errMsg += ex.Message.NL(2);
            //errMsg += Method_Stacktrace_AsStr();  // Get the stacktrace
            ex.Data["UserMessage"] += errMsg;

            switch (action)
            {
                case enCode_ExceptionAction.ThrowError: throw ex;
                case enCode_ExceptionAction.reThrowError: throw New(errMsg, ex);
                default: throw new Exception($"Argument '{nameof(action)}' error.");
            }
        }

        /// <summary>Show Exception Message.</summary>
        /// <param name="errMsg">The error MSG.</param>
        /// <param name="action">The action.</param>
        /// <param name="innerException">The inner exception.</param>
        [DebuggerStepThrough]
        public void Show(string errMsg, enCode_ExceptionAction action = enCode_ExceptionAction.ThrowError, Exception innerException = null)
        {
            Exception ex = New(errMsg, innerException);
            Show(ex, "", action);
        }

        /// <summary>Creates new exception.</summary>
        /// <param name="errMsg">The error MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <returns></returns>
        public Exception New(string errMsg, Exception innerException = null)
        {
            if (innerException == null) return new InvalidOperationException(errMsg);

            return new InvalidOperationException(errMsg, innerException);
        }

    }
}
