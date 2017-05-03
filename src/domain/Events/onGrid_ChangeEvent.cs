using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.domain.Events
{
    /// <summary>
    /// This event fire when the setting (like color, widht, height etc) of a grid element is updated. 
    /// </summary>
    /// <param name="gridControl">The grid control.</param>
    /// <param name="changeType">Type of the change.</param>
    public delegate void onGrid_ChangeEvent(IGridControl gridControl, enGrid_ChangeType changeType);
}