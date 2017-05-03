using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.ExcelData;
using LamedalCore.zz;

namespace LamedalCore.lib.Excel
{
    public sealed class Excel_IO_Read
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library


        /// <summary>Reads the excel file using Open XML SDK.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sheetName"></param>
        public pcExcelData_ ExcelFile_LoadAsExcelData(string fileName, string sheetName = "")
        {
            if (fileName == "") throw new ArgumentException("Error! filename must be assigned!", fileName);
            if (_lamed.lib.IO.File.Exists(fileName) == false) throw new ArgumentException($"Error! File '{fileName}' does not exist.");

            var result = new pcExcelData_();
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (var spreadsheetDocument = SpreadsheetDocument.Open(fileStream, true))
                {
                    //sharedStringTable = null;
                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;

                    IEnumerable<SharedStringTablePart> sharedStringTableParts = workbookPart.GetPartsOfType<SharedStringTablePart>();
                    SharedStringTablePart sharedStringTablePart;
                    if (sharedStringTableParts.Count() > 0)
                        sharedStringTablePart = sharedStringTableParts.First();
                    else sharedStringTablePart = spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();
                    SharedStringTable sharedStringTable = sharedStringTablePart.SharedStringTable;

                    //WorksheetPart worksheetPart = workbookPart.WorksheetParts.Last();
                    WorksheetPart worksheetPart = WorksheetPart_FromName(workbookPart, sheetName);
                    Worksheet worksheet = worksheetPart.Worksheet;

                    IEnumerable<Row> rows = Rows(worksheet);
                    Debug.WriteLine("Row count = {0}".zFormat(Row_Count(worksheet)));
                    //Cells(worksheet);
                    //Debug.WriteLine("Cell count = {0}".zFormat(cells.LongCount()));
                    //Debug.WriteLine("Col count = {0}".zFormat(cells.LongCount() / rows.LongCount()));

                    #region One way: go through each cell in the sheet
                    //foreach (Cell cell in cells)
                    //{
                    //    var ref1 = cell.CellReference;
                    //    if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                    //    {

                    //        int ssid = int.Parse(cell.CellValue.Text);
                    //        string str = sharedStringTable.ChildElements[ssid].InnerText;
                    //        Debug.WriteLine("Shared string {0}: {1}", ssid, str);
                    //    }
                    //    else if (cell.CellValue != null)
                    //    {
                    //        Debug.WriteLine("Cell contents: {0}", cell.CellValue.Text);
                    //    }
                    //}

                    #endregion

                    // Extract data rows
                    result.Rows.Clear();
                    #region foreach (Row row in rows)
                    foreach (Row row in rows)
                    {
                        //var rowList = new List<string>();
                        foreach (Cell cell in row.Elements<Cell>())
                        {
                            string value = CellValue_AsStr(cell, sharedStringTable);
                            StringValue ref1 = cell.CellReference;
                            result.Value_Set(ref1, value);

                            // Test writing =========================
                            //ConstructCellValue(cell, ref1);

                            Debug.WriteLine($"Cell ref '{ref1}': {value}");
                            //rowList.Add(value);
                        }
                        //result.Rows.Add(rowList);
                    }
                    #endregion

                    // Test writing
                    worksheet.WorksheetPart.Worksheet.Save();
                    spreadsheetDocument.Close();
                }
            }
            // Normalise the result
            return result;
        }

        /// <summary>Compares two data sheets and return the differences.</summary>
        /// <param name="inputFile">The file input.</param>
        /// <param name="inputSheet">The input sheet.</param>
        /// <param name="resultFile">The result file.</param>
        /// <param name="resultSheet">The result sheet.</param>
        /// <param name="returnValue">The return value.</param>
        /// <returns></returns>
        public List<string> CompareDataSheet(string inputFile, string inputSheet, string resultFile, string resultSheet, enExcel_FindReturnValue returnValue = enExcel_FindReturnValue.CellAddress)
        {
            pcExcelData_ input1 = ExcelFile_LoadAsExcelData(inputFile, inputSheet);
            pcExcelData_ result1 = ExcelFile_LoadAsExcelData(resultFile, resultSheet);

            return _lamed.lib.Excel.Data.CompareDataSheet(input1, result1);
        }

        /// <summary>Load the CSV file.</summary>
        /// <param name="csvFilename">The CSV filename.</param>
        /// <returns></returns>
        public pcExcelData_ csvLoadFromFile(string csvFilename)
        {
            // Read the CSV file and populate the data structure
            var result = new pcExcelData_();
            string[] lines = _lamed.lib.IO.RW.File_Read2StrArray(csvFilename);
            _lamed.lib.Excel.Csv.DataRows_FromCsvLines(result.Rows, lines);
            return result;
        }

        #region private

        internal int Row_Count(Worksheet worksheet)
        {
            IEnumerable<Row> rows = Rows(worksheet);
            long result = rows.LongCount();
            return (int)result;
        }

        internal IEnumerable<Row> Rows(Worksheet worksheet)
        {
            IEnumerable<Row> rows = worksheet.Descendants<Row>();
            return rows;
        }

        //private IEnumerable<Cell> Cells(Worksheet worksheet)
        //{
        //    IEnumerable<Cell> cells = worksheet.Descendants<Cell>();
        //    return cells;
        //}

        /// <summary>Constructs the cell value.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        internal void ConstructCellValue(Cell cell, string value)
        {
            if (_lamed.Types.Test.IsNumeric(value))
            {
                ConstructCellValue(cell, value, CellValues.Number);
                //CellValue v = new CellValue();
                //v.Text = value;
                //cell.AppendChild(v);
            }
            else ConstructCellValue(cell, value, CellValues.String);
        }

        ///// <summary>Constructs the cell value.</summary>
        ///// <param name="value">The value.</param>
        ///// <returns></returns>
        //private void ConstructCellValue(Cell cell, string value, SharedStringTablePart shareStringPart)
        //{
        //    if (_lamed.Types.String.IsNumeric(value)) ConstructCellValue(cell, value, CellValues.Number);
        //    else
        //    {
        //        int index = InsertSharedStringItem(value, shareStringPart);
        //        ConstructCellValue(cell, value, CellValues.String);
        //    }
        //}

        /// <summary>Constructs the cell value.</summary>
        /// <param name="cell">The cell.</param>
        /// <param name="value">The value.</param>
        /// <param name="dataType">Type of the data.</param>
        private void ConstructCellValue(Cell cell, string value, CellValues dataType)
        {
            cell.CellValue = new CellValue(value);
            cell.DataType = new EnumValue<CellValues>(dataType);
        }

        internal WorksheetPart WorksheetPart_FromName(WorkbookPart workbookPart, string sheetName = "")
        {
            //if (sheetName == "") return workbookPart.WorksheetParts.Last();

            Sheets sheets = workbookPart.Workbook.GetFirstChild<Sheets>();
            var total = sheets.Count();
            if (total == 0) return null; // The specified worksheet does not exist.

            IEnumerable<Sheet> sheetsName = sheets.Elements<Sheet>().Where(s => s.Name == sheetName);
            var sheet1 = sheetsName.FirstOrDefault();
            if (sheet1 == null)
            {
                if (sheetName != "")
                {
                    ($"Error! Worksheet with name '{sheetName}' was not found!").zException_Show();
                }

                // The Sheet name was not found; return the first visible sheet
                foreach (Sheet sheet in sheets.Elements<Sheet>())
                {
                    if (sheet.State == null || (sheet.State != null && sheet.State.HasValue && sheet.State.Value == SheetStateValues.Visible))
                    {
                        sheet1 = sheet;
                        break;
                    }
                }
            }

            // if (sheet1 == null) return null; // <==================[  Unit test required for this condition

            string relationshipId = sheet1.Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(relationshipId);
            return worksheetPart;
        }

        /// <summary>Return the value of the Cell.</summary>
        /// <param name="cell">The cell.</param>
        /// <param name="sharedStringTable">The shared string table.</param>
        /// <returns></returns>
        internal string CellValue_AsStr(Cell cell, SharedStringTable sharedStringTable)
        {
            if (cell.CellValue == null) return "";
            string result = cell.CellValue.Text;
            if (_lamed.Types.Test.IsNumeric(result) == false) return result;  // This is text

            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                int ssid = Int32.Parse(result);
                result = sharedStringTable.ChildElements[ssid].InnerText;
                //Debug.WriteLine("Shared string {0}: {1}".zFormat(ssid, result));
            }

            return result;
        }
        #endregion

    }
}
