using System;

namespace backend
{
    [Flags]
    public enum DamageType
    {
        None = 0,
        Burn = 1,
        Shock = 1 << 1,
        Cut = 1 << 2,
        LimbLoss = 1 << 3,
        Crush = 1 << 4,
        Poison = 1 << 5,
        Radiation = 1 << 6,
        Suffocation = 1 << 7,
        InstantDeath = 1 << 8
    }
}