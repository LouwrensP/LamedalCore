using System;
using System.Collections.Generic;
using System.Drawing;
using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;
using LamedalCoreRemoved.Excel;
using LamedalExcel;

namespace LamedalCoreRemoved.ExcelData
{
    /// <summary>Public class to access excel data files</summary>
    public sealed class pcExcelData_
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        private readonly Excel_ _excel = LamedalCore_.Instance.lib.Excel;
        internal Worksheet _sheet = null;

        private readonly List<List<string>> _rows = new List<List<string>>();

        /// <summary>
        /// Save the Worksheet 
        /// </summary>
        /// <returns></returns>
        internal Worksheet Worksheet
        {
            get { return _sheet; }
        }

        /// <summary>Gets the cells.</summary>
        public List<List<string>> Rows
        {
            get { return _rows; }
        }

        public List<List<string>> Columns
        {
            get { return Columns_Get(); }
        }

        /// <summary>Return the Columns.</summary>
        /// <returns></returns>
        private List<List<string>> Columns_Get()
        {
            var cols = new List<List<string>>();
            var colMax = 1;
            var index = 0;
            while (index < colMax)
            {
                var col = new List<string>();
                foreach (List<string> row in _rows)
                {
                    if (index < row.Count)
                        col.Add(row[index]);
                    else col.Add("");
                    if (index == 0 && row.Count > colMax) colMax = row.Count; // Get the max col count.
                }
                cols.Add(col);
                index++;
            }
            return cols;
        }

        /// <summary>Gets the col count.</summary>
        public int Col_Count
        {
            get { return _rows.Count == 0 ? 0 : _rows[0].Count; }
        }

        /// <summary>Gets the row count.</summary>
        public int Row_Count
        {
            get { return _rows.Count; }
        }

        /// <summary>Return the specific row</summary>
        /// <param name="rowNo">The row no.</param>
        /// <returns></returns>
        public string[] Row(int rowNo)
        {
            if (rowNo <= 0) new ArgumentException("RowNo must be greater than 1", nameof(rowNo));
            if (rowNo > Row_Count) new ArgumentException($"RowNo must be smaller than {Row_Count}", nameof(rowNo));

            var row = _rows[rowNo - 1];
            return row.ToArray();
        }

        /// <summary>Gets the cell value</summary>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        public string Value_Get(int col, int row)
        {
            return _lamed.lib.Excel.Data.Value_Get(this, col, row);
        }

        /// <summary>Gets the cell value</summary>
        /// <returns></returns>
        public string Value_Get(string cellName)
        {
            return _lamed.lib.Excel.Data.Value_Get(this, cellName);
        }

