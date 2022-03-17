using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFollower<TObject> : ActivityBase<Transform>  where TObject : MonoBehaviour, IObjectScreen, IFollowable
{

    private SpawnData _spawnData;
    private Transform _target;
    private InstanceInScreenSide<TObject> _instance;
    private TObject _follower;
    public SpawnFollower(Transform t, SpawnData spawnData, Transform target, Camera camera) : base(t)
    {
        _spawnData = spawnData;
        _target = target;
        _instance = new InstanceInScreenSide<TObject>(camera);
    }

    public override void Update()
    {
        if (_follower == null) CreateFollower();
    }

    private void CreateFollower()
    {
        TObject follower = _instance.Create(_spawnData.Prefab.GetComponent<TObject>(), Side.right);
        follower.SetTarget(_target);
        _follower = follower;
    }
}
