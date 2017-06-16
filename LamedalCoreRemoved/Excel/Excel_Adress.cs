using System;
using System.Collections.Generic;
using LamedalCoreRemoved.ExcelData;

namespace LamedalCoreRemoved.Excel
{
    /// <summary>
    /// Order must be Col, Row
    /// </summary>
    public sealed class Excel_Adress
    {
        /// <summary>Col number to cell name.</summary>
        /// <param name="columnNumber">The colName number</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        /// <returns>string</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Error! Value can not be 0.</exception>
        public string ColName_FromColNumber(int columnNumber, bool showError = true)
        {
            if (columnNumber < 1)
            {
                if (showError) throw new ArgumentOutOfRangeException(nameof(columnNumber), "Error! Value can not be 0.");
                return "?";
            }

            int dividend = columnNumber;
            string columnName = "";

            while (dividend > 0)
            {
                int modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo) + columnName;
                dividend = (dividend - modulo) / 26;
            }
            return columnName;
        }

        /// <summary>Cell Name to int value.</summary>
        /// <param name="cellAddress">The name</param>
        /// <returns>int</returns>
        public int ColName_2Int(string cellAddress = "A1")
        {
            int row;
            string colName;
            ColRow_AsRefName(out colName, out row, cellAddress);  // if cellName = "A1" get the "A"

            int number = 0;
            int startValue = 1;
            for (int ii = colName.Length - 1; ii >= 0; ii--)
            {
                char value = colName[ii];
                {
                    number += (value - 'A' + 1) * startValue;
                    startValue *= 26;
                }
            }
            return number;
        }

        /// <summary>Calculate cell address from the row and col numbers.</summary>
        /// <param name="col">The col</param>
        /// <param name="row">The row</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        /// <returns>string</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Error! Value of argument can not be 0.</exception>
        public string CellAddress(int col, int row, bool showError = true)
        {
            var rowStr = "";
            if (row < 1)
            {
                rowStr = "?";
                if (showError) throw new ArgumentOutOfRangeException(nameof(row), "Error! Value of argument can not be 0.");
            }
            else rowStr = rowStr + row;

            string colName = ColName_FromColNumber(col, showError);
            string result = colName + rowStr;
            return result;
        }

        /// <summary>Calculate cell address for the cell below on the next row.</summary>
        /// <param name="cellAddress">The cell address.</param>
        /// <returns>string</returns>
        public string CellAddress_NextRow(string cellAddress)
        {
            int col, row;
            ColRow_AsInt(out col, out row, cellAddress);
            row++;
            return CellAddress(col, row);
        }

        /// <summary>Calculate cell address for the cell in the next column.</summary>
        /// <param name="cellAddress">The cell address.</param>
        /// <returns>string</returns>
        public string CellAddress_NextCol(string cellAddress)
        {
            int col, row;
            ColRow_AsInt(out col, out row, cellAddress);
            col++;
            return CellAddress(col, row);
        }

        /// <summary>Parse cell and return the colName and the row.</summary>
        /// <param name="colName">Return the colName</param>
        /// <param name="row">Return the row</param>
        /// <param name="cellName">The cell name setting. Default value = "A1".</param>
        public void ColRow_AsRefName(out string colName, out int row, string cellName = "A1")
        {
            //string col = "AB21";
            int startIndex = cellName.IndexOfAny("?0123456789".ToCharArray());
            if (startIndex == -1)
            {
                //$"Error! Cellname '{cellName}' does not contain a number.".zException_Show();
                colName = cellName;
                row = 0;
                return;
            }
            colName = cellName.Substring(0, startIndex);
            var rowNo = cellName.Substring(startIndex);
            if (rowNo == "?") row = 0;
            else row = Int32.Parse(rowNo);
        }

        /// <summary>Get the cell address</summary>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        /// <param name="cellName">Name of the cell.</param>
        public void ColRow_AsInt(out int col, out int row, string cellName = "A1")
        {
            string colName;
            ColRow_AsRefName(out colName, out row, cellName);
            col = ColName_2Int(colName);
        }

        /// <summary>Calculateulates the range from cell. Default value = "A1"..</summary>
        /// <param name="cellStart">Cell starts the setting. Default value = "A1".</param>
        /// <param name="columns">The add columns setting. Default value = 0.</param>
        /// <param name="rows">The add rows setting. Default value = 0.</param>
        /// <returns>string</returns>
        public string Range(string cellStart = "A1", int columns = 1, int rows = 1)
        {
            if (columns < 1) "Error! Columns must be 1 or greater!".zException_Show();
            if (rows < 1) "Error! Rows must be 1 or greater!".zException_Show();

            string colName;
            int row;
            ColRow_AsRefName(out colName, out row, cellStart);
            int colNo = ColName_2Int(colName);
            colNo += columns - 1;
            row += rows - 1;

            var result = CellAddress(colNo, row);
            return result;
        }

        /// <summary>Get the Reference point.</summary>
        /// <param name="data">The data.</param>
        /// <param name="findValue">The find value.</param>
        /// <param name="compare">The compare formula to use.</param>
        /// <param name="returnType">Specify what should be returned.</param>
        /// <returns></returns>
        public List<string> Find(pcExcelData_ data, string findValue = "|->", enExcel_Compare compare = enExcel_Compare.Contains, enExcel_FindReturnValue returnType = enExcel_FindReturnValue.CellValue)
        {
           
            var result = new List<string>();
            int rowNo = 1;
            foreach (List<string> row in data.Rows)
            {
                var colNo = 1;
                foreach (string item in row)
                {
                    bool found = false;
                    if (compare == enExcel_Compare.Contains)
                    {
                         if (item.Contains(findValue)) found = true;
                    }
                    else if (item == findValue) found = true;

                    if (found)
                    {
                        if (returnType == enExcel_FindReturnValue.CellValue) result.Add(item);
                        else result.Add(CellAddress(colNo, rowNo));
                    }
                    colNo++;
                }
                rowNo++;
            }
            return result;
        }

        ///// <summary>Gets all the cells that contain's |V>|.</summary>
        ///// <param name="data">The data.</param>
        ///// <returns></returns>
        //public List<string> Compile_DownLeftCells(ExcelData_ data)
        //{
        //    return Find(data, "|V>|", enExcelCompare.Equal, enExcelFindReturnValue.CellAddress);

        //    //var result = new List<string>();
        //    //var rowNo = 1;
        //    //foreach (List<string> row in data.Rows)
        //    //{
        //    //    var colNo = 1;
        //    //    foreach (string cell in row)
        //    //    {
        //    //        if (cell == "|V>|")
        //    //        {
        //    //            var address = CellAddress(colNo, rowNo, false);  // Todo: fix this macro to do everything
        //    //            result.Add(address);
        //    //        }
        //    //        colNo++;
        //    //    }
        //    //    rowNo++;
        //    //}
        //    //return result;
        //}

        /// <summary>Finds the first occurance.</summary>
        /// <param name="data">The data.</param>
        /// <param name="result">The result.</param>
        /// <param name="findValue">The find value.</param>
        /// <param name="compare">The compare formula to use.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <returns></returns>
        public bool Find_First(pcExcelData_ data, out string result, string findValue = "|->", enExcel_Compare compare = enExcel_Compare.Contains,
            enExcel_FindReturnValue returnType = enExcel_FindReturnValue.CellValue)
        {
            result = "";
            var findList = Find(data, findValue, compare, returnType);
            if (findList.Count == 0) return false;

            result = findList[0];
            return true;
        }
    }
}
