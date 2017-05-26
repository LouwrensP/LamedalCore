using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using LamedalCore.domain.Enumerals;
using LamedalCore.domain.Events;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.zPublicClass.GridBlock
{
    public class GridBlock_0BaseState : GridBlock_0Base, IGridBlock_State
    {
        private Color _stateColor;
        private double _stateValueDouble;
        private int _stateValueInt;

        /// <summary>Initializes a new instance of the <see cref="GridBlock_1Micro" /> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="index">The index.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <param name="settings">The settings.</param>
        public GridBlock_0BaseState(IGridBlock_Base parent, int index, int row, int col, GridControl_Settings settings) : base(parent, row, col, settings)
        {
            State_Index = index;
            State_Col = col;
            State_Row = row;
            State_Setup(Double.NaN, 0, Color.Black);
            State_EditState = enGrid_BlockEditState.Undefined;
        }

        public int State_Col { get; }
        public int State_Row { get; }
        public enGrid_BlockEditState State_EditState { get; set; }
        public bool State_Selected { get; set; }
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
        public int State_Index { get; set; }
        public int State_Id
        {
            get { return _stateValueInt; }
            set
            {
                _stateValueInt = value;
                State_EditState = enGrid_BlockEditState.Changed;
            }
        }
        public int State_DbId { get; set; }
        public string State_DbName { get; set; }
    }
}
