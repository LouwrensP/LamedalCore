using System.Collections.Generic;
using LamedalCoreRemoved.ExcelData;

namespace LamedalCoreRemoved.Excel
{
    public sealed class Excel_About
    {
        ///// <summary>Generate Excel document to describe the Macro commands available.</summary>
        //public string About_Excel(string outputFile = "AboutExcelSetup.csv")
        //{
        //    List<string> aboutExcel_AsList = About_Excel_ToList();
        //    var data = new pcExcelData_();
        //    var array = aboutExcel_AsList.ToArray();
        //    data.csvLoadFromLines(array);

        //    // Test all integrity points
        //    string errorMsg;
        //    if (_lamed.lib.Excel.Macro.DataIntegrity_Check(data, out errorMsg) == false) errorMsg.zException_Show();  // Unit test needed 

        //    var folder = _lamed.lib.IO.Folder.Path_Application();
        //    var result = folder + outputFile;
        //    data.csvSave2File(result, true);
        //    return result;
        //}

        /// <summary>Return the Excel About message as a list. This is used for testing</summary>
        /// <returns></returns>
        public List<string> About_Excel_ToList()
        {
            #region Definition

            // ========================
            //  Excel Specifications
            // ========================

            // You can use the arrows to complete linear patters:
            // ==================================================
            //       ,      , Test1
            //  1    ,  2   , |>|  , |>|, -->, 1    , 2   , 3   , 4
            // |A2|  , |C4| , |>|  , |>|, -->, |A2| , |C4|, |E6|, |G8|
            // Test2 , |B3| , |C3| , |>|, -->, Test3, |B3|, |C3|, |D4|
            // |<|   , |<|  ,  10  ,  15, -->, 0    , 5   ,  10 , 15
            //       ,      , Test4
            //       ,
            // You can use the following arrows to complete linear patterns:    
            //   |>| , |<|, |V|, |^| 
            //   |V>|,(Get first value of address from top and second value from the left)
            //
            // To combine data from many sheets you can use the following commands:  
            //   {Sheet}->"Q22",{Data}->|A5|,|A10|->"Name or Nickname:",|A14|->"1",|A35|->"22",|K12|->"Total"
            //   -> ForAll Sheets with name "Q22" and ref cells A14==1, A35==22, K12==Total; Begin import at cell A5
            //   |V0|,(Copy values from the top row to the current row. Used for multiple files.)  
            //   |^0|,(Copy values from bottom  row to the current row. Used for multiple files.)

            // References Test:
            // ================
            // |C2|->"Test1",(Check if address C2 has value "Test1")
            // |A5|->Test2  ,(Check if address A5 has value "Test2")
            // |F5|->Test3  ,(Check if address F5 has value "Test3")
            // |C7|->Test4  ,(Check if address C7 has value "Test4")
            // ========================

            #endregion

            var lines = new List<string>();

            lines.Add(" You can use the arrows to complete linear patters:");
            lines.Add(" ==================================================");
            lines.Add("       ,      , Test1");
            lines.Add("  1    ,  2   , |>|  , |>|, ------>, 1    , 2   , 3   , 4");
            lines.Add(" |A2|  , |C4| , |>|  , |>|, ------>, |A2| , |C4|, |E6|, |G8|");
            lines.Add(" Test2 , |B3| , |C3| , |>|, ------>, Test3, |B3|, |C3|, |D4|");
            lines.Add(" |<|   , |<|  ,  10  ,  15, ------>, 0    , 5   ,  10 , 15");
            lines.Add("       ,      , Test4");
            lines.Add("       ,");
            lines.Add(" You can use the following arrows to complete linear patterns:    ");
            lines.Add(" =============================================================");
            lines.Add(" |>| , (Calculate linear pattern from left two values)");
            lines.Add(" |<|,  (Calculate linear pattern from right two values)");
            lines.Add(" |V|,  (Calculate linear pattern from top two values)");
            lines.Add(" |^|,  (Calculate linear pattern from bottom two values)");
            lines.Add(" |V>|, (Get first value of address from top and second value from the left)");
            lines.Add("");
            lines.Add(" To combine data from many sheets you can use the following commands:  ");
            lines.Add(" ===================================================================");
            lines.Add(
                "   {Sheet}->\"Q22\";{Data}->|A5|;|A10|->\"Name or Nickname:\";|A14|->\"1\";|A35|->\"22\";|K12|->\"Total\"");
            lines.Add(
                "   -> ForAll Sheets with name \"Q22\" and ref cells A14==1; A35==22; K12==Total; Import first sheet data to cell A5. (Next sheets to A6; A7... etc.)");
            lines.Add("   |V0|,(Copy values from the top row to the current row. Used for multiple files.)");
            lines.Add("   |^0|,(Copy values from bottom  row to the current row. Used for multiple files.)");
            lines.Add("");
            lines.Add(" References Tests:");
            lines.Add(" =================");
            lines.Add(" |C3|->\"Test1\",,(Check if address C3 has value \"Test1\")");
            lines.Add(" |A6|->Test2    ,,(Check if address A6 has value \"Test2\")");
            lines.Add(" |F6|->Test3    ,,(Check if address F6 has value \"Test3\")");
            lines.Add(" |C8|->Test4    ,,(Check if address C8 has value \"Test4\")");
            // =================================================================
            return lines;
        }
    }
}
