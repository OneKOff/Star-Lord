using UnityEngine;

[CreateAssetMenu(fileName = "Energy Barrier", menuName = "Ability/Secondary/EnergyBarrier")]
public class EnergyBarrierAbilityObject : AbilityObject
{
    [SerializeField] private int damageBlock = 20;
    public int DamageBlock
    {
        get { return damageBlock; }
        private set { damageBlock = value; }
    }
    [SerializeField] private float energyPerBlockedDamage = 0.5f;
    public float EnergyPerBlockedDamage
    {
        get { return energyPerBlockedDamage; }
        private set { energyPerBlockedDamage = value; }
    }
}
