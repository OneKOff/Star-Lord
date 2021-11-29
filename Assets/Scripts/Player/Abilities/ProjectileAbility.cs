using UnityEngine;

public abstract class ProjectileAbility : Ability
{
    // Fields
    protected ProjectileAbilityObject aPObject;

    protected Projectile _projectile;

    // Basic functions
    protected override void Start()
    {
        base.Start();

        aObject = aPObject;
    }

    // User methods
    protected override void Action()
    {
        _projectile = ObjectPooler.Instance.SpawnFromPool(aPObject.ProjectileTag, _player.GunPoint.position, _player.transform.rotation).GetComponent<Projectile>();
        _projectile.transform.localEulerAngles += Vector3.forward * Random.Range(-aPObject.Spread, aPObject.Spread);

        _projectile.setDirection(-_projectile.transform.up);
    }
}
