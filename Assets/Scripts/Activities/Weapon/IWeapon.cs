using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    public void Fire();
    public int GetCountBullets();
    public void SetCountBullets(int count);
    public float GetReloadTime();
}
