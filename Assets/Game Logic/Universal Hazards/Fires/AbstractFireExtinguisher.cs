using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace backend
{
    public abstract class AbstractFireExtinguisher : AbstractRemedy
    {
        public readonly float capacity;
        public float rate { get; protected set; }
        public float fullness { get; set; }
        
        protected override HazardType affectedHazardTypes => HazardType.Fire | HazardType.ChemicalLiquid | HazardType.Cut | HazardType.Biohazard; 
        protected override HazardType remediedHazardTypes => HazardType.Fire; 
        protected virtual FireClass classes => FireClass.None;

        public override bool ApplyTo(AbstractHazard hazard)
        {
            if (this.IsEmpty())
            {
                return false;
            }

            var intensity = Math.Min(this.rate, this.fullness);
            this.fullness -= intensity;
            
            if (!this.Affects(hazard))
            {
                return false;
            }

            if (hazard is AbstractFire fire)
            {
                if (this.Resolves(fire))
                {
                    fire.Extinguish(intensity);
                    return fire.IsExtinguished();
                }

                fire.OnRemedy(this);
            }
            else
            {
                hazard.OnRemedy(this);
            }

            return false;
        }

        public void Extinguish(AbstractFire fire)
        {
            if (this.IsEmpty())
            {
                return;
            }
            
            base.ApplyTo(fire);
            this.fullness -= Math.Min(this.rate, this.fullness);
        }

        public void Refill()
        {
            this.fullness = this.capacity;
        }

        public bool IsEmpty()
        {
            return this.fullness <= 0;
        }
        
        public override bool Resolves(AbstractHazard hazard)
        {
            return base.Resolves(hazard) && (classes & ((AbstractFire)hazard).Class) != 0;
        }
    }
}
