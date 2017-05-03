using System;
using System.Collections.Generic;
using System.Linq;
using LamedalCore.domain.Enumerals;
using LamedalCore.domain.Events;
using LamedalCore.zPublicClass.GridBlock.GridInterface;
using LamedalCore.zz;

namespace LamedalCore.zPublicClass.GridBlock
{
    public sealed class GridBlock_5Setup   // Parent need to be of type IGridblock_Base
    {
        private readonly Dictionary<string, IGridControl> _treeControls = new Dictionary<string, IGridControl>();
        private readonly onGrid_CreateControl _onCreateGridControl;
        private readonly Dictionary<string, object> _treeDebugInfo = new Dictionary<string,object>();  // Save debug and testing information
        public GridBlock_4Cuboid GridCuboid { get; }

        /// <summary>Initializes a new instance of the <see cref="GridBlock_5Setup" /> class.</summary>
        /// <param name="onCreateGrid">The on create grid.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="rowName">Name of the row.</param>
        public GridBlock_5Setup(onGrid_CreateControl onCreateGrid, GridControl_Settings settings, string rowName = "R1")
        {
            if (onCreateGrid != null)
            {
                _onCreateGridControl -= onCreateGrid;
                _onCreateGridControl += onCreateGrid;
            }

            _treeControls.Clear();
            var root = new object() as IGridBlock_Base;
            IGridControl gridRowControl = new object() as IGridControl; // Client need to create this
            if (_onCreateGridControl != null)
            {
                _onCreateGridControl(root, enGrid_ControlType.Row, "?", rowName, enGrid_BlockType.CuboidGrid, ref gridRowControl); // Ask frontend to create the control
                // Save testing information
                _treeDebugInfo.Add(GridControl_2Str(enGrid_ControlType.Row, "?", rowName, enGrid_BlockType.CuboidGrid),null);

            }

            _treeControls.Add(rowName, gridRowControl);

            GridCuboid = new GridBlock_4Cuboid(root, OnGridCreate, OnGridRowCreate, settings.Total_MacroRows, settings.Total_MacroCols,
                                settings.Total_SubRows, settings.Total_SubCols, settings.Total_MicroRows, settings.Total_MicroCols);

            //r1
            //r1/cub1_1
            //r1/cub1_1/r1
            //r1/cub1_1/r1/mac1_1
            //r1/cub1_1/r1/mac1_1/r1
            //r1/cub1_1/r1/mac1_1/r1/sub1_1
            //r1/cub1_1/r1/mac1_1/r1/sub1_1/r1
            //r1/cub1_1/r1/mac1_1/r1/sub1_1/r1/mic1_1

        }

        public static string GridControl_2Str(enGrid_ControlType gridcontroltype, string parentname, string childname, enGrid_BlockType blocktype)
        {
            var type = gridcontroltype.ToString();
            return type + "//" + parentname + "//" + childname + "//" + blocktype;
        }

        /// <summary>return list of keys. This can be used for testing</summary>
        /// <returns></returns>
        public List<string> TreeNameList()
        {
            return _treeControls.Keys.ToList();
        }

        /// <summary>return list of controls that represent the grid structure. This can be used for testing</summary>
        /// <returns></returns>
        public List<string> TreeControlList()
        {
            return _treeDebugInfo.Keys.ToList();
        }

        private void OnGridCreate(IGridBlock_Base sender, enGrid_BlockType blockType)
        {
            var gridName = sender.Name_Control;
            var gridRow = sender.Name_ParentRow;
            IGridControl gridControl = new object() as IGridControl;  // Create dummy control
            if (_onCreateGridControl != null) _onCreateGridControl(sender, enGrid_ControlType.Grid, gridRow, gridName, blockType, ref gridControl);  // Ask frontend to create the control
            sender.zGridControl = gridControl;

            // Save tree for quick references
            _treeControls.zDictionary_AddSafe(gridName, gridControl);
            
            // Save testing information
            _treeDebugInfo.zDictionary_AddSafe(GridControl_2Str(enGrid_ControlType.Grid, gridRow, gridName, blockType),null);
        }


