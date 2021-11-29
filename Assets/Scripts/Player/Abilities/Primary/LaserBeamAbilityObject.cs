using UnityEngine;

[CreateAssetMenu(fileName = "Laser Beam", menuName = "Ability/Primary/LaserBeam")]
public class LaserBeamAbilityObject : AbilityObject
{
    // Fields    
    [SerializeField] private LineRenderer laserRendererPrefab;
    public LineRenderer LaserRendererPrefab
    {
        get { return laserRendererPrefab; }
        private set { laserRendererPrefab = value; }
    }
    [SerializeField] protected int damage = 5;
    public int Damage
    {
        get { return damage; }
        private set { damage = value; }
    }
    [SerializeField] private float laserDamageRange = 20f;
    public float LaserDamageRange
    {
        get { return laserDamageRange; }
        private set { laserDamageRange = value; }
    }
    [SerializeField] private float laserMaxRange = 20f;
    public float LaserMaxRange
    {
        get { return laserMaxRange; }
        private set { laserMaxRange = value; }
    }

    // Basic methods
    /*protected override void Start()
    {
        base.Start();

        _laserRenderer = Instantiate(laserRendererPrefab);

        _laserRenderer.transform.SetParent(PlayerController.Instance.transform);
        _laserRenderer.enabled = false;
        Physics2D.queriesHitTriggers = false;
    }

    // User functions
    public override bool UseAbility(KeyCode buttonRegistered)
    {
        if (Input.GetKey(buttonRegistered) && (_player._energy >= energyCost))
        {
            _laserRenderer.enabled = true;

            RaycastHit2D hitInfo = Physics2D.Raycast(_player.GunPoint.position, -_player.GunPoint.up, laserMaxRange);

            if (hitInfo)
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                if (_timer.IsElapsed())
                {
                    _player.ChangeEnergy(-energyCost);
                    _timer.ResetTimer();
                    if ((enemy != null) && ((hitInfo.transform.position - _player.transform.position).magnitude <= laserDamageRange))
                    {
                        enemy.ChangeHealth(-damage);
                    }
                }

                _laserRenderer.SetPosition(0, _player.GunPoint.position + Vector3.back);
                _laserRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                if (_timer.IsElapsed())
                {
                    _player.ChangeEnergy(-energyCost);
                    _timer.ResetTimer();
                }
                _laserRenderer.SetPosition(0, _player.GunPoint.position + Vector3.back);
                _laserRenderer.SetPosition(1, _player.GunPoint.position - _player.GunPoint.up * laserMaxRange);
            }
        }
        else
        {
            _laserRenderer.enabled = false;
        }
        return false;
    }*/
}
