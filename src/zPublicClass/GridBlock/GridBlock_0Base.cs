using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        public GridControl_Settings Settings;
        private int _row, _col;
        public IGridBlock_Base _Parent { get; }
        public string Name_Control { get; }
        public string Name_ParentRow { get; }
        public string Name_ChildRow { get; protected set;}

        /// <summary>Initializes a new instance of the <see cref="GridBlock_0Base" /> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <param name="settings">The settings.</param>
        public GridBlock_0Base(IGridBlock_Base parent, int row, int col, GridControl_Settings settings)
        {
            Settings = settings;
            Name_Address = $"{row}_{col}";
            _row = row;
            _col = col;

            _Parent = parent;
            Name_ChildRow = "";
            Name_ParentRow = GridBlock_zMethods.Name_ParentRow(this, row);
            Name_Control = GridBlock_zMethods.Name_Frontend(this, col, row, Settings);
        }

        public string Name_Caption(GridControl_Settings settings)
        {
            if (settings == null) return GridControl_Settings.Address_FromRowCol(_row, _col, ".");
            return GridControl_Settings.Address_FromRowCol(_row, _col,settings.Address_Seperator, settings.Address_Order,settings.Address_Row, settings.Address_Col);
        }

        public string Name_Address { get; }
        public IGridControl zGridControl { get; set; }

        /// <summary>
        /// The grid blocks dictionary of child grids
        /// </summary>
        protected readonly Dictionary<string, IGridBlock_Base> _GridBlocksDictionary = new Dictionary<string, IGridBlock_Base>();

        public Dictionary<string, IGridBlock_Base> GridBlocksDictionary { get { return _GridBlocksDictionary; } }

        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        public object zTag { get; set; }



        /// <summary>
        /// Return the child grid blocks.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public List<IGridBlock_Base> GetChild_GridBlocks()
        {
            return _GridBlocksDictionary.Values.ToList();
        }

        /// <summary>Return the child grid blocks.</summary>
        /// <param name="searchValue">The macro address or search value.</param>
        /// <param name="searchItem">The search item.</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public IGridBlock_Base GetChild_GridBlock(string searchValue, enGrid_BlockDisplayType searchItem = enGrid_BlockDisplayType.Address, bool showError = true)
        {
            IGridBlock_Base grid = null;
            if (searchItem == enGrid_BlockDisplayType.Address)
            {
                if (_GridBlocksDictionary.TryGetValue(searchValue, out grid) == false)
                {
                    string dimensions = "";
                    string block = "";
                    var parent = this as IGridBlock_ChildState;
                    if (parent != null)
                    {
                        block = parent.Child_BlockType.ToString();
                        dimensions = $"Dimensions: {block} : {parent.Child_Cols}x{parent.Child_Rows}";
                    }
                    if (showError) throw new ArgumentException($"Error! Unable to find {block} address: '{searchValue.Replace("_", ".")}'!".NL() + dimensions);
                }
            }
            else
            {
                IList<IGridBlock_State> grids = _lamed.Types.List.Convert.IList_2IListT<IGridBlock_State>(_GridBlocksDictionary.Values.ToList());
                IEnumerable<IGridBlock_State> gridsFound = null;
                int searchId = searchValue.zTo_Int();
                double searchDouble = searchValue.zObject().AsDouble();
                switch (searchItem)
                {
                    case enGrid_BlockDisplayType.DB_Name: gridsFound = grids.Where(x => x.State_DbName == searchValue); break;
                    case enGrid_BlockDisplayType.DB_ID: gridsFound = grids.Where(x => x.State_DbId == searchId); break;
                    case enGrid_BlockDisplayType.Index: gridsFound = grids.Where(x => x.State_Index == searchId); break;
                    case enGrid_BlockDisplayType.StateID: gridsFound = grids.Where(x => x.State_Id == searchId); break;
                    case enGrid_BlockDisplayType.Value: gridsFound = grids.Where(x => x.State_ValueDouble == searchDouble); break;
                    default: throw new ArgumentException("Error! Search item not implemented yet!", nameof(searchItem));
                }
                grid = gridsFound.First() as IGridBlock_Base;
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
