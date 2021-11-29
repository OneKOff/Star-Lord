using UnityEngine;

public class LaserBeam : Ability
{
    // Fields    
    [SerializeField] private LaserBeamAbilityObject aLBObject;

    private LineRenderer _laserRenderer;

    // Basic methods
    protected void Awake()
    {
        aObject = aLBObject;
    }

    protected override void Start()
    {
        base.Start();

        _laserRenderer = Instantiate(aLBObject.LaserRendererPrefab);

        _laserRenderer.transform.SetParent(PlayerController.Instance.transform);
        _laserRenderer.enabled = false;
        Physics2D.queriesHitTriggers = false;
    }

    // User functions
    public override bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKey(buttonRegistered) && (_player._energy >= aObject.EnergyCost))
        {
            _laserRenderer.enabled = true;

            RaycastHit2D hitInfo = Physics2D.Raycast(_player.GunPoint.position, -_player.GunPoint.up, aLBObject.LaserMaxRange);

            if (hitInfo)
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                if (_timer.IsElapsed())
                {
                    _player.ChangeEnergy(-aObject.EnergyCost);
                    _timer.ResetTimer();
                    if ((enemy != null) && ((hitInfo.transform.position - _player.transform.position).magnitude <= aLBObject.LaserDamageRange))
                    {
                        enemy.ChangeHealth(-aLBObject.Damage);
                    }
                    else
                    {
                        DestructableDecoration destDecor = hitInfo.transform.GetComponent<DestructableDecoration>();
                        if ((destDecor != null) && ((hitInfo.transform.position - _player.transform.position).magnitude <= aLBObject.LaserDamageRange))
                        {
                            destDecor.TakeDamage(aLBObject.Damage);
                        }
                    }
                }

                _laserRenderer.SetPosition(0, _player.GunPoint.position + Vector3.back);
                _laserRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                if (_timer.IsElapsed())
                {
                    _player.ChangeEnergy(-aLBObject.EnergyCost);
                    _timer.ResetTimer();
                }
                _laserRenderer.SetPosition(0, _player.GunPoint.position + Vector3.back);
                _laserRenderer.SetPosition(1, _player.GunPoint.position - _player.GunPoint.up * aLBObject.LaserMaxRange);
            }
        }
        else
        {
            _laserRenderer.enabled = false;
        }
        return false;
    }
}
