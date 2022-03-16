using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : Gun
{
    private float _rollback;
    private float _timer;
    public Lazer(Transform t, in Transform firePoint, in LazerData weaponData) : base(t, firePoint, weaponData)
    {
        _firePoint = firePoint;
        _weaponData = weaponData;
        _rollback = weaponData.Rollback + weaponData.ReloadTime;
        _timer = _rollback;
    }

    public override void Update()
    {
        if(_countBullets < _maxCountBullets)
        {
            if(_timer <= 0)
            {
                _countBullets++;
                _timer = _rollback;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }

        base.Update();
    }
    public float GetRollbackBullet()
    {
        return _timer;
    }
}
