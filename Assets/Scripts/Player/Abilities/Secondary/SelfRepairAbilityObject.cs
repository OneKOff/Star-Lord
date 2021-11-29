using UnityEngine;

[CreateAssetMenu(fileName = "Self Repair", menuName = "Ability/Secondary/SelfRepair")]
public class SelfRepairAbilityObject : AbilityObject
{
    [SerializeField] private int healthPerTick = 5;
    public int HealthPerTick
    {
        get { return healthPerTick; }
        private set { healthPerTick = value; }
    }

    /*// User functions
    public override bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKey(buttonRegistered) && _timer.IsElapsed() && _player._energy >= energyCost && _player._health < _player.MaxHealth)
        {
            _timer.ResetTimer();
            _player.ChangeEnergy(-energyCost);
            Action();

            return true;
        }
        return false;
    }

    protected override void Action()
    {
        _player.ChangeHealth(healthPerTick);
    }*/
}
