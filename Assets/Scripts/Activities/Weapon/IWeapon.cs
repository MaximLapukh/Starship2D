using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon<TBullet>
{
    public event Action<GameObject> HadHit;
    public void Fire();
    public int GetCountBullets();
    public void SetCountBullets(int count);
    public float GetReloadTime();
}
