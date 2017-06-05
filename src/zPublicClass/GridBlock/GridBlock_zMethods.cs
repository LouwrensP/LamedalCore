using System;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.zPublicClass.GridBlock
{
    public static class GridBlock_zMethods
    {
        public static string GridPrefix(IGridBlock_Base grid, GridControl_Settings settings)
        {
            string prefix = "";
            if (grid is GridBlock_1Micro) prefix = settings.GridBlock_Name1Micro;
            else if (grid is GridBlock_2Sub) prefix = settings.GridBlock_Name2Sub;
            else if (grid is GridBlock_3Macro) prefix = settings.GridBlock_Name3Macro;
            else if (grid is GridBlock_4Cuboid) prefix = settings.GridBlock_Name4Cuboid;
            else throw new ArgumentException($"Error! '{nameof(grid)}' is not a defined type.");
            return prefix;
        }

        /// <summary>Calculates the grid frontend name.</summary>
        /// <param name="grid">The grid.</param>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        public static string Name_Frontend(IGridBlock_Base grid, int col, int row, GridControl_Settings settings)
        {
            var parentRow = grid.Name_ParentRow;   // + "/";
            string prefix = GridPrefix(grid, settings);
            return  parentRow + prefix + $"{row}_{col}";
        }

        /// <summary>Calculate the current row name for the frontend.</summary>
        /// <param name="grid">The grid.</param>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        public static string Name_ParentRow(IGridBlock_Base grid, int row)
        {
            string name = "";
            if (grid._Parent != null) name = grid._Parent.Name_Control;
            //if (name != "") name += "/";
            return name + "R" + row;
        }

        /// <summary>Calculates the front-ends child row.</summary>
        /// <param name="gridBlock">The grid block.</param>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        public static string Name_ChildRow(IGridBlock_Base gridBlock, int row)
        {
            return gridBlock.Name_Control + "R" + row;
        }
    }
}
