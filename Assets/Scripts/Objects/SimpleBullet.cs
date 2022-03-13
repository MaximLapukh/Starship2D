using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] MoveData _moveData;

    private List<ActivityBase<Transform>> _activities;
    private MoveInDirection _moveinDirection;
    void Awake()
    {
        _activities = new List<ActivityBase<Transform>>();

        _moveinDirection = new MoveInDirection(transform);
        _activities.Add(_moveinDirection);

    }

    void Start()
    {
        _moveinDirection.SetDirection(Vector3.up);
        _moveinDirection.SetSpeed(_moveData.Speed);
        _moveinDirection.SetAcceleration(_moveData.Acceleration);

        foreach (var item in _activities)
        {
            item.Start();
        }
    }
    void Update()
    {
        foreach (var item in _activities)
        {
            item.Update();
        }
    }

    public void Crash(IDamagable damagable)
    {
        damagable.Hit();
        Destroy(gameObject);
    }
}
