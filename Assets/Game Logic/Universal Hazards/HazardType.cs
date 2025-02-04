using System;

namespace backend
{
    [Flags]
    public enum HazardType
    {
        None              = 0b00000,
        Fire              = 0b00001,
        ChemicalLiquid    = 0b00010,
        Gas               = 0b00100,
        Cut               = 0b01000,
        Biohazard         = 0b10000,
    }
}