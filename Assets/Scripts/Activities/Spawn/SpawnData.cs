using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Spawn")]
public class SpawnData : ScriptableObject
{
    [Tooltip("Must inherit by IObjectScreen if you use SpawnInScreenSide")]
    public GameObject Prefab;
    public float Rate;
}
