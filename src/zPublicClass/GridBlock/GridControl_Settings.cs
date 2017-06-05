using System;
using System.Collections.Generic;
using System.Drawing;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.zPublicClass.GridBlock
{
    public class GridControl_Settings
    {
        // Default values
        private const int constMinMicroSize = 20;
        private const int constMinSubSize = 20;
        private const double constZoomSubGridFactor = 1.5;
        private const double constZoomMacroGridFactor = 1.25;
        private const int constSizeMicroWidth = 32;
        private const int constSizeMicroHeight = 30;
        public const string constGridBlock_Name1Micro = "mic";
        public const string constGridBlock_Name2Sub = "sub";
        public const string constGridBlock_Name3Maco = "macro";
        public const string constGridBlock_Name4Cuboid = "cub";
        
        #region Names
        public string GridBlock_Name1Micro = constGridBlock_Name1Micro;
        public string GridBlock_Name2Sub = constGridBlock_Name2Sub;
        public string GridBlock_Name3Macro= constGridBlock_Name3Maco;
        public string GridBlock_Name4Cuboid = constGridBlock_Name4Cuboid;

        #endregion

        #region Address           
        // Note: Address settings will only have effect on the display of the output
        public enGrid_AddressDefOrder Address_Order = enGrid_AddressDefOrder.RowCol;
        public enGrid_AddressValue Address_Row = enGrid_AddressValue.Numeric;
        public enGrid_AddressValue Address_Col = enGrid_AddressValue.Numeric;
        public string Address_Seperator = ".";
        #endregion

        #region Size
        public int Size_MicroWidth = constSizeMicroWidth;
        public int Size_MicroHeight = constSizeMicroHeight;
        public int Size_SubWidth;
        public int Size_SubHeight;
        public int Size_MacroWidth;
        public int Size_MacroHeight;
        public int Size_CuboidWidth;
        public int Size_CuboidHeight;

        public int Min_MacroSize = constMinMicroSize;
        public int Min_SubSize = constMinSubSize;
        #endregion

        #region Scope
        public int Total_MicroCols = 1;
        public int Total_MicroRows = 1;
        public int Total_SubCols = 1;
        public int Total_SubRows = 1;
        public int Total_MacroCols = 1;
        public int Total_MacroRows = 1;
        #endregion

        #region Visible
        public  bool Visible_MacroGrids = true;
        public  bool Visible_SubGrids = true;
        public  bool Visible_MicroGrids = false;
        public double Visible_SubGridZoomFactor = constZoomSubGridFactor;
        public double Visible_MacroGridZoomFactor = constZoomMacroGridFactor;
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
        private GridControl_Settings()
        {
            // Code convention: When a class has more than one constructor -> make the constuctor private and add static methods 'Setup()' to the class
            // ========================================================================================================================================
        }

        /// <summary>Resets the defaults.</summary>
        public void ResetDefaults()
        {
            Size_MicroWidth = constSizeMicroWidth;
            Size_MicroHeight = constSizeMicroHeight;

            Min_MacroSize = constMinMicroSize;
            Min_SubSize = constMinSubSize;

            Visible_SubGridZoomFactor = constZoomSubGridFactor;
            Visible_MacroGridZoomFactor = constZoomMacroGridFactor;
            Refresh_Calculations();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GridControl_Settings"/> class.
        /// </summary>
        public static GridControl_Settings Setup()
        {
            
            var result = new GridControl_Settings();
            result.Refresh_Calculations();
            return result;
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
        /// <returns></returns>
        public static GridControl_Settings Setup(int macroRows, int macroCols,
            int subRows, int subCols,
            int microRows, int microCols,
            int width = 0, int height = 0)
        {
            return Setup(null, macroRows, macroCols, subRows, subCols, microRows, microCols, width, height);
        }

        /// <summary>
            /// Setup the Grid settings.
            /// </summary>
            /// <param name="settings">The settings.</param>
            /// <param name="macroRows">The macro rows.</param>
            /// <param name="macroCols">The macro cols.</param>
            /// <param name="subRows">The sub rows.</param>
            /// <param name="subCols">The sub cols.</param>
            /// <param name="microRows">The micro rows.</param>
            /// <param name="microCols">The micro cols.</param>
            /// <param name="width">The width.</param>
            /// <param name="height">The height.</param>
            /// <returns></returns>
            public static GridControl_Settings Setup(GridControl_Settings settings, int macroRows, int macroCols,
                                int subRows, int subCols,
                                int microRows, int microCols,
                                int width = 0, int height = 0)
        {
            if (settings == null) settings = Setup();

            settings.Total_MacroRows = macroRows;
            settings.Total_MacroCols = macroCols;
            settings.Total_SubRows = subRows;
            settings.Total_SubCols = subCols;
            settings.Total_MicroRows = microRows;
            settings.Total_MicroCols = microCols;
            if (width != 0) settings.Size_MicroWidth = width;
            if (height != 0) settings.Size_MicroHeight = height;
            settings.Refresh_Calculations();
            return settings;
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

        /// <summary>Address to x and row.</summary>
        /// <param name="address">The address.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The x.</param>
        /// <param name="addressDef">The address definition.</param>
        /// <param name="addressRow">The address row.</param>
        /// <param name="addressCol">The address col.</param>
        public static void Address_2RowCol(string address, out int row, out int col, 
            enGrid_AddressDefOrder addressDef = enGrid_AddressDefOrder.RowCol,
            enGrid_AddressValue addressRow = enGrid_AddressValue.Numeric,
            enGrid_AddressValue addressCol = enGrid_AddressValue.Numeric)
        {
            var _lamed = LamedalCore_.Instance;

            string rowStr, colStr;
            if (addressDef == enGrid_AddressDefOrder.RowCol)  
            {
                // YY_XX
                rowStr = address.zvar_Id("_");
                colStr = address.zvar_Value("_");
            }
            else
            {
                // XX_YY
                colStr = address.zvar_Id("_");
                rowStr = address.zvar_Value("_");
            }

            if (addressRow == enGrid_AddressValue.Numeric)
                 row = rowStr.zTo_Int();
            else row = _lamed.Types.Number.Alfa_2Number(rowStr);

            if (addressCol == enGrid_AddressValue.Numeric)
                 col = colStr.zTo_Int();
            else col = _lamed.Types.Number.Alfa_2Number(colStr);

        }

        /// <summary>Address to x and row.</summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The x.</param>
        /// <param name="seperator">The seperator.</param>
        /// <param name="addressDef">The address definition.</param>
        /// <param name="addressRow">The address row.</param>
        /// <param name="addressCol">The address col.</param>
        /// <returns></returns>
        public static string Address_FromRowCol(int row, int col, string seperator = "_",
            enGrid_AddressDefOrder addressDef = enGrid_AddressDefOrder.RowCol,
            enGrid_AddressValue addressRow = enGrid_AddressValue.Numeric,
            enGrid_AddressValue addressCol = enGrid_AddressValue.Numeric)
        {
            var _lamed = LamedalCore_.Instance;
            string rowStr, colStr;
            if (addressRow == enGrid_AddressValue.Alfa)
                 rowStr = _lamed.Types.Number.Alfa_FromNumber(row);
            else rowStr = row.zTo_Str();

            if (addressCol == enGrid_AddressValue.Alfa)
                 colStr = _lamed.Types.Number.Alfa_FromNumber(col);
            else colStr = col.zTo_Str();

            if (addressDef == enGrid_AddressDefOrder.ColRow)
                return  $"{colStr}{seperator}{rowStr}";
            else return $"{rowStr}{seperator}{colStr}";
        }
    }
}