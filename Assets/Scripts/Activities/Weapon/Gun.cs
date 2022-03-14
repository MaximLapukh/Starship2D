using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : ActivityBase<Transform>, IWeapon
{
    private Transform _firePoint;
    private WeaponData _weaponData;

    private int _countBullets;
    private float _reloadTime;
    public Gun(Transform t, in Transform firePoint, in WeaponData weaponData) : base(t)
    {
        _firePoint = firePoint;
        _weaponData = weaponData;
    }
    public int GetCountBullets()
    {
        return _countBullets;
    }
    public void SetCountBullets(int count)
    {
        _countBullets = count;
    }
   
    public float GetReloadTime()
    {
        return _reloadTime;
    }

    public void Fire()
    {
        if (_reloadTime <= 0 && _countBullets > 0)
        {
            GameObject bullet = GameObject.Instantiate(_weaponData.PrefBullet, _firePoint.position, _firePoint.rotation);
            bullet.GetComponent<IBullet>().Init(_firePoint);

            _countBullets--;
            _reloadTime = _weaponData.ReloadTime;

        }
        
    }

    public override void Update()
    {
        if (_reloadTime > 0) _reloadTime -= Time.deltaTime;
    }
}
