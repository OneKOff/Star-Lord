using UnityEngine;

public class Mechanism : MonoBehaviour
{
    [SerializeField] protected Sprite activeState, inactiveState;
    [SerializeField] protected bool active = false;
    public bool Active
    {
        get { return active; }
        private set { active = value; }
    }

    private void Awake()
    {
        GetComponent<BoxCollider2D>().enabled = !active;
        if (active)
        {
            GetComponent<SpriteRenderer>().sprite = activeState;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = inactiveState;
        }
    }

    public void ChangeState()
    {
        if (active)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    public void Activate()
    {
        active = true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = activeState;
    }

    public void Deactivate()
    {
        active = false;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().sprite = inactiveState;
    }
}
