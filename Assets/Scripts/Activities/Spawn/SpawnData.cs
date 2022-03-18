using UnityEngine;

[CreateAssetMenu(menuName = "Data/Spawn")]
public class SpawnData : ScriptableObject
{
    [Tooltip("Must inherit by IObjectScreen if you use SpawnInScreenSide")]
    public GameObject Prefab;
    public float Rate;
    //use field to access in future
}
