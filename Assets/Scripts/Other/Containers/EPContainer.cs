using UnityEngine;

public class EPContainer : Container
{
    [SerializeField] private int containedEnergy;

    override protected void ContainerFunction()
    {
        _player.ChangeEnergy(containedEnergy);
        base.ContainerFunction();
    }
}
