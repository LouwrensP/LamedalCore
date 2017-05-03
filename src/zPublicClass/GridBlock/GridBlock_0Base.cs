using System;
using System.Collections.Generic;
using System.Drawing;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.GridBlock.GridInterface;
using LamedalCore.zz;

namespace LamedalCore.zPublicClass.GridBlock
{
    /// <summary>
    /// The base class implements an interface to allow it to be used across platform boundaries. 
    /// </summary>
    /// <seealso cref="IGridBlock_Base" />
    public class GridBlock_0Base : IGridBlock_Base
    {
        public IGridBlock_Base _Parent { get; }
        public string Name_Control { get; }
        public string Name_ParentRow { get; }
        public string Name_ChildRow { get; protected set;}
        public string Name_Caption { get; }
        public string Name_Address { get; }
        public IGridControl zGridControl { get; set; }

        /// <summary>
        /// The grid blocks dictionary of child grids
        /// </summary>
        protected readonly Dictionary<string, IGridBlock_Base> _GridBlocksDictionary = new Dictionary<string, IGridBlock_Base>();
        public Dictionary<string, IGridBlock_Base> GridBlocksDictionary { get { return _GridBlocksDictionary; } }

        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        public object zTag { get; set; }

        /// <summary>Initializes a new instance of the <see cref="GridBlock_0Base"/> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <param name="gridTypeName">Name of the grid type.</param>
        public GridBlock_0Base(IGridBlock_Base parent, int row, int col, string gridTypeName)
        {
            Name_Address = $"{row}_{col}";
            if (gridTypeName == "mic")
                 Name_Caption = $"{row}.{col}";
            else Name_Caption = gridTypeName + $"{row}.{col}";  // Show grid type in caption except for micro grids

            _Parent = parent;
            Name_ChildRow = "";
            Name_ParentRow = GridBlock_zMethods.Name_ParentRow(this, row);
            Name_Control = GridBlock_zMethods.Name_Frontend(this, col, row, gridTypeName);
        }

        /// <summary>
        /// Return the child grid blocks.
        /// </summary>
        /// <param name="address">The macro address.</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public IGridBlock_Base GetChild_GridBlock(string address, bool showError = true)
        {
            IGridBlock_Base grid = null;
            if (_GridBlocksDictionary.TryGetValue(address, out grid) == false)
            {
                string dimensions = "";
                string block = "";
                var parent = this as IGridBlock_ChildState;
                if (parent != null)
                {
                    block = parent.Child_BlockType.ToString();
                    dimensions = $"Dimensions: {block} : {parent.Child_Cols}x{parent.Child_Rows}";
                }
                if (showError) throw new ArgumentException($"Error! Unable to find {block} address: '{address.Replace("_",".")}'!".NL() + dimensions);
            }
            return grid;
        }

        /// <summary>Set the state information.</summary>
        /// <param name="dValue">The d value.</param>
        /// <param name="iValue">The i value.</param>
        /// <param name="color">The color.</param>
        public void State_Setup(double dValue, int iValue, Color color)
        {
            var state = this as IGridBlock_State;
            if (state == null) return;

            state.State_ValueDouble = dValue;
            state.State_Id = iValue;
            state.State_Color = color;
            state.State_EditState = enGrid_BlockEditState.ValueSet;
        }

        /// <summary>Set the state information.</summary>
        /// <param name="dValue">The d value.</param>
        /// <param name="iValue">The i value.</param>
        public void State_Setup(double dValue, int iValue = 0)
        {
            State_Setup(dValue, iValue, Color.Black);
        }
    }
}
