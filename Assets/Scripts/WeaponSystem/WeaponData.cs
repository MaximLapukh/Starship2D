using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Weapon/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Tooltip("Must inherit by IBullet")]
    public GameObject PrefBullet;
    public int MaxTotalBullets;
    public float ReloadTime;
}
