using System;
using UnityEngine;

internal class AlienLogic
{
    internal void Fire(IWeapon<IBullet> weapon, Transform firePoint)
    {
        firePoint.localRotation = ScreenCoordinator2D.GetRndAngels(0, 359, new Vector3(0, 0, 1));
        weapon.Fire();
    }
    internal void Crash(GameObject obj, GameObject gameObject, Action destroy)
    {
        if (obj.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.Hit(gameObject);
            destroy();
        }
    }
}
