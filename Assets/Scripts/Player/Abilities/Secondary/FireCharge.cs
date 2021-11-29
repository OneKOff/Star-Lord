using UnityEngine;

public class FireCharge : ProjectileAbility
{
    // Fields
    [SerializeField] private FireChargeAbilityObject aFChObject;

    // User functions
    protected Projectile _fireMine;
    protected bool _active = false;

    // Basic methods
    protected void Awake()
    {
        aObject = aPObject = aFChObject;
    }

    protected void Update()
    {
        if (_timer.IsElapsed() && _active == true)
        {
            if (_player._energy < aFChObject.EnergyCost)
            {
                _active = false;
                _player.Speed /= aFChObject.SpeedMultiplier;
            }
            else
            {
                _timer.ResetTimer();

                _fireMine = ObjectPooler.Instance.SpawnFromPool(aFChObject.ProjectileTag, _player.GunPoint.position, _player.transform.rotation).GetComponent<Projectile>();
                _fireMine.transform.localEulerAngles += Vector3.forward * Random.Range(-aPObject.Spread, aPObject.Spread);

                _fireMine.setDirection(_fireMine.transform.up);
                _player.ChangeEnergy(-aFChObject.EnergyCost);
            }
        }
    }

    // User functions
    public override bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKeyDown(buttonRegistered) && _player._energy > aFChObject.EnergyCost)
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
        if (_active == true)
        {
            _player.Speed *= aFChObject.SpeedMultiplier;
        }
        else
        {
            _player.Speed /= aFChObject.SpeedMultiplier;
        }
    }
}
