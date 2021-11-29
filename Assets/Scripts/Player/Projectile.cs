using UnityEngine;

public class Projectile : MonoBehaviour, IPooledObject
{
    // Fields
    [SerializeField] protected ProjectileObject projData;
    public ProjectileObject ProjData
    {
        get { return projData; }
        private set { projData = value; }
    }
    [SerializeField] protected Rigidbody2D rb;

    protected Timer _expireTimer = null;
    protected int _pierceLeft;

    // Basic Functions
    protected virtual void Update()
    {
        if (_expireTimer.IsElapsed())
        {
            OnObjectDespawn();
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        DestructableDecoration _decor;
        if ((_decor = collision.GetComponent<DestructableDecoration>()) != null)
        {
            _decor.TakeDamage(projData.Damage);
            _pierceLeft--;
            if (_pierceLeft <= 0)
            {
                OnObjectDespawn();
            }

        }

        DetectEnemy(collision);
    }

    public virtual void OnObjectSpawn()
    {
        if (_expireTimer == null) _expireTimer = gameObject.AddComponent<Timer>();
        _expireTimer.ResetTimer( projData.ExpireTime );

        _pierceLeft = ProjData.PierceAmount;
    }
    public virtual void OnObjectDespawn()
    {
        gameObject.SetActive(false);
    }

    // User Functions
    protected virtual void DetectEnemy(Collider2D collision)
    {
        Enemy _enemy;
        if ((_enemy = collision.gameObject.GetComponent<Enemy>()) != null)
        {
            _enemy.ChangeHealth(-projData.Damage);
            _pierceLeft--;
            if (_pierceLeft <= 0)
            {
                OnObjectDespawn();
            }
        }
    }
    public virtual void setDirection(Vector2 dir)
    {
        rb.velocity = dir * projData.Speed;
    }
    public virtual void setVelocity(Vector2 dir, float newSpeed)
    {
        projData.Speed = newSpeed;
        rb.velocity = dir * projData.Speed;
    }
}
