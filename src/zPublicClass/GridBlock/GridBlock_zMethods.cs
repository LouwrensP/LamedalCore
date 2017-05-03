using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace LamedalCore.zPublicClass.GridBlock
{
    public static class GridBlock_zMethods
    {

        /// <summary>Calculates the grid frontend name.</summary>
        /// <param name="grid">The grid.</param>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        /// <param name="gridTypeName">Name of the grid type.</param>
        /// <returns></returns>
        public static string Name_Frontend(IGridBlock_Base grid, int col, int row, string gridTypeName)
        {
            var parentRow = grid.Name_ParentRow;   // + "/";
            return  parentRow + gridTypeName + $"{row}_{col}";
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
