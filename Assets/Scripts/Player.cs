using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Activity<Transform>> _activities;

    private MoveInDirection _moveinDirection;
    private void Awake()
    {
        _activities = new List<Activity<Transform>>();
        _moveinDirection = new MoveInDirection(transform, transform.up, 2);
        _activities.Add(_moveinDirection);

    }
    void Start()
    {
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
}
