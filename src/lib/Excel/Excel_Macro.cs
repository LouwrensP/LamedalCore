using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.ExcelData;
using LamedalCore.zz;
//using Xunit;

namespace LamedalCore.lib.Excel
{
    public sealed class Excel_Macro
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        #region MacroItem
        /// <summary>
        /// Gets the MacroItem library methods.
        /// </summary>
        public Excel_MacroItem MacroItem
        {
            get { return _MacroItem ?? (_MacroItem = new Excel_MacroItem()); }
        }
        private Excel_MacroItem _MacroItem;
        #endregion

        /// <summary>Execute the macro in the exel file.</summary>
        /// <param name="fileData">The file data.</param>
        /// <param name="fileConfig">The file configuration.</param>
        /// <param name="fileOutput">The file output.</param>
        /// <param name="errorMsg">The error MSG.</param>
        public bool Execute_ExcelMacro(string fileData, string fileConfig, string fileOutput, out string errorMsg)
        {
            // Test if input files exists
            if (_lamed.lib.IO.File.Exists(ref fileData, ".xlsx") == false) $"Error! '{fileData}' does not exist.".zException_Show();
            if (_lamed.lib.IO.File.Exists(ref fileConfig, ".xlsx") == false) $"Error! '{fileConfig}' does not exist.".zException_Show();
            if (fileOutput.Contains(".xlsx") == false) fileOutput += ".xlsx";

            // Copy config file to _Compile
            var fileCompile = fileConfig.Replace(".xlsx", "_Compile.xlsx");
            _lamed.lib.IO.File.Copy(fileConfig, fileCompile, true);

            // Read the two excel files
            pcExcelData_ excelConfig = _lamed.lib.Excel.IO_Read.ExcelFile_LoadAsExcelData(fileCompile);
            pcExcelData_ excelData = _lamed.lib.Excel.IO_Read.ExcelFile_LoadAsExcelData(fileData);
            //excelData.csvSave2File(@"C:\test\07_RDI_BudgetAdjusted.csv");

            // Compile the refeneces
            _lamed.lib.Excel.Macro.Compile(excelConfig, out errorMsg); // Get the reference
            _lamed.lib.Excel.Macro.ExcelFile_Merge(fileCompile, excelConfig, enExcel_MergeType.ExecuteMacro);
            _lamed.lib.IO.File.Copy(fileCompile, fileOutput, true);
            if (errorMsg.Trim() != "") return false;  // <================================================[ Unit test required for this

            // Merge the final values
            _lamed.lib.Excel.Macro.Execute_Data(excelData, excelConfig); // Get the data of the references
            //excelData.csvSave2File(@"C:\test\Budget_Dashboard.csv");
            _lamed.lib.Excel.Macro.ExcelFile_Merge(fileOutput, excelData, enExcel_MergeType.InsertReferences);
            return true;
        }

