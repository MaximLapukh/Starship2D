using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : ActivityBase<Transform>, IWeapon<IBullet>
{
    public event Action<GameObject> HadBulletHit = delegate { };

    protected Transform _firePoint;
    protected WeaponData _weaponData;

    protected int _bullets;
    protected int _maxBullets;
    protected float _reloadTime;
    public Gun(Transform t, in Transform firePoint, in WeaponData weaponData) : base(t)
    {
        _firePoint = firePoint;
        _weaponData = weaponData;
        _bullets = weaponData.MaxTotalBullets;
    }
    public int GetCountBullets()
    {
        return _bullets;
    }
   
    public float GetReloadTime()
    {
        return _reloadTime;
    }

    public void Fire()
    {
        if (_reloadTime <= 0 && _bullets > 0)
        {
            GameObject bulletObj = GameObject.Instantiate(_weaponData.PrefBullet, _firePoint.position, _firePoint.rotation);
            IBullet bullet = bulletObj.GetComponent<IBullet>();
            bullet.Init(_firePoint);
            bullet.HadHit += HadBulletHit.Invoke;

            _bullets--;
            _reloadTime = _weaponData.ReloadTime;

        }
        
    }

    public override void Update()
    {
        if (_reloadTime > 0) _reloadTime -= Time.deltaTime;
    }
}
