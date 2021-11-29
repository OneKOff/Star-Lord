using UnityEngine;

public class PlayerBarrierObject : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;

    private int damageBlock = 20;
    private float energyPerBlockedDamage = 0.5f;

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyProjectile _enemyProjectile;
        if ((_enemyProjectile = collision.gameObject.GetComponent<EnemyProjectile>()) != null)
        {
            if (_enemyProjectile.ProjData.Damage > damageBlock)
            {
                PlayerController.Instance.ChangeHealth
                    (damageBlock - _enemyProjectile.ProjData.Damage);
                PlayerController.Instance.ChangeEnergy
                    ((int)(damageBlock * energyPerBlockedDamage));
            }
            else
            {
                PlayerController.Instance.ChangeEnergy
                    ((int)(_enemyProjectile.ProjData.Damage * energyPerBlockedDamage));
            }
            _enemyProjectile.OnObjectDespawn();
        }
    }

    public void setData(int damageBlock, float energyPerBlockedDamage)
    {
        this.damageBlock = damageBlock;
        this.energyPerBlockedDamage = energyPerBlockedDamage;
    }
}
