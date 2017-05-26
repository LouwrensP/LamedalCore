using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.ExcelData;

namespace LamedalCore.lib.Excel
{
    public sealed class Excel_Data
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;


        /// <summary>Sets the value of a cell</summary>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        /// <param name="value">The value.</param>
        public void Value_Set(pcExcelData_ excelData, int col, int row, string value)
        {
            // Add the rows if required
            while (excelData.Row_Count < row)
            {
                excelData.Rows.Add(new List<string>());
            }
            var rowList = excelData.Rows[row - 1];
            while (rowList.Count < col) rowList.Add("");

            excelData.Rows[row - 1][col - 1] = value;
        }

        public void Value_Set(pcExcelData_ excelData, string cellRef = "A1", string value = "")
        {
            int col, row;
            LamedalCore_.Instance.lib.Excel.Adress.ColRow_AsInt(out col, out row, cellRef);
            Value_Set(excelData, col, row, value);
        }
        /// <summary>Gets the cell value</summary>
        /// <param name="excelData">The excel data.</param>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        public string Value_Get(pcExcelData_ excelData, int col, int row)
        {
            var row1 = excelData.Row(row);
            var result = row1[col - 1];
            return result.Trim();
        }

        /// <summary>Gets the cell value</summary>
        /// <param name="excelData">The excel data.</param>
        /// <param name="cellName">Name of the cell.</param>
        /// <returns></returns>
        public string Value_Get(pcExcelData_ excelData, string cellName)
        {
            int col, row;
            LamedalCore_.Instance.lib.Excel.Adress.ColRow_AsInt(out col, out row, cellName);
            return Value_Get(excelData, col, row);
        }

        /// <summary>Compares two data sheets and return the differences.</summary>
        /// <param name="input1">The input1.</param>
        /// <param name="result1">The result1.</param>
        /// <param name="returnValue">The return value.</param>
        /// <returns></returns>
        public List<string> CompareDataSheet(pcExcelData_ input1, pcExcelData_ result1, enExcel_FindReturnValue returnValue = enExcel_FindReturnValue.CellAddress)
        {
            var result = new List<string>();
            var rowNo = 1;
            foreach (List<string> row in input1.Rows)
            {
                var colNo = 1;
                foreach (string value in row)
                {
                    var resultValue = result1.Value_Get(colNo, rowNo);
                    if (value != resultValue)
                    {
                        var address = _lamed.lib.Excel.Adress.CellAddress(colNo, rowNo);
                        var valueDiff = $"Value '{value}' != '{resultValue}'";
                        switch (returnValue)
                        {
                            case enExcel_FindReturnValue.CellAddress: result.Add(address); break;
                            case enExcel_FindReturnValue.CellValue: result.Add(valueDiff); break;
                            case enExcel_FindReturnValue.CellAddressAndValue: result.Add(address + " -> " + valueDiff); break;
                            default: throw new Exception($"Argument '{nameof(returnValue)}' error.");
                        }
                    }
                    colNo++;
                }
                rowNo++;
            }

            return result;
        }

        /// <summary>Normalizes the specified excel data. Ensure all rows have equal columns</summary>
        /// <param name="excelData">The excel data.</param>
        public void Normalize(List<List<string>> dataRows)
        {
            // Get the max colcount;
            var count = 0;
            foreach (List<string> row in dataRows) if (row.Count > count) count = row.Count;

            foreach (List<string> row in dataRows)
            {
                while (row.Count < count)
                {
                    row.Add("");
                }
            }
        }
    }
}
