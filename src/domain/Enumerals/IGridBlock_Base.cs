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

        ///// <summary>Gets the name that will be displayed to the user.</summary>
        //string Name_Caption(string seperator = ".",
        //    enGrid_AddressDefOrder addressDef = enGrid_AddressDefOrder.RowCol,
        //    enGrid_AddressValue addressRow = enGrid_AddressValue.Numeric,
        //    enGrid_AddressValue addressCol = enGrid_AddressValue.Numeric);

        string Name_Caption(GridControl_Settings settings = null);

        // <summary>Gets the name that will be displayed to the user.</summary>
        string Name_Address { get; }

        /// <summary>
        /// Gets the grid blocks dictionary of all child grids.
        /// </summary>
        Dictionary<string, IGridBlock_Base> GridBlocksDictionary { get; }

        /// <summary>Gets the child grid block.</summary>
        /// <param name="searchValue">The macro address or search value.</param>
        /// <param name="searchItem">The search item.</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        /// <returns></returns>
        IGridBlock_Base GetChild_GridBlock(string searchValue, enGrid_BlockDisplayType searchItem = enGrid_BlockDisplayType.Address, bool showError = true);

        /// <summary>Gets the child grid blocks.</summary>
        /// <returns></returns>
        List<IGridBlock_Base> GetChild_GridBlocks();

        IGridControl zGridControl { get; set; }

        object zTag { get; set; }

        void State_Setup(double dValue, int iValue, Color color);
        void State_Setup(double dValue, int iValue = 0);
    }
}