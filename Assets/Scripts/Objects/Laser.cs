using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour, IBullet
{
    [Header("Base")]
    [SerializeField] float _duration;

    private List<ActivityBase<Transform>> _activities;
    private CallbackOverTime _callback;
    private void Awake()
    {
        _activities = new List<ActivityBase<Transform>>();

        _callback = new CallbackOverTime(transform);
        _activities.Add(_callback);
    }
    public void Init(Transform firePoint)
    {
        transform.SetParent(firePoint);
    }

    void Start()
    {
        _callback.InvokeCallback(_duration, Destroy);
        foreach (var item in _activities)
        {
            item.Start();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
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
        }
    }
}
