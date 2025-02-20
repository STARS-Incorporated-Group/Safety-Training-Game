using System;

namespace Backend.Scoring
{
    [Flags]
    public enum RewardLevels: int
    {
        ResolveSmallHazard = 50,
        ResolveDeadlyHazard = 250,
        ResolveDisaster = 500,
        ResolveLevel = 2000
    }
}