using System;
using System.Drawing;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zPublicClass.GridBlock.GridInterface
{
    public interface IGridBlock_State
    {
        /// <summary>Gets or sets the address col.</summary>
        int State_Col { get; }

        /// <summary>Gets or sets the address row.</summary>
        int State_Row { get; }

        /// <summary>Gets or sets the value.</summary>
        double State_ValueDouble { get; set; }

        /// <summary>Gets or sets the index of the state.</summary>
        int State_Index { get; set; }

        /// <summary>Gets or sets the state enum value. This can be used for store different states that can be uses for colours of the grids.</summary>
        int State_EnumValue { get; set; }
        Type State_Enum { get; set; }
        /// <summary>Gets or sets the DB Id value. This can be used to link the grids to a database.</summary>
        int State_DbId { get; set; }

        /// <summary>Gets or sets the DB name value. This can be used to search for values.</summary>
        string State_DbName { get; set; }

        /// <summary>Gets or sets the color of the block.</summary>
        Color State_Color { get; set; }

        enGrid_BlockEditState State_EditState { get; set; }

        /// <summary>Gets or sets a value indicating whether [state selected].</summary>
        bool State_Selected { get; set; }

        /// <summary>Gets or sets the progress state. Value is between 0 and 100.</summary>
        int State_Progress { get; set; }
    }
}