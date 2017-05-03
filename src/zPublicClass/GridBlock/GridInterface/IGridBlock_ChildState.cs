using LamedalCore.domain.Enumerals;

namespace LamedalCore.zPublicClass.GridBlock.GridInterface
{
    public interface IGridBlock_ChildState
    {
        /// <summary>Gets or sets the type of the block.</summary>
        /// <value>The type of the block.</value>
        enGrid_BlockType Child_BlockType { get;}

        /// <summary>Gets or sets the display type.</summary>
        /// <value>The display type.</value>
        enGrid_BlockDisplayType Child_DisplayType { get; set; }

        int Child_Count { get; }

        int Child_Rows { get; }

        int Child_Cols { get; }
    }
}