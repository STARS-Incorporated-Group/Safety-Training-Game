using System.Collections;
using System.Collections.Generic;
using backend;
using Unity.VisualScripting;
using UnityEngine;

namespace backend
{
    public abstract class AbstractFire : AbstractHazard
    {
        public readonly FireClass Class;
        public float size;
        protected AbstractFire(FireClass fireClass): base(HazardType.Fire, DamageType.Burn)
        {
            this.Class = fireClass;
        }

        public override void OnRemedy(AbstractRemedy remedy)
        {
            if (remedy is AbstractFireExtinguisher)
            {
                if (remedy.Resolves(this))
                {
                    this.Extinguish(((AbstractFireExtinguisher)remedy).rate);
                }
            }
        }

        public bool IsExtinguished()
        {
            return this.size <= 0;
        }
        
        public virtual void Extinguish(float amount)
        {
            this.size -= amount;
        }
        
        public virtual void Pop() {}

        public virtual void Grow(Vector3 amount)
        {
            this.size += amount.magnitude;
        }

        public virtual AbstractFire Spread(Vector3 step)
        {
            return (AbstractFire)this.MemberwiseClone();
        }

        public virtual AbstractFire Spread(Vector3 step, Vector3 variation)
        {
            return (AbstractFire)this.MemberwiseClone();
        }
    }
}
