using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectBehaviour : MonoBehaviour
{
    protected List<ActivityBase<Transform>> _activities;
    private bool _isStopActivities;

    protected void Awake()
    {
        _activities = new List<ActivityBase<Transform>>();
        InitActivities();
    }
    protected virtual void InitActivities()
    {

    }
    protected virtual void Start()
    {
        foreach (var item in _activities)
        {
            item.Start();
        }
    }

    protected virtual void Update()
    {
        if (_isStopActivities) return;
        foreach (var item in _activities)
        {
            item.Update();
        }
    }

    protected virtual void Stop()
    {
        foreach (var item in _activities)
        {
            item.Stop();
        }
    }
    public void StartAllActivities()
    {
        Start();
        _isStopActivities = false;
    }
    public void StopAllActivities()
    {
        Stop();
        _isStopActivities = true;
    }
}
