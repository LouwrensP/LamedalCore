using System;
using System.Collections.Generic;
using LamedalCoreRemoved.ExcelData;

namespace LamedalCoreRemoved.Excel
{
    public sealed class Excel_MacroItem
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>Parse the row item and return true and ref values if the row item need to be calculated</summary>
        /// <param name="row">The row.</param>
        /// <param name="index">The index.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        public bool ItemRow_LessThan(List<string> row, int index, out string value1, out string value2)
        {
            // |<|
            if (row[index].Trim() == "|<|" && index < row.Count - 2)
            {
                // Get the previouse two values
                value1 = row[index + 2];
                value2 = row[index + 1];
                return true;
            }

            value1 = value2 = "";
            return false;
        }

        /// <summary>Parse the row item and return true and ref values if the row item need to be calculated</summary>
        /// <param name="row">The row.</param>
        /// <param name="index">The index.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        public bool ItemRow_GreaterThan(List<string> row, int index, out string value1, out string value2)
        {
            // |>|
            if (row[index].Trim() == "|>|" && index > 1)
            {
                // Get the previouse two values
                value1 = row[index - 2];
                value2 = row[index - 1];
                return true;
            }

            value1 = value2 = "";
            return false;
        }

        /// <summary>Parse the row item and return true and ref values if the row item need to be calculated</summary>
        /// <param name="col">The row.</param>
        /// <param name="index">The index.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        public bool ItemCol_Down(List<string> col, int index, out string value1, out string value2)
        {
            // |V|
            if (col[index].Trim() == "|V|" && index > 1)
            {
                // Get the previouse two values
                value1 = col[index - 2];
                value2 = col[index - 1];
                return true;
            }

            value1 = value2 = "";
            return false;
        }

        /// <summary>Parse the row item and return true and ref values if the row item need to be calculated</summary>
        /// <param name="col">The row.</param>
        /// <param name="index">The index.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        public bool ItemCol_Up(List<string> col, int index, out string value1, out string value2)
        {
            // |^|
            if (col[index].Trim() == "|^|" && index < col.Count - 2)
            {
                // Get the previouse two values
                value1 = col[index + 2];
                value2 = col[index + 1];
                return true;
            }

            value1 = value2 = "";
            return false;
        }

