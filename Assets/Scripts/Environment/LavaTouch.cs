using UnityEngine;

public class LavaTouch : MonoBehaviour
{
    [SerializeField] private int touchDamage = 2;
    [SerializeField] private float damageInterval = 0.1f;

    private Timer _damageTimer;

    private void Start()
    {
        _damageTimer = gameObject.AddComponent<Timer>();
        _damageTimer.ResetTimer(damageInterval);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            if (_damageTimer.IsElapsed())
            {
                PlayerController.Instance.ChangeHealth(-touchDamage);
                _damageTimer.ResetTimer();
            }
        }
    }
}
