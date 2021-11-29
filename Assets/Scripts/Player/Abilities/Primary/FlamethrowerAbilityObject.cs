using UnityEngine;

[CreateAssetMenu(fileName = "Flamethrower", menuName = "Ability/Primary/Flamethrower")]
public class FlamethrowerAbilityObject : ProjectileAbilityObject
{
    [SerializeField] protected int shotAmount = 6;
    public int ShotAmount
    {
        get { return shotAmount; }
        private set { shotAmount = value; }
    }
    [SerializeField] protected float delayTime = 0.04f;
    public float DelayTime
    {
        get { return delayTime; }
        private set { delayTime = value; }
    }

    /*override public bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKey(buttonRegistered) && _timer.IsElapsed() && _player._energy >= energyCost)
        {
            _timer.ResetTimer();
            _player.ChangeEnergy(-energyCost);
            AbilityCoroutine(); // спорно

            return true;
        }
        return false;
    }

    IEnumerator AbilityCoroutine()
    {
        WaitForSeconds delay = new WaitForSeconds(delayTime);

        for (int i = 0; i < shotAmount; i++)
        {
            _projectile = Instantiate(projectilePrefab, _player.GunPoint.position, _player.transform.rotation);
            _projectile.transform.localEulerAngles += Vector3.forward * Random.Range(-spread, spread);

            _projectile.setDirection(-_projectile.transform.up);

            yield return delay;
        }
    }*/
}
