namespace Backend.Vitals
{
    public enum LimbUsabilityLevel
    {
        Healthy = 3,            // perfectly fine
        PainSensitive = 2,      // usable but causes pain
        Salvageable = 1,        // salvageable from medical attention
        Dead = 0,               // must be amputated
    }
}