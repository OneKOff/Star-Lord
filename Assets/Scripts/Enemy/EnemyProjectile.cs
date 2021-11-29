using UnityEngine;

public class EnemyProjectile : Projectile
{
    // Basic Functions
    protected override void DetectEnemy(Collider2D collision)
    {
        PlayerController player;
        if ((player = collision.gameObject.GetComponent<PlayerController>()) != null)
        {
            player.ChangeHealth(-projData.Damage);
            _pierceLeft--;
            if (_pierceLeft <= 0)
            {
                OnObjectDespawn();
            }
        }
    }
}
