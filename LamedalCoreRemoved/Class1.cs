using System;
using LamedalCoreRemoved.Excel;

namespace LamedalCoreRemoved
{
    public class Class1
    {
        #region Excel
        /// <summary>
        /// Gets the Excel library methods.
        /// </summary>
        public Excel_ Excel
        {
            get { return _Excel ?? (_Excel = new Excel_()); }
        }
        private Excel_ _Excel;
        #endregion

        #region Excel
        /// <summary>
        /// Gets the About library methods.
        /// </summary>
        public Excel_About ExcelAbout
        {
            get { return _Excel1 ?? (_Excel1 = new Excel_About()); }
        }
        private Excel_About _Excel1;
        #endregion
    }
}
