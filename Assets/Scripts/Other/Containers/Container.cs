using UnityEngine;

public class Container : MonoBehaviour
{
    protected PlayerController _player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out _player))
        {
            ContainerFunction();
        }
    }
    protected virtual void ContainerFunction()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
