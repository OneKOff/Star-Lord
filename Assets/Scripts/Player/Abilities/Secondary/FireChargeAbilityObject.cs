using UnityEngine;

[CreateAssetMenu(fileName = "Fire Charge", menuName = "Ability/Secondary/FireCharge")]
public class FireChargeAbilityObject : ProjectileAbilityObject
{
    [SerializeField] private float speedMultiplier = 2f;
    public float SpeedMultiplier
    {
        get { return speedMultiplier; }
        private set { speedMultiplier = value; }
    }
}
