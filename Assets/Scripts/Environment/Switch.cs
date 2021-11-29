using UnityEngine;

public class Switch : Mechanism
{
    [SerializeField] private Mechanism attachedMechanism;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (attachedMechanism.Active == true)
            {
                active = false;
                attachedMechanism.Deactivate();
                GetComponent<SpriteRenderer>().sprite = inactiveState;
            }
            else
            {
                active = true;
                attachedMechanism.Activate();
                GetComponent<SpriteRenderer>().sprite = activeState;
            }
        }
    }
}
