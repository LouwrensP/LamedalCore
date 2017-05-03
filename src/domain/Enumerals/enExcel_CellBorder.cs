using System;
using System.Runtime.Serialization;

namespace LamedalCore.domain.Enumerals
{
    [DataContract]
    [Flags]
    public enum enExcel_CellBorder
    {
        None = 0,
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8,
        All = 15
    }
}