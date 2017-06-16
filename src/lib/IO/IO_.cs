using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.IO.IO_StateInfo;

namespace LamedalCore.lib.IO
{
    [Test_IgnoreCoverage(enCode_TestIgnore.ClassIsNodeLink)]
    public sealed class IO_
    {
        #region Folder
        /// <summary>
        /// Gets the Folder library methods.
        /// </summary>
        public IO_Folder Folder
        {
            get { return _Folder ?? (_Folder = new IO_Folder()); }
        }
        private IO_Folder _Folder;
        #endregion

        #region File
        /// <summary>
        /// Gets the File library methods.
        /// </summary>
        public IO_File File
        {
            get { return _File ?? (_File = new IO_File()); }
        }
        private IO_File _File;
        #endregion

        #region Json
        /// <summary>
        /// Gets the Json library methods.
        /// </summary>
        public IO_Json Json
        {
            get { return _Json ?? (_Json = new IO_Json()); }
        }
        private IO_Json _Json;
        #endregion

        #region Parts
        /// <summary>
        /// Gets the Parts library methods.
        /// </summary>
        public IO_Parts Parts
        {
            get { return _Parts ?? (_Parts = new IO_Parts()); }
        }
        private IO_Parts _Parts;
        #endregion

        #region RW
        /// <summary>
        /// Gets the RW library methods.
        /// </summary>
        public IO_RW RW
        {
            get { return _RW ?? (_RW = new IO_RW()); }
        }
        private IO_RW _RW;
        #endregion

        #region Search
        /// <summary>
        /// Gets the Search library methods.
        /// </summary>
        public IO_Search Search
        {
            get { return _Search ?? (_Search = new IO_Search()); }
        }
        private IO_Search _Search;
        #endregion

        #region StateInfo
        /// <summary>
        /// Gets the StateInfo library methods.
        /// </summary>
        public IO_StateInfo_ StateInfo
        {
            get { return _StateInfo ?? (_StateInfo = new IO_StateInfo_()); }
        }
        private IO_StateInfo_ _StateInfo;
        #endregion
    }
}
