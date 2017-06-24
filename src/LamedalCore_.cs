/******************************[Module Header]************************************\
* Project        :  LaMedalCore
* Created By     :  Perez Lamed van Niekerk
* Creation Date  :  30 July 2016
*
*
* Purpose ************************************************************************
* The Purpose of this library is to define the main starting point for the LaMedal
* open source core library.
*
* Usage **************************************************************************
 * private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library
 * 
 * 
* Copyright 2014-2016 Perez Lamed van Niekerk
* This source is subject to the following license terms.
* See http://www.apache.org/licenses/LICENSE-2.0.
* See https://sites.google.com/site/lamedalwiki/home
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib;
using LamedalCore.Types;
using LamedalCore.zz;
using DocumentFormat.OpenXml.Spreadsheet;

namespace LamedalCore
{
    /// <summary>
    /// Starting point for the LamedalCore_ library
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.CTIN, Ignore_Namespace1 = "Factory", Ignore_Namespace2 = "")]
    [Test_IgnoreCoverage(enCode_TestIgnore.ClassIsNodeLink)]
    public sealed class LamedalCore_
    {
        // private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library
        // Console.WriteLine(_lamed.About());

        #region Singleton of Access2System_
        private static readonly LamedalCore_ _LaMedalPort = new LamedalCore_();  // This is the only instance of this class
        private LamedalCore_()
        {
            // Private constructor prevents creation by external clients
        }

        /// <summary>
        /// Return Instance of Access2System_
        /// </summary>
        public static LamedalCore_ Instance
        {
            get { return _LaMedalPort; }
        }
        #endregion

        #region Exceptions
        /// <summary>
        /// Gets the Exceptions library methods. 
        /// </summary>
        public LamedalCore_Exceptions Exceptions
        {
            get { return _Exceptions ?? (_Exceptions = new LamedalCore_Exceptions()); }
        }
        private LamedalCore_Exceptions _Exceptions;
        #endregion

        #region lib
        /// <summary>
        /// Gets the lib2 library methods.
        /// </summary>
        public lib_ lib
        {
            get { return _lib ?? (_lib = new lib_()); }
        }
        private lib_ _lib;
        #endregion


        #region About messages
        /// <summary>Shows an about message of the LamedaL library.</summary>
        /// <returns></returns>
        public string About_()
        {
            return LamedalCore_.Instance.lib.Console.IO.About_();
        }

        /// <summary>Writes to the console an about message of the LamedaL library.</summary>
        public void About_WriteLine()
        {
            LamedalCore_.Instance.lib.Console.IO.About_WriteLine();
        }

        /// <summary>
        /// Writes a hello world message to the console
        /// </summary>
        /// <returns></returns>
        public string HelloWorld_()
        {
            return LamedalCore_.Instance.lib.Console.IO.About_HelloWorld_();
        }

        /// <summary>
        /// Writes a hello world message to the console
        /// </summary>
        /// <returns></returns>
        public void HelloWorld_WriteLine()
        {
            LamedalCore_.Instance.lib.Console.IO.About_HelloWorld_WriteLine();
        }

        /// <summary>
        /// Shows a error message. This is for testing purposes.
        /// </summary>
        [Test_IgnoreCoverage(enCode_TestIgnore.CodeIsUsedForTesting)]
        public void Error_Test()
        {
            throw new NotImplementedException("Hello. This is a test error message.");
        }

        /// <summary>Exits the application.</summary>
        /// <param name="exitCode">The exit code.</param>
        [Test_IgnoreCoverage(enCode_TestIgnore.CodeIsUsedForTesting)]
        public void Exit(int exitCode = 0)
        {
            Environment.Exit(exitCode);
        }

        /// <summary>Exits the application and write message on the event log.</summary>
        /// <param name="eventlogMsg">The eventlog MSG.</param>
        [Test_IgnoreCoverage(enCode_TestIgnore.CodeIsUsedForTesting)]
        public void Exit_Fast(string eventlogMsg = "")
        {
            Environment.FailFast(eventlogMsg);
        }

        #endregion

        #region Types
        /// <summary>
        /// Gets the Types library methods.
        /// </summary>
        public Types_ Types
        {
            get { return _Types ?? (_Types = new Types_()); }
        }
        private Types_ _Types;
        #endregion

    }
}
