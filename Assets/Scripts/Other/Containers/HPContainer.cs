using UnityEngine;

public class HPContainer : Container
{
    [SerializeField] private int containedHealth;

    override protected void ContainerFunction()
    {
        _player.ChangeHealth(containedHealth);
        base.ContainerFunction();
    }
}
