using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : ActivityBase<Transform>, IWeapon<IBullet>
{
    public event Action<GameObject> HadHit = delegate { };

    protected Transform _firePoint;
    protected WeaponData _weaponData;

    protected int _countBullets;
    protected int _maxCountBullets;
    protected float _reloadTime;
    public Gun(Transform t, in Transform firePoint, in WeaponData weaponData) : base(t)
    {
        _firePoint = firePoint;
        _weaponData = weaponData;
    }
    public int GetCountBullets()
    {
        return _countBullets;
    }
    public void SetMaxCountBullets(int count)
    {
        _countBullets = count;
        _maxCountBullets = count;
    }
   
    public float GetReloadTime()
    {
        return _reloadTime;
    }

    public void Fire()
    {
        if (_reloadTime <= 0 && _countBullets > 0)
        {
            GameObject bulletObj = GameObject.Instantiate(_weaponData.PrefBullet, _firePoint.position, _firePoint.rotation);
            IBullet bullet = bulletObj.GetComponent<IBullet>();
            bullet.Init(_firePoint);
            bullet.HadHit += HadHit.Invoke;

            _countBullets--;
            _reloadTime = _weaponData.ReloadTime;

        }
        
    }

    public override void Update()
    {
        if (_reloadTime > 0) _reloadTime -= Time.deltaTime;
    }
}
