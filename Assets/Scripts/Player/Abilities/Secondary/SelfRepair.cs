using UnityEngine;

public class SelfRepair : Ability
{
    // Fields
    [SerializeField] private SelfRepairAbilityObject aSRepObject;

    // Basic functions
    protected void Awake()
    {
        aObject = aSRepObject;
    }

    // User functions
    public override bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKey(buttonRegistered) && _timer.IsElapsed() && _player._energy >= aSRepObject.EnergyCost && _player._health < _player.MaxHealth)
        {
            _timer.ResetTimer();
            _player.ChangeEnergy(-aSRepObject.EnergyCost);
            Action();

            return true;
        }
        return false;
    }

    protected override void Action()
    {
        _player.ChangeHealth(aSRepObject.HealthPerTick);
    }

    /*public new SelfRepairAbilityObject getAObject()
    {
        return aSRepObject;
    }*/
}
