using UnityEngine;

public class AbilityContainer : Container
{
    [SerializeField] private Ability containedAbility;

    override protected void ContainerFunction()
    {
        _player.AddAbility(containedAbility);
        base.ContainerFunction();
    }
}
