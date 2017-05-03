using System;
using System.Drawing;
using LamedalCore.domain.Enumerals;
using LamedalCore.domain.Events;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.zPublicClass.GridBlock
{
    public sealed class GridBlock_2Sub : GridBlock_0Base, IGridBlock
    {
        private Color _stateColor;
        private double _stateValueDouble;
        private int _stateValueInt;

        /// <summary>Initializes a new instance of the <see cref="GridBlock_1Micro" /> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="onGridRowCreate">The on grid row create.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        public GridBlock_2Sub(IGridBlock_Base parent, onGrid_CreateItem onGridCreate, onGrid_CreateItem onGridRowCreate, int row, int col, int microRows = 5, int microCols = 5) : base(parent, row, col, "sub")
        {
            State_Col = col;
            State_Row = row;
            
            State_Setup(Double.NaN, 0, Color.Black);
            State_EditState = enGrid_BlockEditState.Undefined;

            Child_BlockType = enGrid_BlockType.MicroBlock;
            Child_DisplayType = enGrid_BlockDisplayType.Name;
            Child_Cols = microCols;
            Child_Rows = microRows;

            onGridCreate?.Invoke(this, enGrid_BlockType.SubBlock);

            CreateMicroGrids(onGridCreate, onGridRowCreate, microRows, microCols);
        }

        /// <summary>
        /// Creates the micro grids.
        /// </summary>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="onGridRowCreate">The on grid row create.</param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        public void CreateMicroGrids(onGrid_CreateItem onGridCreate, onGrid_CreateItem onGridRowCreate, int microRows, int microCols)
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
                        var grid = new GridBlock_1Micro(this, onGridCreate, col1, row1);
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

        #region state properties
        public int State_Col { get; }

        public enGrid_BlockEditState State_EditState { get; set; }
        public bool State_Selected { get; set; }
        public int State_Row { get; }

        public Color State_Color
        {
            get { return _stateColor; }
            set
            {
                _stateColor = value;
                State_EditState = enGrid_BlockEditState.Changed;
            }
        }
        public double State_ValueDouble
        {
            get { return _stateValueDouble; }
            set
            {
                _stateValueDouble = value;
                State_EditState = enGrid_BlockEditState.Changed;
            }
        }
        public int State_Id
        {
            get { return _stateValueInt; }
            set
            {
                _stateValueInt = value;
                State_EditState = enGrid_BlockEditState.Changed;
            }
        }
        #endregion

    }
}