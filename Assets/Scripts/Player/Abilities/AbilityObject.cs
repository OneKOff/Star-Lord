using UnityEngine;

[CreateAssetMenu(fileName = "Ability Object", menuName = "Ability/AbilityObject")]
public class AbilityObject : ScriptableObject
{
    // Fields     
    [SerializeField] protected SpriteRenderer abilityIcon;
    public SpriteRenderer AbilityIcon
    {
        get { return abilityIcon; }
        private set { abilityIcon = value; }
    }
    [SerializeField] protected int energyCost;
    public int EnergyCost
    {
        get { return energyCost; }
        private set { energyCost = value; }
    }
    [SerializeField] protected float cooldown;
    public float Cooldown
    {
        get { return cooldown; }
        private set { cooldown = value; }
    }

    /*protected PlayerController _player;
    protected Timer _timer;

    // Basic methods
    protected virtual void Start()
    {
        _player = PlayerController.Instance;

        _timer = new InnerTimer();
        _timer.ResetTimer(cooldown);
    }

    // User methods
    public virtual bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKey(buttonRegistered) && _timer.IsElapsed() && _player._energy >= energyCost)
        {
            _timer.ResetTimer();
            _player.ChangeEnergy(-energyCost);
            Action();

            return true;
        }
        return false;
    }
    protected virtual void Action()
    {
        Debug.Log("Scriptable Ability Action");
    }*/
}

/*[System.Serializable]
public class InnerTimer
{
    private float _startingTime = 0f;
    private float _timeLeft = 0f;

    void Update()
    {
        if (_timeLeft > 0)
            _timeLeft -= Time.deltaTime;
    }

    public bool IsElapsed() { return _timeLeft <= 0; }
    public void ResetTimer() { _timeLeft = _startingTime; }
    public void ResetTimer(float newTime)
    {
        _startingTime = newTime;
        _timeLeft = _startingTime;
    }
}
*/