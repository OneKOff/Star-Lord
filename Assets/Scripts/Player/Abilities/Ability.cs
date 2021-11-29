using UnityEngine;

//[RequireComponent(typeof(PlayerController))]
public abstract class Ability : MonoBehaviour
{
    // Fields     
    protected AbilityObject aObject;
    public AbilityObject AObject
    {
        get { return aObject; }
        private set { aObject = value; }
    }

    protected Timer _timer;
    protected PlayerController _player;

    // Basic methods
    protected virtual void Start()
    {
        _player = PlayerController.Instance;

        _timer = gameObject.AddComponent<Timer>();
        _timer.ResetTimer(aObject.Cooldown);
    }

    // User methods
    public virtual bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKey(buttonRegistered) && _timer.IsElapsed() && _player._energy >= aObject.EnergyCost)
        {
            _timer.ResetTimer();
            _player.ChangeEnergy(-aObject.EnergyCost);
            Action();

            return true;
        }
        return false;
    }
    protected virtual void Action()
    {
        Debug.Log("Ability Action");
    }
}
