using UnityEngine;

[CreateAssetMenu(fileName = "Self Recycle", menuName = "Ability/Secondary/SelfRecycle")]
public class SelfRecycleAbilityObject : AbilityObject
{
    [SerializeField] private int healthCost = 5;
    public int HealthCost
    {
        get { return healthCost; }
        private set { healthCost = value; }
    }

    /*// User functions
    public override bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKey(buttonRegistered) && _timer.IsElapsed() && _player._health > healthCost && _player._energy < _player.MaxEnergy)
        {
            _timer.ResetTimer();
            _player.ChangeHealth(-healthCost);
            Action();

            return true;
        }
        return false;
    }

    protected override void Action()
    {
        _player.ChangeEnergy(energyCost);
    }*/
}
