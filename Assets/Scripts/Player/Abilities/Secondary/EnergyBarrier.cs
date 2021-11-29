using UnityEngine;

public class EnergyBarrier : Ability
{
    // Fields
    [SerializeField] private EnergyBarrierAbilityObject aEBObject;
    public EnergyBarrierAbilityObject AEBObject
    {
        get { return aEBObject; }
        private set { aEBObject = value; }
    }
    [SerializeField] private PlayerBarrierObject barrierPrefab;

    protected PlayerBarrierObject _barrier;
    protected bool _active = false;

    // Basic methods
    protected void Awake()
    {
        aObject = aEBObject;
    }

    protected override void Start()
    {
        base.Start();

        _barrier = Instantiate(barrierPrefab, _player.transform);
        _barrier.setData(aEBObject.DamageBlock, aEBObject.EnergyPerBlockedDamage);

        _barrier.gameObject.SetActive(false);
    }

    protected void Update()
    {
        _barrier.transform.position = _player.transform.position;
        _barrier.transform.rotation = _player.transform.rotation;

        if (_timer.IsElapsed() && _active == true)
        {
            if (_player._energy < aEBObject.EnergyCost)
            {
                _active = false;
                _barrier.gameObject.SetActive(false);
            }
            else
            {
                _timer.ResetTimer();
                _player.ChangeEnergy(-aEBObject.EnergyCost);
            }
        }
    }

    // User functions
    public override bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKeyDown(buttonRegistered) && _player._energy > aEBObject.EnergyCost)
        {
            _timer.ResetTimer();
            Action();

            return true;
        }
        return false;
    }

    protected override void Action()
    {
        _active = !_active;
        _barrier.gameObject.SetActive(_active);
    }
}
