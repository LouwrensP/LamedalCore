using LamedalCore.domain.Enumerals;
using LamedalCore.domain.Events;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.zPublicClass.GridBlock
{
    public sealed class GridBlock_4Cuboid : GridBlock_0Base, IGridBlock_ChildState
    {
        /// <summary>Initializes a new instance of the <see cref="GridBlock_4Cuboid" /> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="onGridRowCreate">The on grid row create.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="macroRows">The macro rows.</param>
        /// <param name="macroCols">The child rows.</param>
        /// <param name="subRows">The sub rows.</param>
        /// <param name="subCols">The sub cols.</param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        public GridBlock_4Cuboid(IGridBlock_Base parent, onGrid_CreateItem onGridCreate, onGrid_CreateItem onGridRowCreate, 
            GridControl_Settings settings, int macroRows = 1, int macroCols = 1, int subRows = 5, int subCols = 5, 
            int microRows = 5, int microCols = 5) : base(parent, 1, 1, settings)
        {
            Child_BlockType = enGrid_BlockType.MacroBlock;
            Child_DisplayType = enGrid_BlockDisplayType.Address;
            Child_Cols = macroCols;
            Child_Rows = macroRows;

            onGridCreate?.Invoke(this, enGrid_BlockType.CuboidGrid);
        
            // Create the child objects
            int ii = 0;
            for (int row1 = 1; row1 <= macroRows; row1++)
            {
                Name_ChildRow = GridBlock_zMethods.Name_ChildRow(this, row1);
                onGridRowCreate?.Invoke(this, Child_BlockType);

                for (int col = 1; col <= macroCols; col++)
                {
                    ii++;
                    var grid = new GridBlock_3Macro(this, onGridCreate, onGridRowCreate, settings,
                            ii, row1, col, 
                            subRows, subCols, 
                            microRows, microCols);
                    _GridBlocksDictionary.Add(grid.Name_Address, grid);
                }
            }
            Child_Count = macroRows * macroCols * subRows * subCols * microRows * microCols;
        }
        
        public enGrid_BlockType Child_BlockType { get; }
        public int Child_Count { get; }
        public int Child_Rows { get; }
        public int Child_Cols { get; }
        public enGrid_BlockDisplayType Child_DisplayType { get; set; }

    }
}