        private void OnGridRowCreate(IGridBlock_Base sender, enGrid_BlockType blockType)
        {
            var parentGrid = sender.Name_Control;
            var rowName = sender.Name_ChildRow;
            IGridControl gridRowControl = new object() as IGridControl;  // Create dummy control
            if (_onCreateGridControl != null) _onCreateGridControl(sender, enGrid_ControlType.Row, parentGrid, rowName, blockType, ref gridRowControl);  // Ask frontend to create the control
            //sender.zGridControl = gridRowControl;    // We do not want to save the row. We can get it through the parent property. We already have the grid
            _treeControls.zDictionary_AddSafe(rowName, gridRowControl);
            
            // Save testing information
            _treeDebugInfo.zDictionary_AddSafe(GridControl_2Str(enGrid_ControlType.Row, parentGrid, rowName, blockType),null);
        }

        /// <summary>Return the child grid blocks.</summary>
        /// <param name="macroAddress">The macro address.</param>
        /// <param name="subAddress">The sub address.</param>
        /// <param name="microAddress">The micro address.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public IGridBlock_Base GetChild_MicroGridBlock(string macroAddress, string subAddress, string microAddress)
        {
            var gridSub = GetChild_SubGridBlock(macroAddress, subAddress) as IGridBlock_Base;
            var gridMicroI = gridSub.GetChild_GridBlock(microAddress);
            return gridMicroI;
        }

        /// <summary>Return the child grid blocks.</summary>
        /// <param name="macroAddress">The macro address.</param>
        /// <param name="subAddress">The sub address.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public IGridBlock_Base GetChild_SubGridBlock(string macroAddress, string subAddress)
        {
            var gridMacro = GetChild_MacroGridBlock(macroAddress);
            var gridSubI = gridMacro.GetChild_GridBlock(subAddress);
            return gridSubI;
        }

        /// <summary>Return the child grid blocks.</summary>
        /// <param name="macroAddress">The macro address.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public IGridBlock_Base GetChild_MacroGridBlock(string macroAddress)
        {
            var gridMacro = GridCuboid.GetChild_GridBlock(macroAddress);
            return gridMacro;
        }

        /// <summary>
        /// Setups the sub grids.
        /// </summary>
        /// <param name="macroAddress">The macro address.</param>
        /// <param name="subRows">The sub rows.</param>
        /// <param name="subCols">The sub cols.</param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        public void Setup_SubGrids(string macroAddress, int subRows, int subCols, int microRows, int microCols)
        {
            IGridBlock_Base grid = GetChild_MacroGridBlock(macroAddress);
            var gridMacro = grid as GridBlock_3Macro;
            if (gridMacro == null) throw new InvalidOperationException("Error! Macro grid was not found.");
            gridMacro.CreateSubGrids(OnGridCreate, OnGridRowCreate, subRows, subCols, microRows, microCols);
        }

        /// <summary>
        /// Setups the sub grids.
        /// </summary>
        /// <param name="macroAddress">The macro address.</param>
        /// <param name="subAddress">The sub address.</param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        /// <exception cref="InvalidOperationException">Error! Macro grid was not found.</exception>
        public void Setup_MicroGrids(string macroAddress, string subAddress, int microRows, int microCols)
        {
            IGridBlock_Base grid = GetChild_SubGridBlock(macroAddress, subAddress);
            var gridMicro = grid as GridBlock_2Sub;
            if (gridMicro == null) throw new InvalidOperationException("Error! Macro grid was not found.");
            gridMicro.CreateMicroGrids(OnGridCreate, OnGridRowCreate, microRows, microCols);
        }

        public void CreateNewChildGrids(IGridControl grid, onGrid_CreateControl onCreateGridControl, int rows, int cols)
        {
            var gridState = grid.GridState;
            var gridMacro = gridState as GridBlock_3Macro;
            if (gridMacro != null)
            {
                gridMacro.CreateSubGrids(OnGridCreate, OnGridRowCreate,rows, cols, 0, 0);
            }

            var gridsub = gridState as GridBlock_2Sub;
            if (gridsub != null)
            {
                gridsub.CreateMicroGrids(OnGridCreate, OnGridRowCreate, rows, cols);
            }
        }
    }
}