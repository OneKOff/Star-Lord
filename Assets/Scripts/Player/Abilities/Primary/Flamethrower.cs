using System.Collections;
using UnityEngine;

public class Flamethrower : ProjectileAbility
{
    // Fields    
    [SerializeField] private FlamethrowerAbilityObject aFTObject;

    // Basic functions
    protected void Awake()
    {
        aObject = aPObject = aFTObject;
    }

    // User functions
    override public bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKey(buttonRegistered) && _timer.IsElapsed() && _player._energy >= aFTObject.EnergyCost)
        {
            _timer.ResetTimer();
            _player.ChangeEnergy(-aFTObject.EnergyCost);
            StartCoroutine(AbilityCoroutine());

            return true;
        }
        return false;
    }

    IEnumerator AbilityCoroutine()
    {
        for (int i = 0; i < aFTObject.ShotAmount; i++)
        {
            _projectile = ObjectPooler.Instance.SpawnFromPool(aFTObject.ProjectileTag, _player.GunPoint.position, _player.transform.rotation).GetComponent<Projectile>();
            _projectile.transform.localEulerAngles += Vector3.forward * Random.Range(-aFTObject.Spread, aFTObject.Spread);

            _projectile.setDirection(-_projectile.transform.up);

            yield return new WaitForSeconds(aFTObject.DelayTime);
        }
    }

    /*public new FlamethrowerAbilityObject getAObject()
    {
        return aFTObject;
    }*/
}
