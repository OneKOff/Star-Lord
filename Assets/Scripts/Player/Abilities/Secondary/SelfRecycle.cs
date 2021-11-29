using UnityEngine;

public class SelfRecycle : Ability
{
    // Fields
    [SerializeField] private SelfRecycleAbilityObject aSRecObject;

    // Basic functions
    protected void Awake()
    {
        aObject = aSRecObject;
    }

    // User functions
    public override bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKey(buttonRegistered) && _timer.IsElapsed() && _player._health > aSRecObject.HealthCost && _player._energy < _player.MaxEnergy)
        {
            _timer.ResetTimer();
            _player.ChangeHealth(-aSRecObject.HealthCost);
            Action();

            return true;
        }
        return false;
    }

    protected override void Action()
    {
        _player.ChangeEnergy(aSRecObject.EnergyCost);
    }
}
