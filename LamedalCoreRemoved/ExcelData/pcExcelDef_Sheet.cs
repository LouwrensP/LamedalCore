using System.Collections.Generic;

namespace LamedalCoreRemoved.ExcelData
{
    /// <summary>
    /// {Sheet}->"Q22",{Data}->|A5|,|A10|->"Name or Nickname:",|A14|->"1",|A35|->"22",|K12|->"Total"
    /// </summary>
    public sealed class pcExcelDef_Sheet
    {
        public string SheetName;
        public string DataCellAddress;
        public List<pcExcelDef_Cell> Cells = new List<pcExcelDef_Cell>();
    }
}