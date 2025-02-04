using System.Linq;

namespace backend
{
    public abstract class AbstractRemedy
    {
        protected virtual HazardType affectedHazardTypes => 0;
        protected virtual HazardType remediedHazardTypes => 0;

        public virtual bool ApplyTo(AbstractHazard hazard)
        {
            if (!this.Affects(hazard))
            {
                return false;
            }

            hazard.OnRemedy(this);
            return this.Resolves(hazard);
        }

        public virtual bool Resolves(AbstractHazard hazard)
        {
            return (affectedHazardTypes & hazard.Type) != 0;
        } 
        
        public virtual bool Affects(AbstractHazard hazard)
        {
            return (remediedHazardTypes & hazard.Type) != 0;
        } 
    }
}