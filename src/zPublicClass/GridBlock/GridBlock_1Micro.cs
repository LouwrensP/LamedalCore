using System;
using System.Drawing;
using LamedalCore.domain.Enumerals;
using LamedalCore.domain.Events;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.zPublicClass.GridBlock
{
    public sealed class GridBlock_1Micro : GridBlock_0Base, IGridBlock_State
    {
        private Color _stateColor;
        private double _stateValueDouble;
        private int _stateValueInt;

        /// <summary>Initializes a new instance of the <see cref="GridBlock_1Micro" /> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        public GridBlock_1Micro(IGridBlock parent, onGrid_CreateItem onGridCreate, int col, int row) : base(parent, row, col, "mic")
        {

            State_Col = col;
            State_Row = row;
            State_Setup(Double.NaN, 0, Color.Black);
            State_EditState = enGrid_BlockEditState.Undefined;

            onGridCreate?.Invoke(this, enGrid_BlockType.MicroBlock);
        }

        
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