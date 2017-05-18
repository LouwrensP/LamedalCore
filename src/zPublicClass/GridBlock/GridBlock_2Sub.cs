using System;
using System.Drawing;
using LamedalCore.domain.Enumerals;
using LamedalCore.domain.Events;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.zPublicClass.GridBlock
{
    public sealed class GridBlock_2Sub : GridBlock_0BaseState, IGridBlock
    {
        /// <summary>Initializes a new instance of the <see cref="GridBlock_1Micro" /> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="onGridRowCreate">The on grid row create.</param>
        /// <param name="subName"></param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <param name="microName"></param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        public GridBlock_2Sub(IGridBlock_Base parent, onGrid_CreateItem onGridCreate, onGrid_CreateItem onGridRowCreate, 
                        string subName, int row, int col, 
                        string microName, int microRows = 5, int microCols = 5) : base(parent, row, col, subName)
        {
            Child_BlockType = enGrid_BlockType.MicroBlock;
            Child_DisplayType = enGrid_BlockDisplayType.Name;
            Child_Cols = microCols;
            Child_Rows = microRows;

            onGridCreate?.Invoke(this, enGrid_BlockType.SubBlock);

            CreateMicroGrids(onGridCreate, onGridRowCreate, microName, microRows, microCols);
        }

        /// <summary>Creates the micro grids.</summary>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="onGridRowCreate">The on grid row create.</param>
        /// <param name="microName">Name of the micro.</param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        public void CreateMicroGrids(onGrid_CreateItem onGridCreate, onGrid_CreateItem onGridRowCreate, 
            string microName, int microRows, int microCols)
        {
            // Create the child objects
            // This can be optimised by only creating a child the momemnt it is neaded in Child_GridBlockGet
            for (int row1 = 1; row1 <= microRows; row1++)
            {
                Name_ChildRow = GridBlock_zMethods.Name_ChildRow(this, row1);
                onGridRowCreate?.Invoke(this, Child_BlockType);

                for (int col1 = 1; col1 <= microCols; col1++)
                {
                    if (GetChild_GridBlock($"{row1}_{col1}", false) == null)
                    {
                        // The childblock does not exists
                        var grid = new GridBlock_1Micro(this, onGridCreate, microName, col1, row1);
                        _GridBlocksDictionary.Add(grid.Name_Address, grid);
                    }
                }
            }
            Child_Count = microRows * microCols;
        }


        public enGrid_BlockType Child_BlockType { get; }
        public int Child_Count { get; private set; }
        public int Child_Rows { get; }
        public int Child_Cols { get; }
        public enGrid_BlockDisplayType Child_DisplayType { get; set; }
    }
}