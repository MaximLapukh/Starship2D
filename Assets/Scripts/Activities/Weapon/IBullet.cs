using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    public event Action<GameObject> HadHit;
    public void Init(Transform firePoint);
}
