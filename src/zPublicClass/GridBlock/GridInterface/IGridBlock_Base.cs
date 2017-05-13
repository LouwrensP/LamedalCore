using System.Collections.Generic;
using System.Drawing;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zPublicClass.GridBlock.GridInterface
{
    public interface IGridBlock_Base
    {

        /// <summary>Gets the parent.</summary>
        /// <value>The parent.</value>
        IGridBlock_Base _Parent { get; }

        /// <summary>Gets the name of the frontend control.</summary>
        string Name_Control { get; }

        /// <summary>Gets the current row of the parent.</summary>
        string Name_ParentRow { get; }

        /// <summary>Gets the current row of the parent.</summary>
        string Name_ChildRow { get; }

        /// <summary>Gets the name that will be displayed to the user.</summary>
        string Name_Caption(string seperator = ".",
            enGrid_AddressDefOrder addressDef = enGrid_AddressDefOrder.RowCol,
            enGrid_AddressValue addressRow = enGrid_AddressValue.Numeric,
            enGrid_AddressValue addressCol = enGrid_AddressValue.Numeric);

        // <summary>Gets the name that will be displayed to the user.</summary>
        string Name_Address { get; }

        /// <summary>
        /// Gets the grid blocks dictionary of all child grids.
        /// </summary>
        Dictionary<string, IGridBlock_Base> GridBlocksDictionary { get; }

        IGridBlock_Base GetChild_GridBlock(string macroAddress, bool showError = true);

        IGridControl zGridControl { get; set; }

        object zTag { get; set; }

        void State_Setup(double dValue, int iValue, Color color);
        void State_Setup(double dValue, int iValue = 0);
    }
}