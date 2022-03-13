using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    public void Fire();
    //todo: get count bullet in future
    public void SetCountBullets(int count);
    public float GetReloadTime();
}
