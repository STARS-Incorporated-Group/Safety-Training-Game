

using System;
using Backend.Hazards;

namespace Backend.Vitals
{
    public class Vitals
    {
        internal const float BurnAmputateThreshold = 80f;
        internal const float BurnHealthyThreshold = 5f;
        internal const float O2UsageRate = 10f;
        internal const float MaxO2 = 500f;
            
        private LimbVitals _leftArm;
        private LimbVitals _rightArm;
        private LimbVitals _leftLeg;
        private LimbVitals _rightLeg;
        private TorsoVitals _torso;
        private HeadVitals _head;
        private float _poison;
        
        public LimbUsabilityLevel LeftLegUsabilityLevel()
        {
            return GetLimbUsabilityLevel(_leftLeg);
        }
        
        public LimbUsabilityLevel RightLegUsabilityLevel() 
        {
            return GetLimbUsabilityLevel(_rightLeg);
        }
        
        public LimbUsabilityLevel LeftArmUsabilityLevel()
        {
            return GetLimbUsabilityLevel(_leftArm);
        }
        
        public LimbUsabilityLevel RightArmUsabilityLevel()
        {
            return GetLimbUsabilityLevel(_rightArm);
        }

        private LimbUsabilityLevel GetLimbUsabilityLevel(LimbVitals limb)
        {
            bool burnHealthy = limb.PercentBurnt < BurnHealthyThreshold;
            bool burnAmputate = limb.PercentBurnt > BurnAmputateThreshold;
            if (burnAmputate)
                return LimbUsabilityLevel.Dead;
            
            bool fractureUsable = limb.FractureLevel < FractureLevel.Transverse;
            bool fractureHandicap = limb.FractureLevel >= FractureLevel.Comminuted;
            if (limb.FractureLevel == FractureLevel.None && burnHealthy)
                return LimbUsabilityLevel.Healthy;
            if (fractureUsable)
                return LimbUsabilityLevel.PainSensitive;
            return LimbUsabilityLevel.Salvageable;
        }

        public bool IsDead()
        {
            return _torso.O2Levels <= 0f || _torso.PercentBurnt > BurnAmputateThreshold || _poison > 100;
        }
        
        public bool IsConcussed()
        {
            return this._head.ConcussionResistance <= 0;
        }
        
        public bool CanWalk()
        {
            return this.LeftLegUsabilityLevel() >= LimbUsabilityLevel.PainSensitive &&
                   this.RightLegUsabilityLevel() >= LimbUsabilityLevel.PainSensitive;
        }
        
        public void UpdateBreathing()
        {
            this._torso.O2Levels += -O2UsageRate + _torso.PercentLungHealth;
            _torso.O2Levels = Math.Min(MaxO2, _torso.O2Levels);
        }

        public float WalkingSpeedRemaining()
        {
            float leftSpeed = (100f - _leftLeg.PercentBurnt) * 0.01f;
            switch (_leftLeg.FractureLevel)
            {
                case FractureLevel.None :
                    break;
                case FractureLevel.Hairline :
                    leftSpeed *= 0.5f;
                    break;
                case FractureLevel.GreenStick :
                    leftSpeed *= 0.2f;
                    break;
                default:
                    leftSpeed = 0;
                    break;
            }
            
            float rightSpeed = (100f - _rightLeg.PercentBurnt) * 0.01f;
            switch (_rightLeg.FractureLevel)
            {
                case FractureLevel.None :
                    break;
                case FractureLevel.Hairline :
                    rightSpeed *= 0.5f;
                    break;
                case FractureLevel.GreenStick :
                    rightSpeed *= 0.2f;
                    break;
                default:
                    rightSpeed = 0;
                    break;
            }
            
            // d = vt -> t = d/v -> use harmonic mean to find total velocity
            return 1f / ((1f / leftSpeed) + (1f / rightSpeed));
        }

        public void ApplyDamage(DamageInfo dmg)
        {
            this._poison += dmg.PoisonDamage;
        }
    }
}