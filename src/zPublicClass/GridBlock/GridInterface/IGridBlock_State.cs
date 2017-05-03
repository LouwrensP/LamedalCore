using System.Drawing;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zPublicClass.GridBlock.GridInterface
{
    public interface IGridBlock_State
    {
        /// <summary>Gets or sets the address col.</summary>
        /// <value>The address col.</value>
        int State_Col { get; }

        /// <summary>Gets or sets the address row.</summary>
        /// <value>The address row.</value>
        int State_Row { get; }

        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        double State_ValueDouble { get; set; }

        /// <summary>Gets or sets the int value. This can be used for store different states.</summary>
        /// <value>The state_ value int.</value>
        int State_Id { get; set; }

        /// <summary>Gets or sets the state of the block.</summary>
        /// <value>The state of the block.</value>
        Color State_Color { get; set; }

        enGrid_BlockEditState State_EditState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [state selected].
        /// </summary>
        bool State_Selected { get; set; }

    }
}