using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Fields
    [SerializeField] private int maxHealth;
    public int MaxHealth {
        get { return maxHealth; }
        private set { maxHealth = value; }
    }
    [SerializeField] private int hpRegen, hpRegenCap;
    public int _health { get; private set; }

    [SerializeField] private int maxEnergy;
    public int MaxEnergy {
        get { return maxEnergy; }
        private set { maxEnergy = value; }
    }
    [SerializeField] private int epRegen, epRegenCap;
    public int _energy { get; private set; }

    private Timer _regenTimer;

    [SerializeField] private Slider hpBar;
    [SerializeField] private Slider epBar;

    [SerializeField] private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    [SerializeField] private Camera cam;
    private Vector2 _movement;
    public Vector2 _mousePos { get; private set; }
    public Vector2 _lookDir { get; private set; }
    public float _angle { get; private set; } 

    [SerializeField] private SpriteRenderer sprRend;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform gunPoint;
    public Transform GunPoint
    {
        get { return gunPoint; }
        private set { gunPoint = value; }
    }

    [SerializeField] private GameObject abilitiesContainer;
    [SerializeField] private Image[] abilityIcons = new Image[3];
    /*[SerializeField]*/ private Ability[] abilities = new Ability[3];

    public bool _alive { get; private set; }
    private Color _origColor;
    private Projectile _bullet;

    public static PlayerController Instance
    {
        get;
        private set;
    } = null;

    // Basic functions
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {  
        _alive = true;

        _regenTimer = gameObject.AddComponent<Timer>();
        _regenTimer.ResetTimer(1.6f);

        _health = maxHealth;
        hpBar.maxValue = maxHealth;
        hpBar.value = maxHealth;

        _energy = maxEnergy;
        epBar.maxValue = maxEnergy;
        epBar.value = maxEnergy;

        _origColor = sprRend.color;

        for (int i = 0; i < 3; i++)
        {
            abilityIcons[i].enabled = false;
        }

        AddAbility(Inventory.AbilityType1, 0);
        AddAbility(Inventory.AbilityType2, 1);
        AddAbility(Inventory.AbilityType3, 2);
    }
    private void Update()
    {
        if (_alive)
        {
            // Movement
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");

            _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Abilities
            if (abilities[0] != null) abilities[0].UseAbility(KeyCode.Mouse0);
            if (abilities[1] != null) abilities[1].UseAbility(KeyCode.Space);
            if (abilities[2] != null) abilities[2].UseAbility(KeyCode.Mouse1);

            // Exit
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("GameMap");
            }

            // Regen
            if (_regenTimer.IsElapsed())
            {
                // Reduce regen cd until it's 0.4s
                if (_regenTimer.StartingTime > 0.41f)
                {
                    _regenTimer.ResetTimer(_regenTimer.StartingTime / 2);
                }
                else
                {
                    _regenTimer.ResetTimer();
                }

                if (_health < hpRegenCap)
                {
                    ChangeHealth(hpRegen);
                }
                if (_energy < epRegenCap)
                {
                    ChangeEnergy(epRegen);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * speed * Time.deltaTime);

        _lookDir = (_mousePos - rb.position).normalized;
        _angle = Mathf.Atan2(_lookDir.y, _lookDir.x) * Mathf.Rad2Deg + 90f; // Спрайт повернут лицом вниз, поэтому изменяем его угол на 90 градусов вправо
        rb.rotation = _angle;
    }

    // User functions 
    public void ChangeHealth(int dHealth)
    {
        if (_alive)
        {// Take damage - reset regen timer's CD to 1.6
            if (dHealth < 0)
            {
                _regenTimer.ResetTimer(1.6f);
                StartCoroutine(DamageIndicate());
            }
            if (dHealth > 0 && _health < maxHealth)
            {
                StartCoroutine(HealIndicate());
            }
            _health += dHealth;
            _health = Mathf.Clamp(_health, 0, maxHealth);
            hpBar.value = _health;

            if (_health <= 0)
            {
                StartCoroutine(Die());
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

    public void AddAbility(Ability newAbility)
    {
        for (int i = 0; i < 3; i++)
        {
            if (abilities[i] == null)
            {
                abilities[i] = newAbility;
                abilityIcons[i].enabled = true;
                abilityIcons[i].sprite = abilities[i].AObject.AbilityIcon.sprite;
                return;
            }
        }

        abilities[0] = newAbility;
        abilityIcons[0].enabled = true;
        abilityIcons[0].sprite = abilities[0].AObject.AbilityIcon.sprite;
    }

    public void AddAbility(AbilityType.AType newAbility, int slotIndex)
    {
        switch (newAbility)
        {
            case AbilityType.AType.FireCannon:
                abilitiesContainer.GetComponent<FireCannon>().enabled = true;
                abilities[slotIndex] = abilitiesContainer.GetComponent<FireCannon>();
                break;
            case AbilityType.AType.Flamethrower:
                abilitiesContainer.GetComponent<Flamethrower>().enabled = true;
                abilities[slotIndex] = abilitiesContainer.GetComponent<Flamethrower>();
                break;
            case AbilityType.AType.LaserBeam:
                abilitiesContainer.GetComponent<LaserBeam>().enabled = true;
                abilities[slotIndex] = abilitiesContainer.GetComponent<LaserBeam>();
                break;
            case AbilityType.AType.ElectroBlade:
                abilitiesContainer.GetComponent<ElectroBlade>().enabled = true;
                abilities[slotIndex] = abilitiesContainer.GetComponent<ElectroBlade>();
                break;
            case AbilityType.AType.SelfRepair:
                abilitiesContainer.GetComponent<SelfRepair>().enabled = true;
                abilities[slotIndex] = abilitiesContainer.GetComponent<SelfRepair>();
                break;
            case AbilityType.AType.SelfRecycle:
                abilitiesContainer.GetComponent<SelfRecycle>().enabled = true;
                abilities[slotIndex] = abilitiesContainer.GetComponent<SelfRecycle>();
                break;
            case AbilityType.AType.FireCharge:
                abilitiesContainer.GetComponent<FireCharge>().enabled = true;
                abilities[slotIndex] = abilitiesContainer.GetComponent<FireCharge>();
                break;
            case AbilityType.AType.EnergyBarrier:
                abilitiesContainer.GetComponent<EnergyBarrier>().enabled = true;
                abilities[slotIndex] = abilitiesContainer.GetComponent<EnergyBarrier>();
                break;
            case AbilityType.AType.None:
                abilities[slotIndex] = null;
                abilityIcons[slotIndex].enabled = false;
                return;
        }

        abilityIcons[slotIndex].enabled = true;
        abilityIcons[slotIndex].sprite = abilities[slotIndex].AObject.AbilityIcon.sprite;
        Debug.Log("Added ability " + newAbility + " to slot " + slotIndex);
    }

    IEnumerator DamageIndicate()
    {
        sprRend.color = new Color(0.8f, 0.2f, 0.0f, 1.0f);

        yield return new WaitForSeconds(0.1f);

        sprRend.color = _origColor;
    }
    IEnumerator HealIndicate()
    {
        sprRend.color = new Color(0.2f, 0.8f, 0.0f, 1.0f);

        yield return new WaitForSeconds(0.1f);

        sprRend.color = _origColor;
    }
    IEnumerator Die()
    {
        sprRend.color = _origColor = Color.red;
        _alive = false;

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
