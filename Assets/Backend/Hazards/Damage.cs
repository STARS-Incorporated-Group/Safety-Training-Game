namespace Backend.Hazards
{
    public struct DamageInfo
    {
        public float BurnDamage;
        public float ElectricalDamage;
        public float PoisonDamage;
        public float RadiationDamage;
        public float CutDamage;
        public float FallDamage;
        public bool InstaKill;

        public DamageInfo(float burnDamage, float electricalDamage, float poisonDamage, float radiationDamage,
            float cutDamage, float fallDamage, bool instaKill)
        {
            this.BurnDamage = burnDamage;
            this.ElectricalDamage = electricalDamage;
            this.PoisonDamage = poisonDamage;
            this.RadiationDamage = radiationDamage;
            this.CutDamage = cutDamage;
            this.FallDamage = fallDamage;
            this.InstaKill = instaKill;
        }

        public DamageInfo Copy()
        {
            return (DamageInfo)this.MemberwiseClone();
        }
    }
}