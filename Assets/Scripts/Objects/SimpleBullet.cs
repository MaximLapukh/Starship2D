using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour, IBullet
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
    public void Init(Transform firePoint)
    {

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

    public void Crash(GameObject obj)
    {
        if (obj.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.Hit();
            Destroy(gameObject);
        }
    }

}