        [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
        public void Macro_Compile()
        {
            string errorMsg;
            _excel.Macro.Compile(this, out errorMsg);
        }

        /// <summary>Executeutablecutes the tdata macro.</summary>
        /// <param name="dataSource">The data source</param>
        [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
        public void Macro_Execute(pcExcelData_ dataSource)
        {
            _excel.Macro.Execute_Data(dataSource, this);
        }

        /// <summary>Sets the value of a cell</summary>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        /// <param name="value">The value.</param>
        [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
        public void Value_Set(int col, int row, string value)
        {
            _lamed.lib.Excel.Data.Value_Set(this, col, row, value);
        }

        /// <summary>Sets the value of a cell</summary>
        /// <param name="cellRef">The cell reference.</param>
        /// <param name="value">The value.</param>
        public void Value_Set(string cellRef = "A1", string value = "")
        {
            _lamed.lib.Excel.Data.Value_Set(this, cellRef, value);
        }

        /// <summary>Load the CSV file.</summary>
        /// <param name="csvFilename">The CSV filename.</param>
        [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
        public void csvLoadFromFile(string csvFilename)
        {
            // Read the CSV file and populate the data structure
            string[] lines = _lamed.lib.IO.RW.File_Read2StrArray(csvFilename);
            csvLoadFromLines(lines);
        }

        /// <summary>Loads the from csv lines.</summary>
        /// <param name="lines">The lines.</param>
        public void csvLoadFromLines(params string[] lines)
        {
            _lamed.lib.Excel.Csv.DataRows_FromCsvLines(Rows, lines);
        }


        /// <summary>Saves the file to CSV</summary>
        /// <param name="csvFilename">The CSV filename.</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        public void csvSave2File(string csvFilename, bool overwrite = false)
        {
            _lamed.lib.Excel.Csv.DataRows_2csvFile(csvFilename, Rows, overwrite);
        }

        /// <summary>Normalizes the rows to all have equal values.</summary>
        public pcExcelData_ Normalize()
        {
            _lamed.lib.Excel.Data.Normalize(this.Rows);
            return this;
        }

        /// <summary>Finds the specified value in the sheet.</summary>
        /// <param name="findValue">The find value.</param>
        /// <param name="compare">The compare formula to use.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <returns></returns>
        [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
        public List<string> Find(string findValue = "|->", enExcel_Compare compare = enExcel_Compare.Contains,
            enExcel_FindReturnValue returnType = enExcel_FindReturnValue.CellValue)
        {
            return _lamed.lib.Excel.Adress.Find(this, findValue, compare, returnType);
        }

        /// <summary>Finds the first occurance.</summary>
        /// <param name="result">The result.</param>
        /// <param name="findValue">The find value.</param>
        /// <param name="compare">The compare.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <returns></returns>
        public bool Find_First(out string result, string findValue = "|->",
            enExcel_Compare compare = enExcel_Compare.Contains,
            enExcel_FindReturnValue returnType = enExcel_FindReturnValue.CellValue)
        {
            return _lamed.lib.Excel.Adress.Find_First(this, out result, findValue, compare, returnType);
        }

        /// <summary>Creates a new Worksheet.</summary>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="orientation">The orientation.</param>
        /// <param name="workbookAuthor">The workbook author.</param>
        /// <param name="workbookTitle">The workbook title.</param>
        public void WorkSheet_New(string sheetName, enExcel_Orientation orientation = enExcel_Orientation.Portrait, string workbookAuthor = "", string workbookTitle = "")
        {
            _lamed.lib.Excel.WorkSheet.WorkSheet_New(this, sheetName, workbookAuthor, workbookTitle, orientation);
        }

        /// <summary>Set the column width of the sheet.</summary>
        /// <param name="colNo">The col no.</param>
        /// <param name="colWidth">Width of the col.</param>
        public void WorkSheet_ColumnWidth(int colNo, double colWidth)
        {
            _lamed.lib.Excel.WorkSheet.WorkSheet_ColumnWidth(this, colNo, colWidth);
        }

        /// <summary>Set the column width of the sheet.</summary>
        /// <param name="colName">Name of the col.</param>
        /// <param name="colWidth">Width of the col.</param>
        [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
        public void WorkSheet_ColumnWidth(string colName, double colWidth)
        {
            _lamed.lib.Excel.WorkSheet.WorkSheet_ColumnWidth(this, colName, colWidth);
        }

        /// <summary>Set the Cell value for the worksheet.</summary>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        /// <param name="value">The value.</param>
        /// <param name="bold">The bold.</param>
        /// <param name="underline">The underline.</param>
        /// <param name="italic">The italic.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="webLink">The web link.</param>
        /// <param name="textColor">Color of the text.</param>
        /// <param name="columnWidth">Width of the column.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <param name="border">The border.</param>
        public void WorkSheet_CellSet(int col, int row, object value, bool? bold = null,
            bool? underline = null, bool? italic = null, int? fontSize = null, string webLink = null,
            Color? textColor = null, int? columnWidth = null, string fontName = null, enExcel_CellBorder? border = null)
        {
            var address = _lamed.lib.Excel.Adress.CellAddress(col, row);
            WorkSheet_CellSet(address, value, bold, underline, italic, fontSize, webLink, textColor, columnWidth, fontName, border);
        }

        /// <summary>Set the Cell value for the worksheet.</summary>
        /// <param name="cellName">Name of the cell.</param>
        /// <param name="value">The value.</param>
        /// <param name="bold">The bold.</param>
        /// <param name="underline">The underline.</param>
        /// <param name="italic">The italic.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="webLink">The web link.</param>
        /// <param name="textColor">Color of the text.</param>
        /// <param name="columnWidth">Width of the column.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <param name="border">The border.</param>
        public void WorkSheet_CellSet(string cellName, object value, bool? bold = null,
            bool? underline = null, bool? italic = null, int? fontSize = null, string webLink = null,
            Color? textColor = null, int? columnWidth = null, string fontName = null, enExcel_CellBorder? border = null)
        {
            Value_Set(cellName, value.zObject().AsStr());  // Save the value in the data
            _lamed.lib.Excel.WorkSheet.WorkSheet_CellSet(this, cellName, value, bold, underline, italic, fontSize,
                webLink, textColor, columnWidth, fontName, border);
        }

        /// <summary>Save the workbook</summary>
        /// <param name="fileName">Name of the file.</param>
        public void Workbook_Save(string fileName)
        {
            // Sync the worksheet
            var rowNo = 1;   
            foreach (List<string> row in Rows)
            {
                var colNo = 1;
                foreach (string value in row)
                {
                    _lamed.lib.Excel.WorkSheet.WorkSheet_CellSet(this, colNo, rowNo, value);
                    colNo++;
                }
                rowNo++;
            }

            if (fileName != "") _lamed.lib.Excel.WorkSheet.Workbook_Save(this, fileName);
        }

        /// <summary>Close the Workbook. If a filename is given saves the workbook before the close</summary>
        /// <param name="fileName">Name of the file.</param>
        public void Workbook_Close(string fileName = "")
        {
            Workbook_Save(fileName);
            _lamed.lib.Excel.WorkSheet.Workbook_Close(this);
        }
    }
}
