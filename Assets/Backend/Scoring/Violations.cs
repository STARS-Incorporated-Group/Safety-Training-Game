using UnityEngine.InputSystem.LowLevel;

namespace Backend.Scoring
{
    public enum Violations
    {
        NoPpe = ViolationSeverityLevels.Moderate,
        FaultyPpe = ViolationSeverityLevels.Minor,
        
        IgnoredHazard = ViolationSeverityLevels.Minor,
        AteOrDrankInLab = ViolationSeverityLevels.Moderate,
        LeftTrippingHazard = ViolationSeverityLevels.Moderate, 
        
        CreatedFumes = ViolationSeverityLevels.Moderate,
        CreatedLethalFumes = ViolationSeverityLevels.Major,
        
        FailedToDisposeWaste = ViolationSeverityLevels.Moderate,
        MixingChemicals = ViolationSeverityLevels.Moderate,
        RecycledUsedChemicals = ViolationSeverityLevels.Fired,
        
        CausedSmallExplosion = ViolationSeverityLevels.Major,
        CausedBigExplosion = ViolationSeverityLevels.Fired,
        
        StartedSmallFire = ViolationSeverityLevels.Major,
        StartedBigFire = ViolationSeverityLevels.Fired,
        IneffectiveFireExtinguishing = ViolationSeverityLevels.Minor,
        HazardousFireExtinguishing = ViolationSeverityLevels.Major,
        
        MinorInjury = ViolationSeverityLevels.Moderate,
        MinorDamage = ViolationSeverityLevels.Moderate,
        
        MajorInjury = ViolationSeverityLevels.Major,
        MajorDamage = ViolationSeverityLevels.Fired,
        
        Murder = ViolationSeverityLevels.Fired,
        Death = ViolationSeverityLevels.InstantLose,
        Concussion = ViolationSeverityLevels.InstantLose
    }
}