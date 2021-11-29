using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronScout : Enemy
{
    // Fields
    [SerializeField] private bool rushOn = false;
    [SerializeField] private bool gripOn = false;

    // Basic methods
    /*override protected void Update()
    {
        if ((targetTransform.position - transform.position).magnitude < aggroRange)
        {
            _aggro = true;
            _playerPositionInSight = targetTransform.position;
        }
        else if (_aggro)
        {
            _aggro = false;
        }

        if (_aggro)
        {
            _lookDir = ((Vector2)_playerPositionInSight - rb.position).normalized;
            float angle = Mathf.Atan2(_lookDir.y, _lookDir.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = angle;

            if (_shootTimer.IsElapsed())
            {
                _shootTimer.ResetTimer();
                StartCoroutine(MultiShot(multiShotCount, multiShotDelay));
            }
        }
        if ((_playerPositionInSight - (Vector2)rb.position).magnitude > 0.1f)
            rb.velocity = _lookDir * speed;
        else
            rb.velocity = Vector2.zero;
    }*/

    // User methods

}