        /// <summary>Compiles the row.</summary>
        /// <param name="column">The row.</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <returns>If values were updated return true</returns>
        public bool Compile_Column(List<string> column, out string errorMsg)
        {
            var result = false;
            errorMsg = "";
            string value1, value2;
            // Get the first "|>|" and execute the macro
            for (int ii = 0; ii < column.Count; ii++)
            {
                if (ItemCol_Down(column, ii, out value1, out value2))
                {
                    string errMsg1;
                    column[ii] = Compile_NextValue(value1, value2, out errMsg1);  // Get the previouse two values
                    if (errMsg1 != "") errorMsg += errMsg1;
                    result = true;
                }
            }

            // Get the first "|<|" and execute the macro
            for (int ii = column.Count - 1; ii >= 0; ii--)
            {
                if (ItemCol_Up(column, ii, out value1, out value2))
                {
                    string errMsg1;
                    column[ii] = Compile_NextValue(value1, value2, out errMsg1);  // Get the previouse two values
                    if (errMsg1 != "") errorMsg += errMsg1;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>Compiles the row.</summary>
        /// <param name="row">The row.</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <exception cref="System.Exception"></exception>
        public bool Compile_Row(List<string> row, out string errorMsg)
        {
            errorMsg = "";
            string value1, value2;
            // Get the first "|>|" and execute the macro
            for (int ii = 0; ii < row.Count; ii++)
            {
                try
                {
                    if (ItemRow_GreaterThan(row, ii, out value1, out value2))
                    {
                        string errMsg1;
                        row[ii] = Compile_NextValue(value1, value2, out errMsg1);  // Get the previouse two values
                        if (errMsg1 != "") errorMsg += errMsg1;
                    }
                }
                catch (Exception ex)  // Unit test required for this exception
                {
                    ex.zException_Show("Error in row: " + row.zTo_Str(","));
                }
            }

            // Get the first "|<|" and execute the macro
            for (int ii = row.Count - 1; ii >= 0; ii--)
            {
                if (ItemRow_LessThan(row, ii, out value1, out value2))
                {
                    string errMsg1;
                    row[ii] = Compile_NextValue(value1, value2, out errMsg1);  // Get the previouse two values
                    if (errMsg1 != "") errorMsg += errMsg1;
                }
            }

            if (errorMsg == "") return true;
            return false;
        }

        /// <summary>Compiles the next cell value.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="errMsg">The error MSG.</param>
        /// <returns></returns>
        public string Compile_NextValue(string value1, string value2, out string errMsg)
        {
            errMsg = "";
            // Check the format of value1, value2
            value1 = value1.Trim();
            value2 = value2.Trim();

            if (_lamed.Types.Test.IsNumeric(value1))
            {
                // Number
                int val1 = value1.zTo_Int();
                int val2 = value2.zTo_Int();
                var result = val2 + (val2 - val1);
                return result.zTo_Str();
            }
            else
            {
                #region Address
                // Test if Value1, Value2 is valid addresses
                string errMsg1, errMsg2;
                var address1 = _IsValidMacroValue(ref value1, out errMsg1);
                var address2 = _IsValidMacroValue(ref value2, out errMsg2);
                errMsg = errMsg1.NL() + errMsg2;

                if (address1 && address2)
                {
                    int col1, row1, col2, row2;
                    _lamed.lib.Excel.Adress.ColRow_AsInt(out col1, out row1, value1);
                    _lamed.lib.Excel.Adress.ColRow_AsInt(out col2, out row2, value2);
                    int resultCol = col2 + (col2 - col1);
                    int resultRow = row2 + (row2 - row1);
                    var result = _lamed.lib.Excel.Adress.CellAddress(resultCol, resultRow, false);
                    return "|" + result + "|";
                }
                else return "|??|";
                #endregion
            }
        }

        /// <summary>Test if the Cell value is a valid macro.</summary>
        /// <param name="value">The value.</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <returns></returns>
        public bool _IsValidMacroValue(ref string value, out string errorMsg)
        {
            errorMsg = "";
            if (value.Length < 2) errorMsg = $"Error! '{value}' is not a macro setting.";
            if ("|" != value.Substring(0, 1)) errorMsg = $"Error! '{value}' is not a macro setting.";
            if ("|" != value.Substring(value.Length - 1, 1)) errorMsg = $"Error! '{value}' is not a macro setting.";
            if (errorMsg != "") return false;  // <-----------------------------------------------------------------

            value = value.Replace("|", "");
            if (value == "??")
            {
                errorMsg = "Error! ?? is undefined.";
                return false; // <----------------------------------------------------------------------------
            }

            return true;
        }

        /// <summary>From the cell list calculate a new value from the top and left cell name</summary>
        /// <param name="data">The data.</param>
        /// <param name="addressList">The address list.</param>
        public void Compile_DownLeftCalculate(pcExcelData_ data, List<string> addressList)
        {
            // '|V>|'
            foreach (string cell in addressList)
            {
                int col, row;
                _lamed.lib.Excel.Adress.ColRow_AsInt(out col, out row, cell);
                var value1 = data.Value_Get(col, row - 1);
                var value2 = data.Value_Get(col - 1, row);
                var value = Compile_CellMergeValues(value1, value2);
                data.Value_Set(cell, value);
            }
        }

        /// <summary>Compile the |V0| macro code</summary>
        /// <param name="data">The data.</param>
        /// <param name="addressList">The address list.</param>
        public void Compile_Down0Calculate(pcExcelData_ data, List<string> addressList)
        {
            foreach (string cell in addressList)
            {
                int col, row;
                _lamed.lib.Excel.Adress.ColRow_AsInt(out col, out row, cell);
                var value1 = data.Value_Get(col, row - 1);
                data.Value_Set(cell, value1);
            }
        }

        /// <summary>Compile the |^0| macro code</summary>
        /// <param name="data">The data.</param>
        /// <param name="addressList">The address list.</param>
        public void Compile_Up0Calculate(pcExcelData_ data, List<string> addressList)
        {
            addressList.Reverse();
            foreach (string cell in addressList)
            {
                int col, row;
                _lamed.lib.Excel.Adress.ColRow_AsInt(out col, out row, cell);
                var value1 = data.Value_Get(col, row + 1);
                data.Value_Set(cell, value1);
            }
        }

        /// <summary>Compiles the next cell value.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        public string Compile_CellMergeValues(string value1, string value2)
        {
            bool value1Macro = false;
            bool value2Macro = false;

            // Check the format of value1, value2
            value1 = value1.Trim();
            value2 = value2.Trim();
            string errorMsg1, errorMsg2;
            //if (value1.Contains("|")) value1Macro = true;
            // if (value2.Contains("|")) value2Macro = true;
            if (_IsValidMacroValue(ref value1, out errorMsg1)) value1Macro = true;
            if (_IsValidMacroValue(ref value2, out errorMsg2)) value2Macro = true;
            if (value1Macro != value2Macro) throw new ArgumentException($"Error! Inconsistent parameters '{value1}' and '{value2}'.".NL() + errorMsg1.NL() + errorMsg2);

            // value1 = value1.Replace("|", "");
            //value2 = value2.Replace("|", "");

            int col1, row1, col2, row2;
            _lamed.lib.Excel.Adress.ColRow_AsInt(out col1, out row1, value1);
            _lamed.lib.Excel.Adress.ColRow_AsInt(out col2, out row2, value2);
            var resultCol = col1;
            var resultRow = row2;
            var result = _lamed.lib.Excel.Adress.CellAddress(resultCol, resultRow);
            if (value1Macro) result = "|" + result + "|";
            return result;

        }


        /// <summary>Checks the data integrity of the sheet.</summary>
        /// <param name="data">The data.</param>
        /// <param name="cellAddress">The cell address.</param>
        /// <param name="cellValue">The cell value.</param>
        /// <param name="resultMsg">The error MSG.</param>
        /// <returns></returns>
        public bool DataIntegrity_Check(pcExcelData_ data, string cellAddress, string cellValue, out string resultMsg)
        {
            var testValue = data.Value_Get(cellAddress);
            if (cellValue != testValue)
            {
                resultMsg = $"Reference check address: '{cellAddress}' == '{testValue}'  (Error! Should be '{cellValue}').";
                return false;
            }
            resultMsg = $"Reference check address: '{cellAddress}' == '{testValue}' (Ok).";
            return true;
        }

        /// <summary>Return the References the cell address and cell value.</summary>
        /// <param name="item">The item.</param>
        /// <param name="cellAddress">The cell address.</param>
        /// <param name="cellValue">The cell value.</param>
        public void DataIntegrity_CellParser(string item, out string cellAddress, out string cellValue)
        {
            cellAddress = item.zvar_Id("->");
            cellAddress = cellAddress.Replace("|", "");
            cellValue = item.zvar_Value("->");
            cellValue = cellValue.Replace("\"", "").Trim();
        }

        /// <summary>Parses the sheet definition values into a class.</summary>
        /// <param name="parseValue">The value that must be parsed.</param>
        /// <returns></returns>
        public pcExcelDef_Sheet SheetDef_Parse(string parseValue)
        {
            // {Sheet}->"Q22";{Data}->|A5|;|A10|->"Name or Nickname:";|A14|->"1";|A35|->"22";|K12|->"Total"
            // ============================================================================================

            if (parseValue.Contains("{Sheet}->") == false) "Error! '{Sheet}->' was not found.".zException_Show();
            if (parseValue.Contains(";{Data}->") == false) "Error! ';{Data}->' was not found.".zException_Show();
            if (parseValue.Contains("|->") == false) "Error! '|->' cell reference was not found.".zException_Show();

            var valueList = parseValue.zConvert_Str_ToListStr(";|");
            if (valueList.Count < 3) "Error! No cell references checks defined.".zException_Show();

            var result = new pcExcelDef_Sheet();
            // SheetName ]=================================
            var dataCellAddress = valueList[0];
            "}->".zVar_Next(ref dataCellAddress, true);
            var sheetName = ";{Data}->".zVar_Next(ref dataCellAddress, true);
            if (sheetName.Contains("\"") == false) $"Error! Sheet ref '{sheetName}' does not contain quotes.".zException_Show();  // This is extra safety test
            result.SheetName = sheetName.Replace("\"", "");

            // DataCellAddress ]===========================
            result.DataCellAddress = dataCellAddress.Replace("|", "");

            for (int ii = 1; ii < valueList.Count; ii++)
            {
                var val = valueList[ii];
                var address = val.zvar_Id("|->");
                var value = val.zvar_Value("|->");
                if (value.Contains("\"") == false) $"Error! Cell value '{val}' does not contain quotes.".zException_Show();
                var cell = new pcExcelDef_Cell
                {
                    CellAddress = address,
                    CellValue = value.Replace("\"", "")
                };
                result.Cells.Add(cell);
            }
            return result;
        }
    }
}
