using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Projectile")]
public class ProjectileObject : ScriptableObject
{
    [SerializeField] protected float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    [SerializeField] protected int damage;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    [SerializeField] protected int pierceAmount = 1;
    public int PierceAmount
    {
        get { return pierceAmount; }
        set { pierceAmount = value; }
    }
    [SerializeField] protected float expireTime = 2.0f;
    public float ExpireTime
    {
        get { return expireTime; }
        set { expireTime = value; }
    }
}
