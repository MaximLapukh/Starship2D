using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInScreenSides<TObject> : SpawnerBase where TObject : MonoBehaviour, IObjectScreen
{

    private List<Side> _sides;
    private InstanceInScreenSide<TObject> _instance;
    public SpawnInScreenSides(Transform t, SpawnData spawnData, List<Side> sides, Camera camera) : base(t, spawnData)
    {
        _sides = sides;
        _instance = new InstanceInScreenSide<TObject>(camera);
    }
    protected override void Spawn()
    {
        Side side = _sides[Random.Range(0, _sides.Count)];
        _instance.Create(_spawnData.Prefab.GetComponent<TObject>(), side);
    }
}
