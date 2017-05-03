using System.Collections.Generic;
using System.Drawing;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.zPublicClass.GridBlock
{
    public class GridControl_Settings
    {
        #region Size

        public int Size_MicroWidth = 32;
        public  int Size_MicroHeight = 30;
        public  int Size_SubWidth;
        public  int Size_SubHeight;
        public  int Size_MacroWidth;
        public  int Size_MacroHeight;
        public  int Size_CuboidWidth;
        public  int Size_CuboidHeight;

        public int Min_MacroSize = 100;
        public int Min_SubSize = 70;

        #endregion

        #region Scope
        public int Total_MicroCols = 5;
        public int Total_MicroRows = 5;
        public int Total_SubCols = 2;
        public int Total_SubRows = 2;
        public int Total_MacroCols = 2;
        public int Total_MacroRows = 2;
        #endregion

        #region Visible
        public  bool Visible_MacroGrids = true;
        public  bool Visible_SubGrids = true;
        public  bool Visible_MicroGrids = false;
        public double Visible_SubGridZoomFactor = 1.5;
        public double Visible_MacroGridZoomFactor = 1.25;
        #endregion

        #region Color
        // Default colors are only set during creation
        public  Color ColorDefault_CuboidGrid = Color.Lavender;
        public  Color ColorDefault_MacroGrid = Color.Lavender;
        public  Color ColorDefault_SubGrid = Color.Silver;
        public  Color ColorDefault_MicroGrid = Color.Silver;
        public  Dictionary<int, Color> Color_ID = new Dictionary<int, Color>();   // Set colors for id's
        #endregion

        #region Show mode
        public  enGrid_BlockDisplayType DisplayMode_MacroGrids = enGrid_BlockDisplayType.Address;
        public  enGrid_BlockDisplayType DisplayMode_SubGrids = enGrid_BlockDisplayType.Address;
        public  enGrid_BlockDisplayType DisplayMode_MicroGrids = enGrid_BlockDisplayType.Address;

        // Edit mode
        public  enGrid_BlockEditMode Edit_Mode = enGrid_BlockEditMode.Click;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GridControl_Settings"/> class.
        /// </summary>
        public GridControl_Settings()
        {
            Refresh_Calculations();
        }

        /// <summary>Return new Grid control settings.</summary>
        /// <param name="macroRows">The macro rows.</param>
        /// <param name="macroCols">The macro cols.</param>
        /// <param name="subRows">The sub rows.</param>
        /// <param name="subCols">The sub cols.</param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public GridControl_Settings(int macroRows, int macroCols,
                                int subRows, int subCols,
                                int microRows, int microCols,
                                int width = 0, int height = 0)
        {
            this.Setup(macroRows, macroCols, subRows, subCols, microRows, microCols, width, height);
            Refresh_Calculations();
        }

        /// <summary>Setup the Grid settings.</summary>
        /// <param name="macroRows">The macro rows.</param>
        /// <param name="macroCols">The macro cols.</param>
        /// <param name="subRows">The sub rows.</param>
        /// <param name="subCols">The sub cols.</param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void Setup(int macroRows, int macroCols,
                                int subRows, int subCols,
                                int microRows, int microCols,
                                int width = 0, int height = 0)
        {
            Total_MacroRows = macroRows;
            Total_MacroCols = macroCols;
            Total_SubRows = subRows;
            Total_SubCols = subCols;
            Total_MicroRows = microRows;
            Total_MicroCols = microCols;
            if (width != 0) Size_MicroWidth = width;
            if (height != 0) Size_MicroHeight = height;
            Refresh_Calculations();
        }


        /// <summary>Recalculate the sizes.</summary>
        public virtual void Refresh_Calculations()
        {
            // Micro
            var microCols = (Total_MicroCols == 0) ? 1 : Total_MicroCols;
            var microRows = (Total_MicroRows == 0) ? 1 : Total_MicroRows;

            // Sub
            Size_SubWidth = Size_MicroWidth * microCols + 10;
            Size_SubHeight = Size_MicroHeight * microRows + 20;
            if (Visible_MicroGrids == false && Visible_SubGridZoomFactor != 0.0)
            {
                Size_SubWidth = (int)(Size_SubWidth / Visible_SubGridZoomFactor);
                Size_SubHeight = (int)(Size_SubHeight / Visible_SubGridZoomFactor);
            }
            if (Size_SubWidth < Min_SubSize) Size_SubWidth = Min_SubSize;
            if (Size_SubHeight < Min_SubSize) Size_SubHeight = Min_SubSize;

            // Macro
            var subCols = (Total_SubCols == 0) ? 1 : Total_SubCols;
            var subRows = (Total_SubRows == 0) ? 1 : Total_SubRows;
            Size_MacroWidth = Size_SubWidth * subCols + 10;
            Size_MacroHeight = Size_SubHeight * subRows + 20;
            if (Visible_SubGrids == false && Visible_MacroGridZoomFactor != 0)
            {
                Size_MacroWidth = (int)(Size_MacroWidth / Visible_MacroGridZoomFactor);
                Size_MacroHeight = (int)(Size_MacroHeight / Visible_MacroGridZoomFactor);
            }
            if (Size_MacroWidth < Min_MacroSize) Size_MacroWidth = Min_MacroSize;
            if (Size_MacroHeight < Min_MacroSize) Size_MacroHeight = Min_MacroSize;

            // Cuboid
            Size_CuboidWidth = Size_MacroWidth * Total_MacroCols + 10;
            Size_CuboidHeight = Size_MacroHeight * Total_MacroRows + 20;
        }

        /// <summary>Address to x and y.</summary>
        /// <param name="address">The address.</param>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        public static void Address_ToXY(string address, out int y, out int x)
        {
            var yStr = address.zvar_Id("_");   // Addresses must be name friendly
            var xStr = address.zvar_Value("_");
            y = yStr.zTo_Int();
            x = xStr.zTo_Int();
        }

    }
}