using UnityEngine;

public class ElectroBlade : ProjectileAbility
{
    // Fields
    [SerializeField] private ElectroBladeAbilityObject aEBObject;

    // Basic functions
    protected void Awake()
    {
        aObject = aPObject = aEBObject;
    }

    // User functions
    /*protected override void Action()
    {
        _projectile = ObjectPooler.Instance.SpawnFromPool(aEBObject.ProjectileTag, _player.GunPoint.position, _player.transform.rotation).GetComponent<Projectile>();
        _projectile.transform.localEulerAngles += Vector3.forward * Random.Range(-aEBObject.Spread, aEBObject.Spread);

        _projectile.setDirection(-_projectile.transform.up);
    }*/

    /*public new ElectroBladeAbilityObject getAObject()
    {
        return aEBObject;
    }*/
}
