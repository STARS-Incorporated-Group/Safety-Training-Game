using System;

namespace backend
{
    [Flags]
    public enum FireClass
    {
        None       = 0b000000,
        ClassA     = 0b000001,
        ClassB     = 0b000010,
        ClassC     = 0b000100,
        ClassD     = 0b001000,
        Electrical = 0b010000,
        ClassF     = 0b100000
    }
}