        /// <summary>Reads the excel file using Open XML SDK.</summary>
        /// <param name="fileResult">Name of the file.</param>
        /// <param name="sourceData">The data.</param>
        /// <param name="mergeType">Type of the merge.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="startAddress">If specifed, use this as the start address line for merge operations.</param>
        public void ExcelFile_Merge(string fileResult, pcExcelData_ sourceData, enExcel_MergeType mergeType, string sheetName = "", string startAddress = "")
        {
            using (FileStream fileStream = new FileStream(fileResult, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (var spreadsheetDocument = SpreadsheetDocument.Open(fileStream, true))
                {
                    //sharedStringTable = null;
                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;

                    IEnumerable<SharedStringTablePart> sharedStringTableParts = workbookPart.GetPartsOfType<SharedStringTablePart>();
                    SharedStringTablePart sharedStringTablePart;
                    if (sharedStringTableParts.Count() > 0)
                        sharedStringTablePart = sharedStringTableParts.First();
                    else sharedStringTablePart = spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();  // Unit test needed for this line
                    SharedStringTable sharedStringTable = sharedStringTablePart.SharedStringTable;

                    //WorksheetPart worksheetPart = workbookPart.WorksheetParts.Last();
                    WorksheetPart worksheetPart = _lamed.lib.Excel.IO_Read.WorksheetPart_FromName(workbookPart, sheetName);
                    Worksheet worksheet = worksheetPart.Worksheet;

                    IEnumerable<Row> rows = _lamed.lib.Excel.IO_Read.Rows(worksheet);
                    Debug.WriteLine("Row count = {0}".zFormat(_lamed.lib.Excel.IO_Read.Row_Count(worksheet)));

                    // Extract data rows
                    #region foreach (Row row in rows)

                    int startRow = -1, col;
                    if (startAddress != "") _lamed.lib.Excel.Adress.ColRow_AsInt(out col, out startRow, startAddress);
                    foreach (Row row in rows)
                    {
                        foreach (Cell cell in row.Elements<Cell>())
                        {
                            string value = _lamed.lib.Excel.IO_Read.CellValue_AsStr(cell, sharedStringTable);
                            StringValue ref1 = cell.CellReference;
                            int rowNo;
                            _lamed.lib.Excel.Adress.ColRow_AsInt(out col, out rowNo, ref1);

                            //Debug.WriteLine($"Cell ref '{ref1}': {value}");
                            if (startRow != -1 && startRow != rowNo) continue; //<=======================================[ Skip rows if not applicable

                            // If there is a merge indicator then do the merge
                            if (mergeType == enExcel_MergeType.ExecuteMacro)
                            {
                                if (value.zIn("|>|", "|<|", "|V|", "|^|", "|V0|", "|^0|"))
                                {
                                    var newValue = sourceData.Value_Get(ref1);
                                    _lamed.lib.Excel.IO_Read.ConstructCellValue(cell, newValue);
                                }
                            }
                            else if (mergeType == enExcel_MergeType.InsertReferences && value.Contains("|"))
                            {
                                var ref2 = value.Replace("|", "");
                                var newValue = sourceData.Value_Get(ref2);
                                _lamed.lib.Excel.IO_Read.ConstructCellValue(cell, newValue);
                            }
                        }
                    }
                    #endregion

                    // Test writing
                    worksheet.WorksheetPart.Worksheet.Save();
                    spreadsheetDocument.Close();
                }
            }
        }

        /// <summary>Execute the Macros in the config file.</summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="dataConfig">The data configuration.</param>
        public void Execute_Data(pcExcelData_ dataSource, pcExcelData_ dataConfig)
        {
            foreach (List<string> row in dataConfig.Rows)
            {
                Execute_Row(dataSource, row);
            }
        }

        /// <summary>Executes macro on the row.</summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="row">The row.</param>
        private void Execute_Row(pcExcelData_ dataSource, List<string> row)
        {
            for (int ii = 0; ii < row.Count; ii++)
            {
                var value1 = row[ii].Trim();
                if (value1.Length < 3) continue;  // <=================================================

                if ("|" == value1.Substring(0, 1) && "|" == value1.Substring(value1.Length - 1, 1))
                {
                    value1 = value1.Replace("|", "");
                    var value2 = dataSource.Value_Get(value1).Trim();
                    if (value2.Contains(","))
                        value2 = value2.Replace(",", "");

                    row[ii] = value2;
                }
            }
        }

        /// <summary>Execute the macros in the code.</summary>
        /// <param name="data">The data.</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Compile(pcExcelData_ data, out string errorMsg)
        {
            errorMsg = "";

            // Loop through all the rows
            foreach (List<string> row in data.Rows)
            {
                string errMsg1;
                MacroItem.Compile_Row(row, out errMsg1);
                if (errMsg1 != "") errorMsg += errMsg1;
            }

            // Loop through all the cols
            var columns = data.Columns;
            var colNo = 0;
            foreach (List<string> col in columns)
            {
                string errMsg1;
                if (MacroItem.Compile_Column(col, out errMsg1))  // Compile the column values
                {
                    // Update the row values because something has changed
                    var rowNo = 0;
                    foreach (string value in col)
                    {
                        List<string> row = data.Rows[rowNo];
                        if (row.Count > colNo) row[colNo] = value;
                        rowNo++;
                    }
                }
                if (errMsg1 != "") errorMsg += errMsg1;
                colNo++;
            }

            // ==============================================
            // Look for |V>|
            List<string> addressList = _lamed.lib.Excel.Adress.Find(data, "|V>|", enExcel_Compare.Equal, enExcel_FindReturnValue.CellAddress);
            MacroItem.Compile_DownLeftCalculate(data,addressList);

            // ==============================================
            // |V0|
            addressList = _lamed.lib.Excel.Adress.Find(data, "|V0|", enExcel_Compare.Equal, enExcel_FindReturnValue.CellAddress);
            MacroItem.Compile_Down0Calculate(data, addressList);

            // =============================================
            // |^0|
            addressList = _lamed.lib.Excel.Adress.Find(data, "|^0|", enExcel_Compare.Equal, enExcel_FindReturnValue.CellAddress);
            MacroItem.Compile_Up0Calculate(data, addressList);

            errorMsg = errorMsg.Trim();
            if (errorMsg == "") return true;
            return false;
        }

        /// <summary>Test all the References in the sheet.</summary>
        /// <param name="data">The data.</param>
        /// <param name="resultMsg">The error MSG.</param>
        /// <returns></returns>
        public bool DataIntegrity_Check(pcExcelData_ data, out string resultMsg)
        {
            var result = true;
            resultMsg = "";

            List<string> reflines = _lamed.lib.Excel.Adress.Find(data, "|->");  // Search for |??|-> pattern
            // Parse the pattern & test
            foreach (string refline in reflines)
            {
                if (refline.Contains("{Sheet}->")) continue;  // Skip sheet import definitions

                string cellAddress, cellValue;
                MacroItem.DataIntegrity_CellParser(refline, out cellAddress, out cellValue);
                string msg;
                if (MacroItem.DataIntegrity_Check(data, cellAddress, cellValue, out msg) == false) result = false;
                if (resultMsg != "") resultMsg += "".NL();
                resultMsg += msg;
            }
            return result;
        }

        /// <summary>Test the Excel data file if it meets the sheets definition.</summary>
        /// <param name="data">The data.</param>
        /// <param name="sheetDef">The sheet definition.</param>
        /// <returns></returns>
        public bool DataIntegrity_Check(pcExcelData_ data, pcExcelDef_Sheet sheetDef)
        {
            foreach (pcExcelDef_Cell cell in sheetDef.Cells)
            {
                var value = data.Value_Get(cell.CellAddress);
                if (value != cell.CellValue) return false;
            }
            return true;
        }

        /// <summary>Create a Dashboard from Excel input sheets.</summary>
        /// <param name="folder">The folder.</param>
        /// <param name="dashboardInputFile">The input excel file.</param>
        /// <param name="dashboardResultFile">The dashboard result file.</param>
        public void Dashboard_FromSheets(string folder, string dashboardInputFile, string dashboardResultFile = "")
        {
            #region Load config file and parse macros ]=======================
            var fileConfig = folder + dashboardInputFile;
            if (_lamed.lib.IO.File.Exists(fileConfig) == false) $"Error! File '{fileConfig}' does not exists.".zException_Show();  // Test input
            var fileCompile = fileConfig.Replace(".xlsx", "_Compile.xlsx");
            if (dashboardResultFile == "") dashboardResultFile = fileConfig.Replace(".xlsx", "_Result.xlsx");

            _lamed.lib.IO.File.Copy(fileConfig, fileCompile, true);  // Copy config file to _Compile
            pcExcelData_ excelConfig = _lamed.lib.Excel.IO_Read.ExcelFile_LoadAsExcelData(fileCompile);  // Load the file

            // Compile the refeneces
            string errorMsg;
            _lamed.lib.Excel.Macro.Compile(excelConfig, out errorMsg); // Get the reference
            _lamed.lib.Excel.Macro.ExcelFile_Merge(fileCompile, excelConfig, enExcel_MergeType.ExecuteMacro);
            // ===========================================================================================
            #endregion

            #region Checks & get input files
            // ==================================================
            // Check if "{Sheet}->" exists
            // {Sheet}->"Q22",{Data}->|A5|,|A10|->"Name or Nickname:",|A14|->"1",|A35|->"22",|K12|->"Total"
            string sheetDefStr;
            if (excelConfig.Find_First(out sheetDefStr, "{Sheet}->") == false)
                "Error! Unable to find '{Sheet}->' in Excel sheet".zException_Show();   // Unit test needed for this line
            pcExcelDef_Sheet sheetDef = _lamed.lib.Excel.Macro.MacroItem.SheetDef_Parse(sheetDefStr);
            List<string> filesGood = Dashbaord_FindSheetFiles(folder, sheetDef);  // Get all Excel files from folder that meets search condition
            #endregion

            #region For all files apply macro references 
            // ==================================================
            _lamed.lib.IO.File.Copy(fileCompile, dashboardResultFile, true);
            var startAddress = sheetDef.DataCellAddress;
            foreach (string fileData in filesGood)
            {
                var dataExcel = _lamed.lib.Excel.IO_Read.ExcelFile_LoadAsExcelData(fileData);
                _lamed.lib.Excel.Macro.ExcelFile_Merge(dashboardResultFile, dataExcel, enExcel_MergeType.InsertReferences, "", startAddress);
                startAddress = _lamed.lib.Excel.Adress.CellAddress_NextRow(startAddress);
            }
            #endregion
        }

        /// <summary>Get all Excel files from folder that meets the sheet definition.</summary>
        /// <param name="folder">The folder.</param>
        /// <param name="sheetDef">The sheet definition.</param>
        /// <returns></returns>
        public List<string> Dashbaord_FindSheetFiles(string folder, pcExcelDef_Sheet sheetDef)
        {
            IEnumerable<string> files = _lamed.lib.IO.Search.Files(folder, "*.xlsx");

            // Find Excel files that meets conditions
            var filesGood = new List<string>();
            foreach (string fileInput in files)
            {
                pcExcelData_ dataTest = _lamed.lib.Excel.IO_Read.ExcelFile_LoadAsExcelData(fileInput);
                if (_lamed.lib.Excel.Macro.DataIntegrity_Check(dataTest, sheetDef)) filesGood.Add(fileInput);
            }
            return filesGood;
        }

    }
}
