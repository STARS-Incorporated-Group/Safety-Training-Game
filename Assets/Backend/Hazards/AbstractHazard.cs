using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Backend.Hazards;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Backend
{
    public abstract class AbstractHazard
    {
        public BigInteger type { get; protected set; }
        public bool resolved { get; set; }

        protected DamageInfo Damage;
        
        protected AbstractHazard(BigInteger type, DamageInfo damageInfo)
        {
            this.type = type;
            this.resolved = false;
            this.Damage = damageInfo;
        }

        public virtual void Interact(AbstractRemedy remedy)
        {
            BigInteger responses = remedy.type & this.type;
            if ((responses & HazardResponse.Resolve) != 0)
            {
                this.resolved = true;
            }

            if ((responses & HazardResponse.IgniteHazard) != 0)
            {
                this.Ignite();
            }

            if ((responses & HazardResponse.Pop) != 0)
            {
                this.Pop();
            }

            if ((responses & HazardResponse.Explode) != 0)
            {
                this.Explode();
            }

            if ((responses & HazardResponse.Shock) != 0)
            {
                this.Shock();
            }
            
            if ((responses & HazardResponse.Intensify) != 0)
            {
                this.Intensify();
            }
            
            if ((responses & HazardResponse.Grow) != 0)
            {
                this.Grow();
            }
        }

        public virtual void Ignite() {}
        
        public virtual void Pop() { }
        public virtual void Explode() { }
        public virtual void Shock() { }

        public virtual AbstractHazard Spread(UnityEngine.Vector3 direction)
        {
            return null;
        }
        
        public virtual void Grow() { }
        
        public virtual void Intensify() {}

        public virtual DamageInfo GetDamage(AbstractRemedy protection = null)
        {
            if (protection == null || (protection.type & this.type & HazardResponse.Shield) == BigInteger.Zero)
            {
                return this.Damage.Copy();
            }
            return new DamageInfo();
        }
    }
}