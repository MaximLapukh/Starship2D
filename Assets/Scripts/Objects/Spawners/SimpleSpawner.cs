using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleSpawner<TObject> : ObjectBehaviour where TObject : MonoBehaviour, IObjectScreen
{
    [Header("Base")]
    [SerializeField] SpawnData _spawnData;
    [SerializeField] Camera _camera;

    [Header("Screen sides")]
    [SerializeField] bool _leftSide;
    [SerializeField] bool _rightSide;
    [SerializeField] bool _upSide;
    [SerializeField] bool _downSide;

    private SpawnerBase _spawner;
    protected override void InitActivities()
    {
        var sides = new List<Side>();
        AddSides(ref sides);

        _spawner = new SpawnInScreenSides<TObject>(transform, _spawnData, sides, _camera);
        _activities.Add(_spawner);
    }
    private void AddSides(ref List<Side> sides)
    {
        if (_leftSide) sides.Add(Side.left);
        if (_rightSide) sides.Add(Side.right);
        if (_upSide) sides.Add(Side.up);
        if (_downSide) sides.Add(Side.down);
    }
}
