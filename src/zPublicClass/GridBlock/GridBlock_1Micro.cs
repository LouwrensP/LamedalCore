using System;
using System.Drawing;
using LamedalCore.domain.Enumerals;
using LamedalCore.domain.Events;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.zPublicClass.GridBlock
{
    public sealed class GridBlock_1Micro : GridBlock_0BaseState
    {
        /// <summary>Initializes a new instance of the <see cref="GridBlock_1Micro" /> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="microName"></param>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        public GridBlock_1Micro(IGridBlock_Base parent, onGrid_CreateItem onGridCreate, string microName, int col, int row) : base(parent, row, col, microName)
        {
            onGridCreate?.Invoke(this, enGrid_BlockType.MicroBlock);
        }
    }
}