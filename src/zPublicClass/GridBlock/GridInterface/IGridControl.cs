
using System.Drawing;

namespace LamedalCore.zPublicClass.GridBlock.GridInterface
{
    /// <summary>
    /// Define a simple way to set controls. This interface is not platform specific and define the base class elements for controls.
    /// </summary>
    public interface IGridControl
    {
        Color BackColor { get; set; }
        string Name { get; set; }
        int Left { get; set; }
        int Top { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        string Text { get; set; }
        /// <summary>Provide a hookup to the backend object information.</summary>
        IGridBlock_Base GridState { get; set; }
        void SuspendLayout();

        void BringToFront();

        void SendToBack();

        bool Visible { get; set; }
        void ResumeLayout(bool performLayout);

        IGridControl _Parent { get; }

    }
}