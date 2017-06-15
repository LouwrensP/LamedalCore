using System;

namespace LamedalCore.domain.Enumerals
{
    [Flags]
    public enum enCode_MethodKind
    {
        IsProperty = 1, 
        IsSetter = 2,  // Setter also implies a property
        IsConstructor = 4,         
        IsVoid = 8,
        IsFunction = 16,
    }
}