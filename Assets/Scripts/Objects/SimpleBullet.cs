using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : ObjectBehaviour, IBullet
{
    public event Action<GameObject> HadHit = delegate { };

    [Header("Base")]
    [SerializeField] MoveData _moveData;

    private MoveInDirection _moveinDirection;

    protected override void InitActivities()
    {
        _moveinDirection = new MoveInDirection(transform);
        _activities.Add(_moveinDirection);
    }
    public void Init(Transform firePoint)
    {

    }
    protected override void Start()
    {
        _moveinDirection.SetDirection(Vector3.up);
        _moveinDirection.SetSpeed(_moveData.Speed);
        _moveinDirection.SetAcceleration(_moveData.Acceleration);

        base.Start();
    }
    public void Crash(GameObject obj)
    {
        if (obj.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.Hit();
            HadHit.Invoke(obj);
            Destroy();
        }
    }
    public void Destroy()
    {
        //execute logic about Destroy
        Destroy(gameObject);
    }

}
