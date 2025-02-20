using System;
using System.Numerics;

namespace Backend.Hazards
{
    internal static class Constants
    {
        internal const int NumHazards = 15;
        internal const int NumResponses = 10;

        internal static readonly BigInteger RepeatBits =
            ((BigInteger.One << NumHazards * NumResponses) - BigInteger.One) /
            ((BigInteger.One << NumHazards) - BigInteger.One);
    }
    
    public static class FireType // Cant enum a BigInteger so this is the next best thing
    {
        public static readonly BigInteger None = 0UL;
        public static readonly BigInteger ClassA = Constants.RepeatBits;
        public static readonly BigInteger ClassB = ClassA << 1;
        public static readonly BigInteger ClassC = ClassB << 1;
        public static readonly BigInteger ClassD = ClassC << 1;
        public static readonly BigInteger ClassE = ClassD << 1;
        public static readonly BigInteger ClassK = ClassE << 1;
        public static readonly BigInteger Solid = ClassA;
        public static readonly BigInteger Liquid = ClassB;
        public static readonly BigInteger Gas = ClassC;
        public static readonly BigInteger Metal = ClassD;
        public static readonly BigInteger Electrical = ClassE;
        public static readonly BigInteger Oil = ClassK;
        public static readonly BigInteger Any = ClassA | ClassB | ClassC | ClassD | ClassE | ClassK;
    }
    
    public static class SpillType // Cant enum a BigInteger so this is the next best thing
    {
        public static readonly BigInteger None = 0UL;
        public static readonly BigInteger ChemicalLiquid = FireType.ClassK << 1;  // liquid chemical spill
        public static readonly BigInteger Radiological = ChemicalLiquid << 1;     // radioactive solid
        public static readonly BigInteger Any = ChemicalLiquid | Radiological;
    }

    public static class FumeType
    {
        public static readonly BigInteger None = 0UL;
        public static readonly BigInteger Nontoxic = 0UL;
        public static readonly BigInteger Nonflammable = 0UL;
        public static readonly BigInteger Odorless = 0UL;

        public static readonly BigInteger Toxic = SpillType.Radiological << 1;                         // will cause issues if inhaled
        public static readonly BigInteger Flammable = Toxic << 1;      // catches fire and rapidly expands
        public static readonly BigInteger Scented = Flammable << 1;                    // will trigger smell indicators
        
        public static readonly BigInteger NontoxicFlammableOdorless = Nontoxic | Flammable | Odorless;
        public static readonly BigInteger NontoxicFlammableScented = Nontoxic | Flammable | Scented;
        public static readonly BigInteger NontoxicNonflammableOdorless = Nontoxic | Nonflammable | Odorless;
        public static readonly BigInteger NontoxicNonflammableScented = Nontoxic | Nonflammable | Scented;
        public static readonly BigInteger ToxicFlammableOdorless = Toxic | Flammable | Odorless;
        public static readonly BigInteger ToxicFlammableScented = Toxic | Flammable | Scented;
        public static readonly BigInteger ToxicNonflammableOdorless = Toxic | Nonflammable | Odorless;
        public static readonly BigInteger ToxicNonflammableScented = Toxic | Nonflammable | Scented;
        public static readonly BigInteger Any = ToxicFlammableScented;
    }
    
    public static class ElectricalHazardType // Cant enum a BigInteger so this is the next best thing
    {
        public static readonly BigInteger None = 0UL;
        public static readonly BigInteger ConductiveSurface = FumeType.Scented << 1;    // a hazard that needs to be touched to cause harm
        public static readonly BigInteger ArcShock = ConductiveSurface << 1;            // a region in which any conductable object in that region will get shocked with an arc of electricity.
        public static readonly BigInteger Electrocuting = ArcShock << 1;                // for any electrical hazard that will cause electricution. Will make it very hard to control movement.
        public static readonly BigInteger Lethal = ArcShock << 1;                // for any electrical hazard that will cause electricution. Will make it very hard to control movement.
        public static readonly BigInteger Any = ConductiveSurface | ArcShock | Electrocuting;
    }
    
