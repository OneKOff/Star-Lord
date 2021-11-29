using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // Fields
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected int maxEnergy = 100;
    [SerializeField] protected Slider hpBar;
    [SerializeField] protected Slider epBar;
    [SerializeField] protected float speed = 5.0f;

    [SerializeField] protected bool isBoss = false;

    [SerializeField] protected float aggroRange = 10.0f;
    [SerializeField] protected float aggroDamagedDuration = 2.0f;

    [SerializeField] protected string projectileTag = "EnemyFireball";
    [SerializeField] protected Transform gunPoint;
    [SerializeField] protected float shootCD;
    [SerializeField] protected int multiShotCount = 1;
    [SerializeField] protected float multiShotDelay = 0.2f;
    [SerializeField] protected float spread = 15f;

    [SerializeField] protected SpriteRenderer sprRend;
    [SerializeField] protected Rigidbody2D rb;

    protected Timer _shootTimer;

    protected int _health, _energy;
    protected bool _alive = true, _aggro = false;
    protected float _aggroRangeCurrent;
    protected Color origColor;

    protected Vector2 _playerPositionInSight;
    protected Vector2 _lookDir;
    protected EnemyProjectile _projectile;

    protected Transform targetTransform;

    // Basic Functions
    protected void Start()
    {
        _health = maxHealth;
        hpBar.maxValue = maxHealth;
        hpBar.value = maxHealth;

        _energy = maxEnergy;
        epBar.maxValue = maxEnergy;
        epBar.value = maxEnergy;

        _shootTimer = gameObject.AddComponent<Timer>();
        _shootTimer.ResetTimer(shootCD);

        origColor = sprRend.color;

        targetTransform = PlayerController.Instance.transform;
        _aggroRangeCurrent = aggroRange;
    }
    protected void Update()
    {
        if ((targetTransform.position - transform.position).magnitude < _aggroRangeCurrent)
        {
            _aggro = true;
            _playerPositionInSight = targetTransform.position;
        }
        else if (_aggro)
        {
            _aggro = false;
        }

        if (_aggro)
        {
            _lookDir = ((Vector2)_playerPositionInSight - rb.position).normalized;
            float angle = Mathf.Atan2(_lookDir.y, _lookDir.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = angle;

            if (_shootTimer.IsElapsed())
            {
                _shootTimer.ResetTimer();
                StartCoroutine(MultiShot(multiShotCount, multiShotDelay));
            }
        }
        if ((_playerPositionInSight - (Vector2)rb.position).magnitude > 0.1f)
            rb.velocity = _lookDir * speed;
        else
            rb.velocity = Vector2.zero;
    }

    // User Functions
    public void ChangeHealth(int dHealth)
    {
        //Debug.Log(gameObject.name + ": changed health from " + _health + " by value of " + dHealth);
        if (_alive)
        {
            _health += dHealth;
            _health = Mathf.Clamp(_health, 0, maxHealth);

            hpBar.value = _health;

            if (_health <= 0)
            {
                StartCoroutine(Die());
            }

            if (dHealth < 0)
            {
                StartCoroutine(DamageIndicate());
                StartCoroutine(DamageAggro());
            }
        }
    }
    public void ChangeEnergy(int dEnergy)
    {
        if (_alive)
        {
            _energy += dEnergy;
            _energy = Mathf.Clamp(_energy, 0, maxEnergy);

            epBar.value = _energy;
        }
    }

    protected IEnumerator MultiShot(int shots, float delay)
    {
        if (_alive)
        {
            _shootTimer.ResetTimer();
            //ChangeEnergy(-20);

            for (int i = 0; i < shots; i++)
            {
                _projectile = ObjectPooler.Instance.SpawnFromPool(projectileTag, gunPoint.position, gunPoint.rotation).GetComponent<EnemyProjectile>();
                _projectile.transform.localEulerAngles += Vector3.forward * Random.Range(-spread, spread);
                
                _projectile.setDirection(-_projectile.transform.up);

                yield return new WaitForSeconds(delay);
            }
        }
    }
    protected IEnumerator DamageIndicate()
    {
        sprRend.color = new Color(0.8f, 0.2f, 0.0f, 1.0f);

        yield return new WaitForSeconds(0.1f);

        sprRend.color = origColor;
    }
    protected IEnumerator DamageAggro()
    {
        _aggroRangeCurrent = 100.0f;
        yield return new WaitForSeconds(aggroDamagedDuration);
        _aggroRangeCurrent = aggroRange;
    }
    protected IEnumerator Die()
    {
        sprRend.color = origColor = Color.red;
        _alive = false;

        yield return new WaitForSeconds(1f);

        if (isBoss == true)
        {
            foreach (LevelData level in MapData.levelsData)
            {
                Debug.Log("Level " + level.ID + ", Unlocked: " + level.Unlocked + ", Completed: " + level.Completed);
            }

            LevelData.CompleteLevel(MapData.currentLevelId);

            foreach (LevelData level in MapData.levelsData)
            {
                Debug.Log("Level " + level.ID + ", Unlocked: " + level.Unlocked + ", Completed: " + level.Completed);
            }

            SceneManager.LoadScene("GameMap");
        }

        Destroy(this.gameObject);
        // In pool ^
    }
}
