using UnityEngine;

public class FireCannon : ProjectileAbility
{
    // Fields
    [SerializeField] private FireCannonAbilityObject aFCObject;

    // Basic functions
    protected void Awake()
    {
        aObject = aPObject = aFCObject;
    }

    // User functions
    /*protected override void Action()
    {
        _projectile = ObjectPooler.Instance.SpawnFromPool(getAObject().ProjectileTag, _player.GunPoint.position, _player.transform.rotation).GetComponent<Projectile>();
        _projectile.transform.localEulerAngles += Vector3.forward * Random.Range(-getAObject().Spread, getAObject().Spread);

        _projectile.setDirection(-_projectile.transform.up);
    }*/

    /*public new FireCannonAbilityObject getAObject()
    {
        return aFCObject;
    }*/
}
