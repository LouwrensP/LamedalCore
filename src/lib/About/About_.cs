using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LamedalCore.lib.About
{
    public sealed class About_
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        #region Console
        /// <summary>Shows a message abouts the Lamedal library.</summary>
        public void Console_About()
        {
            _lamed.lib.Console.IO.About_();
        }

        /// <summary>Shows a Hello World console message.</summary>
        public void HelloWorld()
        {
            _lamed.lib.Console.IO.About_HelloWorld_();
        }
        #endregion

        /// <summary>Return the Assembly of Lamedal library.</summary>
        /// <returns></returns>
        public Assembly Assembly()
        {
            return typeof(LamedalCore_).GetTypeInfo().Assembly;
        }



        /// <summary>Return the machine name.</summary>
        /// <returns></returns>
        public string MachineName()
        {
            return Environment.MachineName;
        }

        /// <summary>Return the stack trace.</summary>
        /// <returns></returns>
        public string StackTrace()
        {
            return Environment.StackTrace;
        }

        /// <summary>Return the processor count.</summary>
        /// <returns></returns>
        public int ProcessorCount()
        {
            return Environment.ProcessorCount;
        }

        /// <summary>Return the tick count.</summary>
        /// <returns></returns>
        public int TickCount()
        {
            return Environment.TickCount;
        }
    }
}
