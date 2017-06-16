using System.Collections.Generic;
using System.Text;

namespace LamedalCoreRemoved.Excel
{
    public sealed class Excel_Csv
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>Saves the file to CSV</summary>
        /// <param name="csvFilename">The CSV filename.</param>
        /// <param name="dataRows">The data rows.</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        public void DataRows_2csvFile(string csvFilename, List<List<string>> dataRows, bool overwrite = false)
        {
            var lines = new List<string>();
            foreach (List<string> row in dataRows)
            {
                var rowStr = row.zTo_Str(",");
                lines.Add(rowStr);
            }
            if (overwrite) LamedalCore_.Instance.lib.IO.RW.File_Write(csvFilename, lines.ToArray(), overwrite);
        }

        /// <summary>Loads the from csv lines.</summary>
        public void DataRows_FromCsvLines(List<List<string>> dataRows, string[] lines)
        {
            dataRows.Clear();
            foreach (var row in lines)
            {
                var rowList = DataRow_FromCsvLine(row, ',', '~'); // Do not remove quotes
                dataRows.Add(rowList);
            }
            _lamed.lib.Excel.Data.Normalize(dataRows);
        }

        private List<string> DataRow_FromCsvLine(string row, char fieldSep = ',', char strBackSlash = '\"')
        {
            bool quote = false;
            var strBuilder = new StringBuilder();
            var rowArray = new List<string>();

            var charArray = row.ToCharArray();
            foreach (char cc in charArray)
                if ((cc == fieldSep && !quote))
                {
                    rowArray.Add(strBuilder.ToString().Trim());
                    strBuilder.Clear();
                }
                else
                {
                    if (cc == strBackSlash) quote = !quote;  // Unit test needed for this line
                    else strBuilder.Append(cc);
                }
            /* to solve the last element problem */
            rowArray.Add(strBuilder.ToString().Trim()); /* added this line */
            return rowArray;
        }

    }
}
