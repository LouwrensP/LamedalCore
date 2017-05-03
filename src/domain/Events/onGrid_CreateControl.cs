using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.domain.Events
{
    /// <summary>
    /// This event is fired when a new control need to be created on the frontend.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="gridControlType">Type of the grid control.</param>
    /// <param name="parentName">Name of the parent.</param>
    /// <param name="childName">Name of the child.</param>
    /// <param name="blockType">Type of the block.</param>
    /// <param name="gridControl">The grid control.</param>
    public delegate void onGrid_CreateControl(IGridBlock_Base sender, enGrid_ControlType gridControlType,
        string parentName, string childName, enGrid_BlockType blockType, ref IGridControl gridControl);
}