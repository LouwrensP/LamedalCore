using System;
using LamedalCore.zz;

namespace LamedalCore.lib.Console1
{
    public sealed class Console_
    {

        #region IO
        /// <summary>
        /// Gets the IO library methods.
        /// </summary>
        public Console_IO IO
        {
            get { return _IO ?? (_IO = new Console_IO()); }
        }
        private Console_IO _IO;
        #endregion

    }
}
