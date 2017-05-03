using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.lib.Excel
{
    [Test_IgnoreCoverage(enTestIgnore.ClassIsNodeLink)]
    public sealed class Excel_
    {
        #region About
        /// <summary>
        /// Gets the About library methods.
        /// </summary>
        public Excel_About About
        {
            get { return _About ?? (_About = new Excel_About()); }
        }
        private Excel_About _About;
        #endregion

        #region Adress
        /// <summary>
        /// Gets the Adress library methods.
        /// </summary>
        public Excel_Adress Adress
        {
            get { return _Adress ?? (_Adress = new Excel_Adress()); }
        }
        private Excel_Adress _Adress;
        #endregion

        #region Csv
        /// <summary>
        /// Gets the Csv library methods.
        /// </summary>
        public Excel_Csv Csv
        {
            get { return _Csv ?? (_Csv = new Excel_Csv()); }
        }
        private Excel_Csv _Csv;
        #endregion

        #region Data
        /// <summary>
        /// Gets the Data library methods.
        /// </summary>
        public Excel_Data Data
        {
            get { return _Data ?? (_Data = new Excel_Data()); }
        }
        private Excel_Data _Data;
        #endregion

        #region Macro
        /// <summary>
        /// Gets the Macro library methods.
        /// </summary>
        public Excel_Macro Macro
        {
            get { return _Macro ?? (_Macro = new Excel_Macro()); }
        }
        private Excel_Macro _Macro;
        #endregion

        #region IO_Read
        /// <summary>
        /// Gets the RW library methods.
        /// </summary>
        public Excel_IO_Read IO_Read
        {
            get { return _RW ?? (_RW = new Excel_IO_Read()); }
        }
        private Excel_IO_Read _RW;
        #endregion

        #region WorkSheet
        /// <summary>
        /// Gets the WorkSheet library methods.
        /// </summary>
        public Excel_WorkSheet WorkSheet
        {
            get { return _WorkSheet ?? (_WorkSheet = new Excel_WorkSheet()); }
        }
        private Excel_WorkSheet _WorkSheet;
        #endregion
    }
}
