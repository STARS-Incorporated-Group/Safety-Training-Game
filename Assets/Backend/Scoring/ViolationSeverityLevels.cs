using System;
namespace Backend.Scoring
{
    [Flags]
    public enum ViolationSeverityLevels: int
    {
        Minor = 250,                // technically a violation but nothing happened as a result
        Moderate = 1000,            // minor injury or property damage, or hazard got slightly worse
        Major = 2500,               // major injury, property damage, or hazard got significantly worse
        Fired = 8000,               // a new major hazard was created from something that the user interacted with
        InstantLose = 65535         // user died
    }
}