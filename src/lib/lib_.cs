using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.About;
using LamedalCore.lib.Console1;
using LamedalCore.lib.Excel;
using LamedalCore.lib.IO;
using LamedalCore.lib.Words;
using LamedalCore.lib.XML;

namespace LamedalCore.lib
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Link)]
    [Test_IgnoreCoverage(enCode_TestIgnore.ClassIsNodeLink)]
    public sealed class lib_
    {
        #region About
        /// <summary>
        /// Gets the About library methods.
        /// </summary>
        public About_ About
        {
            get { return _About ?? (_About = new About_()); }
        }
        private About_ _About;
        #endregion

        #region Console
        /// <summary>
        /// Gets the Console library methods.
        /// </summary>
        public Console_ Console
        {
            get { return _Console ?? (_Console = new Console_()); }
        }
        private Console_ _Console;
        #endregion

        #region Command
        /// <summary>
        /// Gets the Command library methods.
        /// </summary>
        public lib_Command Command
        {
            get { return _Command ?? (_Command = new lib_Command()); }
        }
        private lib_Command _Command;
        #endregion

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

        #region IO
        /// <summary>
        /// Gets the IO library methods.
        /// </summary>
        public IO_ IO
        {
            get { return _IO ?? (_IO = new IO_()); }
        }
        private IO_ _IO;
        #endregion

        #region svg
        /// <summary>
        /// Gets the svg library methods.
        /// </summary>
        public lib_svg svg
        {
            get { return _svg ?? (_svg = new lib_svg()); }
        }
        private lib_svg _svg;
        #endregion

        #region Test
        /// <summary>
        /// Gets the Test library methods.
        /// </summary>
        public lib_Test Test
        {
            get { return _Test ?? (_Test = new lib_Test()); }
        }
        private lib_Test _Test;
        #endregion

        #region XML
        /// <summary>
        /// Gets the XML library methods.
        /// </summary>
        public XML_ XML
        {
            get { return _XML ?? (_XML = new XML_()); }
        }
        private XML_ _XML;
        #endregion

        #region Words
        /// <summary>
        /// Gets the Words library methods.
        /// </summary>
        public Words_ Words
        {
            get { return _Words ?? (_Words = new Words_()); }
        }
        private Words_ _Words;
        #endregion

    }
}
