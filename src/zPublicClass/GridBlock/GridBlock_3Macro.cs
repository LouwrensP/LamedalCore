using System;
using System.Drawing;
using LamedalCore.domain.Enumerals;
using LamedalCore.domain.Events;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.zPublicClass.GridBlock
{
    public sealed class GridBlock_3Macro : GridBlock_0BaseState, IGridBlock
    {
        /// <summary>Initializes a new instance of the <see cref="GridBlock_1Micro" /> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="onGridRowCreate">The on grid row create.</param>
        /// <param name="macroName"></param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <param name="subName"></param>
        /// <param name="subRows">The sub rows.</param>
        /// <param name="subCols">The sub cols.</param>
        /// <param name="microName"></param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        public GridBlock_3Macro(IGridBlock_Base parent, onGrid_CreateItem onGridCreate, onGrid_CreateItem onGridRowCreate, 
            string macroName, int row, int col, 
            string subName = "sub", int subRows = 5, int subCols = 5, 
            string microName = "micro", int microRows = 5, int microCols = 5) : base(parent, row, col, macroName)
        {
            Child_BlockType = enGrid_BlockType.SubBlock;
            Child_DisplayType = enGrid_BlockDisplayType.Name;
            Child_Cols = subCols;
            Child_Rows = subRows;

            onGridCreate?.Invoke(this, enGrid_BlockType.MacroBlock);

            // Create the child objects
            CreateSubGrids(onGridCreate, onGridRowCreate, subName, subRows, subCols, microName, microRows, microCols);
        }

        /// <summary>
        /// Creates the sub grids.
        /// </summary>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="onGridRowCreate">The on grid row create.</param>
        /// <param name="subName"></param>
        /// <param name="subRows">The sub rows.</param>
        /// <param name="subCols">The sub cols.</param>
        /// <param name="microName"></param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        public void CreateSubGrids(onGrid_CreateItem onGridCreate, onGrid_CreateItem onGridRowCreate, 
                    string subName, int subRows, int subCols, 
                    string microName, int microRows, int microCols)
        {
            GridBlock_2Sub gridSub = null;
            for (int row1 = 1; row1 <= subRows; row1++)
            {
                Name_ChildRow = GridBlock_zMethods.Name_ChildRow(this, row1);
                onGridRowCreate?.Invoke(this, Child_BlockType);

                for (int col1 = 1; col1 <= subCols; col1++)
                {
                    if (GetChild_GridBlock($"{row1}_{col1}", false) == null)
                    {
                        // The childblock does not exists
                        gridSub = new GridBlock_2Sub(this, onGridCreate, onGridRowCreate, 
                            subName, row1, col1,
                            microName, microRows, microCols);
                        _GridBlocksDictionary.Add(gridSub.Name_Address, gridSub);
                    }
                }
            }


            Child_Count = subRows * subCols * microCols * microRows;
        }

        public enGrid_BlockType Child_BlockType { get; }
        public int Child_Count { get; private set; }
        public int Child_Rows { get; }
        public int Child_Cols { get; }
        public enGrid_BlockDisplayType Child_DisplayType { get; set; }

    }
}