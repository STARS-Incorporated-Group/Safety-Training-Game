using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace backend
{
    public abstract class AbstractHazard
    {
        public readonly HazardType Type;
        public readonly DamageType DmgType;
        public float damageAmount { get; protected set; }
        
        protected AbstractHazard(HazardType type, DamageType damageType)
        {
            this.Type = type;
            this.DmgType = damageType;
        }

        public virtual void OnRemedy(AbstractRemedy remedy) {}
    }
}