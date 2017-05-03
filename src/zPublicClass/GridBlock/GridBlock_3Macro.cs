using System;
using System.Drawing;
using LamedalCore.domain.Enumerals;
using LamedalCore.domain.Events;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.zPublicClass.GridBlock
{
    public sealed class GridBlock_3Macro : GridBlock_0Base, IGridBlock
    {
        private double _stateValueDouble;
        private int _stateValueInt;
        private Color _stateColor;

        /// <summary>Initializes a new instance of the <see cref="GridBlock_1Micro" /> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="onGridRowCreate">The on grid row create.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <param name="subRows">The sub rows.</param>
        /// <param name="subCols">The sub cols.</param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        public GridBlock_3Macro(IGridBlock_Base parent, onGrid_CreateItem onGridCreate, onGrid_CreateItem onGridRowCreate, int row, int col, 
            int subRows = 5, int subCols = 5, int microRows = 5, int microCols = 5) : base(parent, row, col, "mac")
        {
            State_Col = col;
            State_Row = row;            
            State_Setup(Double.NaN, 0, Color.Black);
            State_EditState = enGrid_BlockEditState.Undefined;

            Child_BlockType = enGrid_BlockType.SubBlock;
            Child_DisplayType = enGrid_BlockDisplayType.Name;
            Child_Cols = subCols;
            Child_Rows = subRows;

            onGridCreate?.Invoke(this, enGrid_BlockType.MacroBlock);

            // Create the child objects
            CreateSubGrids(onGridCreate, onGridRowCreate, subRows, subCols, microRows, microCols);
        }

        /// <summary>
        /// Creates the sub grids.
        /// </summary>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="onGridRowCreate">The on grid row create.</param>
        /// <param name="subRows">The sub rows.</param>
        /// <param name="subCols">The sub cols.</param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        public void CreateSubGrids(onGrid_CreateItem onGridCreate, onGrid_CreateItem onGridRowCreate, 
                                int subRows, int subCols,
                                int microRows, int microCols)
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
                        gridSub = new GridBlock_2Sub(this, onGridCreate, onGridRowCreate, row1, col1, microRows: microRows, microCols: microCols);
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