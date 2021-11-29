using UnityEngine;

[CreateAssetMenu(fileName = "Projectile Ability", menuName = "Ability/ProjectileAbility")]
public class ProjectileAbilityObject : AbilityObject
{
    [SerializeField] protected string projectileTag;
    public string ProjectileTag
    {
        get { return projectileTag; }
        private set { projectileTag = value; }
    }
    [SerializeField] protected float spread = 0f;
    public float Spread
    {
        get { return spread; }
        private set { spread = value; }
    }

    /*protected Projectile _projectile;

    // User methods
    protected override void Action()
    {
        Debug.Log("Projectile Ability Action");
        _projectile = Instantiate(projectilePrefab, _player.GunPoint.position, _player.transform.rotation);
        _projectile.transform.localEulerAngles += Vector3.forward * Random.Range(-spread, spread);

        _projectile.setDirection(-_projectile.transform.up);
    }*/
}
