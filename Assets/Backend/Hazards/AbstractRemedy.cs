using System.Linq;
using System.Numerics;

namespace Backend.Hazards
{
    public abstract class AbstractRemedy
    {
        public BigInteger type { get; protected set; }

        public virtual bool Interact(AbstractHazard hazard)
        {
            if (!this.Affects(hazard))
            {
                return false;
            }

            hazard.Interact(this);
            BigInteger response = this.type & hazard.type;
            if ((response & HazardResponse.IgniteRemedy) != 0)
            {
                this.Ignite();
            }
            return (response & HazardResponse.Resolve) != 0;
        }

        public virtual AbstractHazard Ignite()
        {
            return null;
        }
        
        public virtual bool Affects(AbstractHazard hazard)
        {
            return (this.type & hazard.type) != 0;
        } 
    }
}