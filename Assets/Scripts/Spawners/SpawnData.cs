using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Spawn")]
public class SpawnData : ScriptableObject
{
    public GameObject Prefab;
    public float Rate;
}
