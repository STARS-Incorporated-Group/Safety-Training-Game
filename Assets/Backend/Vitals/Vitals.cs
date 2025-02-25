namespace Backend.Vitals
{
    public class Vitals
    {
        private LimbVitals _leftArm;
        private LimbVitals _rightArm;
        private LimbVitals _leftLeg;
        private LimbVitals _rightLeg;
        private TorsoVitals _torso;
        private HeadVitals _head;
        
        public LimbUsabilityLevel LeftLegUsabilityLevel() {
            return LimbUsabilityLevel.Healthy;
        }
        
        public LimbUsabilityLevel RightLegUsabilityLevel() {
            return LimbUsabilityLevel.Healthy;
        }
        
        public LimbUsabilityLevel LeftArmUsabilityLevel() {
            return LimbUsabilityLevel.Healthy;
        }
        
        public LimbUsabilityLevel RightArmUsabilityLevel() {
            return LimbUsabilityLevel.Healthy;
        }

        public bool IsDead()
        {
            return true;
        }
        
        public bool IsConcussed()
        {
            return true;
        }
        
        public bool CanWalk()
        {
            return true;
        }

        public float WalkingSpeedRemaining()
        {
            return 1;
        }
    }
}