    public static class HazardResponse
    {
        public static readonly BigInteger None = 0UL;
        // 0b11111... (there is one 1 for each hazard type)
        public static readonly BigInteger Resolve = (1UL << Constants.NumHazards) - 1UL;
        public static readonly BigInteger Shield = Resolve << Constants.NumHazards;
        public static readonly BigInteger IgniteRemedy = Resolve << Constants.NumResponses;
        public static readonly BigInteger IgniteHazard = IgniteRemedy << Constants.NumResponses;
        public static readonly BigInteger IgniteAll = IgniteRemedy | IgniteHazard;
        public static readonly BigInteger Pop = IgniteHazard << Constants.NumResponses;
        public static readonly BigInteger Explode = Pop << Constants.NumResponses;
        public static readonly BigInteger Shock = Explode << Constants.NumResponses;
        public static readonly BigInteger Grow = Shock << Constants.NumResponses;
        public static readonly BigInteger Intensify = Grow << Constants.NumResponses;
        public static readonly BigInteger Spread = Intensify << Constants.NumResponses;
        public static readonly BigInteger ReleaseFumes = Spread << Constants.NumResponses;
    }

    [Flags]
    public enum HazardResponseBitShift : int
    {
        Resolve      = 0,                                       // start permanently resolving the hazard
        Shield       = Constants.NumResponses,                  // block hazard from causing harm to the user
        IgniteRemedy = Shield       + Constants.NumResponses,   // when the thing interacting with the hazard is flammable
        IgniteHazard = IgniteRemedy + Constants.NumResponses,   // when the thing interacting with the hazard will cause the hazard to catch fire
        Pop          = IgniteHazard + Constants.NumResponses,   // droplets go flying and spread the hazard
        Explode      = Pop          + Constants.NumResponses,   // cause an explosion shockwave
        Shock        = Explode      + Constants.NumResponses,   // create a shock zone
        Spread       = Shock        + Constants.NumResponses,   // cause the hazard to spread to adjacent areas
        Grow         = Spread       + Constants.NumResponses,   // cause hazard to grow in place (bigger collision box or something)
        Intensify    = Grow         + Constants.NumResponses,   // hazard will deal more damage 
        ReleaseFumes = Intensify    + Constants.NumResponses    // releases toxic fume clouds
    }
    
    public static class RemedyTypes
    {
        public static readonly BigInteger None = 0;
        public static readonly BigInteger Water = (FireType.ClassA & HazardResponse.Resolve) | (FireType.ClassB & HazardResponse.Spread) | (FireType.ClassC & HazardResponse.Spread) | (FireType.ClassD & (HazardResponse.Grow | HazardResponse.Explode | HazardResponse.ReleaseFumes)) | (FireType.ClassK & HazardResponse.Pop);
        public static readonly BigInteger FoamExtinguisher = ((FireType.ClassA | FireType.ClassB) & HazardResponse.Resolve) | (FireType.ClassE & HazardResponse.Shock);
        public static readonly BigInteger DryChemicalExtinguisher = ((FireType.ClassA | FireType.ClassB | FireType.ClassC | FireType.ClassE) & HazardResponse.Resolve);
        public static readonly BigInteger CO2Extinguisher = (FireType.ClassB | FireType.ClassE) & HazardResponse.Resolve;
        public static readonly BigInteger WetChemicalExtinguisher = ((FireType.ClassA | FireType.ClassK) & HazardResponse.Resolve) | (FireType.ClassE & HazardResponse.Shock);
        public static readonly BigInteger PowderExtinguisher = (FireType.ClassA | FireType.ClassB | FireType.ClassC | FireType.ClassD | FireType.ClassE) & HazardResponse.Resolve;
        public static readonly BigInteger FireBlanket = (FireType.ClassA | FireType.ClassD | FireType.ClassK) & HazardResponse.Resolve;
        public static readonly BigInteger Sand = FireType.ClassD & HazardResponse.Resolve;
        public static readonly BigInteger Soil = Sand;
        public static readonly BigInteger Sprinkler = Water;
        public static readonly BigInteger PaperTower = (FireType.Any & HazardResponse.IgniteRemedy) | (SpillType.ChemicalLiquid & HazardResponse.Resolve);
        public static readonly BigInteger Glove = ElectricalHazardType.ConductiveSurface & HazardResponse.Shield;
        public static readonly BigInteger Mop = SpillType.ChemicalLiquid & HazardResponse.Resolve;
    }

    public static class HazardDamage
    {
        public static readonly BigInteger None = 0;
        public static readonly BigInteger Burn = FireType.Any | SpillType.ChemicalLiquid;
        public static readonly BigInteger Shock = ElectricalHazardType.Any;
        public static readonly BigInteger Electrocute = ElectricalHazardType.Electrocuting;
        public static readonly BigInteger Die = ElectricalHazardType.Lethal;
        public static readonly BigInteger Poison = FumeType.Toxic;
        public static readonly BigInteger Radiation = SpillType.Radiological;
    }
}