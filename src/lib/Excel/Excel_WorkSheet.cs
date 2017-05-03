using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.ExcelData;
using LamedalExcel;
using LamedalExcel.Cells;
using LamedalExcel.enums;
using LamedalCore.zz;

namespace LamedalCore.lib.Excel
{
    public sealed class Excel_WorkSheet
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>Set the Cell value for the worksheet.</summary>
        /// <param name="excelData">The excel data.</param>
        /// <param name="cellName">The cell name</param>
        /// <returns>Cell</returns>
        public Cell WorkSheet_Cell(pcExcelData_ excelData, string cellName)
        {
            Worksheet sheet = Worksheet_FromExcelData(excelData);
            Cell result = sheet.Cells[cellName];
            return result;
        }

        /// <summary>Set the Cell value for the worksheet.</summary>
        /// <param name="excelData">The excel data.</param>
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
        /// <returns></returns>
        public Cell WorkSheet_CellSet(pcExcelData_ excelData, string cellName, object value, bool? bold = null, bool? underline = null, 
            bool? italic = null, int? fontSize = null, string webLink = null, Color? textColor = null, int? columnWidth = null, 
            string fontName = null, enExcel_CellBorder? border = null)
        {
            Cell result = WorkSheet_Cell(excelData, cellName);
            result.Value = value;
            if (bold != null) result.Bold = (bool)bold;
            if (underline != null) result.Underline = (bool)underline;
            if (italic != null) result.Italic = (bool)italic;
            if (fontSize != null) result.FontSize = (int)fontSize;
            if (webLink != null) result.Hyperlink = webLink;
            if (textColor != null) result.TextColor = (Color)textColor;
            if (fontName != null) result.FontName = fontName;
            if (columnWidth != null) WorkSheet_ColumnWidth(excelData, cellName, (int)columnWidth);
            //if (border.HasValue)
            if (border!=null)
            {
                int borderValue = (int)border.Value;
                result.Border = (enCellBorder)borderValue;
            }

            return result;
        }

        /// <summary>Set the Cell value for the worksheet.</summary>
        /// <param name="excelData">The excel data.</param>
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
        /// <returns></returns>
        public Cell WorkSheet_CellSet(pcExcelData_ excelData, int col, int row, object value, bool? bold = null, bool? underline = null, 
            bool? italic = null, int? fontSize = null, string webLink = null, Color? textColor = null, int? columnWidth = null, 
            string fontName = null, enExcel_CellBorder? border = null)
        {
            string cellRef = _lamed.lib.Excel.Adress.CellAddress(col, row);
            return WorkSheet_CellSet(excelData, cellRef, value, bold,underline,italic,fontSize,webLink,textColor,columnWidth,fontName, border);
        }

        /// <summary>Set the column width of the sheet.</summary>
        /// <param name="excelData">The excel data.</param>
        /// <param name="colNo">The col no.</param>
        /// <param name="colWidth">Width of the col.</param>
        public void WorkSheet_ColumnWidth(pcExcelData_ excelData, int colNo, double colWidth)
        {
            var colName = _lamed.lib.Excel.Adress.ColName_FromColNumber(colNo);
            WorkSheet_ColumnWidth(excelData, colName, colWidth);
        }

        /// <summary>Set the column width of the sheet.</summary>
        /// <param name="excelData">The excel data.</param>
        /// <param name="colName">Name of the col.</param>
        /// <param name="colWidth">Width of the col.</param>
        public void WorkSheet_ColumnWidth(pcExcelData_ excelData, string colName, double colWidth)
        {
            var sheet = Worksheet_FromExcelData(excelData);
            var colNo = _lamed.lib.Excel.Adress.ColName_2Int(colName);
            sheet.ColumnWidths[colNo - 1] = colWidth;
        }

        /// <summary>Creates a new Worksheet.</summary>
        /// <param name="data">The data.</param>
        /// <param name="workbook">The workbook.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="orientation">The orientation.</param>
        internal void WorkSheet_New(pcExcelData_ data, Workbook workbook, string sheetName, enExcel_Orientation orientation = enExcel_Orientation.Portrait)
        {
            var sheet = new Worksheet(sheetName);
            workbook.Add(sheet);

            sheet.PageSetup.Orientation = (enOrientation)orientation;
            sheet.PageSetup.PrintRepeatRows = 2;
            sheet.PageSetup.PrintRepeatColumns = 2;
            data._sheet = sheet;
        }

        /// <summary>Creates a new Worksheet.</summary>
        /// <param name="data">The data.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="workbookAuthor">The workbook author.</param>
        /// <param name="workbookTitle">The workbook title.</param>
        /// <param name="orientation">The orientation.</param>
        public void WorkSheet_New(pcExcelData_ data, string sheetName, string workbookAuthor = "", string workbookTitle = "", enExcel_Orientation orientation = enExcel_Orientation.Portrait)
        {
            var workbook = Workbook_New(workbookAuthor, workbookTitle);
            WorkSheet_New(data, workbook, sheetName, orientation);
        }

        /// <summary>Creates a new Workbook.</summary>
        /// <param name="author">The author.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        internal Workbook Workbook_New(string author = "", string title = "")
        {
            var workbook = new Workbook();
            workbook.Title = title;
            workbook.Author = author;
            return workbook;
        }

        /// <summary>
        /// Return the Worksheet for the excel data
        /// </summary>
        /// <param name="excelData"></param>
        /// <returns></returns>
        private Worksheet Worksheet_FromExcelData(pcExcelData_ excelData)
        {
            var sheet = excelData.Worksheet;
            if (sheet == null) "Error! There is no worksheet in excelData.".zException_Show();  // Unit test needed for this
            return sheet;
        }

        /// <summary>Saves the Workbook.</summary>
        /// <param name="excelData">The excel data.</param>
        /// <param name="fileName">Name of the file.</param>
        public void Workbook_Save(pcExcelData_ excelData, string fileName)
        {
            var sheet = Worksheet_FromExcelData(excelData);
            sheet.Workbook.Save(fileName, CompressionLevel.Balanced);
        }

        /// <summary>Close the Workbook.</summary>
        /// <param name="excelData">The excel data.</param>
        public void Workbook_Close(pcExcelData_ excelData)
        {
            excelData._sheet = null;
        }
    }
}
