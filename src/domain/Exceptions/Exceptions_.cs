using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.domain.Exceptions
{
    /// <summary>
    /// Error handeling methods class
    /// </summary>
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Action, DefaultType = typeof(Exception))]
    [Test_IgnoreCoverage(enTestIgnore.CodeIsUsedForTesting)]
    public class Exceptions_
    {
        // Todo: [0.5d] (R&D) DebuggerStepThrough Attribute and apply on exception classes. Test it on type methods. Test InnerExceptions() method.

        /// <summary>
        /// Gets a sequence containing the <see cref="Exception"/> object
        /// and its complete chain of nested exceptions via 
        /// <see cref="Exception.InnerException"/>.
        /// </summary>
        /// <remarks>
        /// This method uses deferred and streaming execution semantics.
        /// </remarks>
        [DebuggerStepThrough]
        public IEnumerable<Exception> InnerExceptions(Exception e)
        {
            if (e == null) throw new Exception_ArgumentIsNull("e");

            return InnerExceptions_Yield(e);
        }

        private IEnumerable<Exception> InnerExceptions_Yield(Exception e)
        {
            for (; e != null; e = e.InnerException) yield return e;
        }

        /// <summary>Shows the Exception message</summary>
        /// <param name="ex">The exception</param>
        /// <param name="errMsg">The error msg setting. Default value = "".</param>
        /// <param name="action">The exception action setting. Default value = ExceptionAction.ThrowError.</param>
        [DebuggerStepThrough]
        public virtual void Show(Exception ex, string errMsg = "", enExceptionAction action = enExceptionAction.reThrowError)
        {
            //_system.lib.Tools.Form_Remove_TopMost();

            errMsg = (errMsg == "") ? "" : "".NL() + errMsg.NL(2);   // The first 2 new lines help with a new rethrow error message in unit tests. 
            errMsg += ex.Message.NL(2);
            //errMsg += Method_Stacktrace_AsStr();  // Get the stacktrace
            ex.Data["UserMessage"] += errMsg;

            switch (action)
            {
                case enExceptionAction.ThrowError: throw ex;
                case enExceptionAction.reThrowError: throw New(errMsg, ex);
            }
        }

        /// <summary>Show Exception Message.</summary>
        /// <param name="errMsg">The error MSG.</param>
        /// <param name="action">The action.</param>
        /// <param name="innerException">The inner exception.</param>
        [DebuggerStepThrough]
        public void Show(string errMsg, enExceptionAction action = enExceptionAction.ThrowError, Exception innerException = null)
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
