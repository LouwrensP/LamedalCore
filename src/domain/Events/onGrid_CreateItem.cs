using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.domain.Events
{

    /// <summary>
    /// This event fire when a new element (grid or row) is created on the grid data structures.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="blockType">Type of the block.</param>
    public delegate void onGrid_CreateItem(IGridBlock_Base sender, enGrid_BlockType blockType);
}