using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractHazard : MonoBehaviour
{
    public enum DamageType
    {
        Burn,
        Shock,
        Cut,
        LimbLoss,
        Crush,
        Poison,
        Radiation,
        Suffocation,
        InstantDeath
    }
    
    public readonly DamageType DmgType;
    public ColliderHit Collision;
    private float _damageAmount;
    private float _size;
    
    protected AbstractHazard(DamageType damageType)
    {
        this.DmgType = damageType;
    }
}
