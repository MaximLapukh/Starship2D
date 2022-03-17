using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon<TBullet>
{
    public event Action<GameObject> HadBulletHit;
    public void Fire();
    public int GetCountBullets();
    public float GetReloadTime();
}
