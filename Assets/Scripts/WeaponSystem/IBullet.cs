using System;
using UnityEngine;

public interface IBullet
{
    public event Action<GameObject> HadHit;
    public void Init(Transform firePoint);
}
