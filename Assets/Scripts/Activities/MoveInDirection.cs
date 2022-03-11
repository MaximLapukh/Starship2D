using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : Activity<Transform>
{
    private Vector3 _direction;
    private float _speed;
    public MoveInDirection(Transform transform) : base(transform)
    {
        _direction = Vector3.zero;
        _speed = 0;
    }
    public void SetDirection(in Vector3 direction)
    {
        _direction = direction;
        Debug.Log(_direction);
    }
    public void SetSpeed(in float speed)
    {
        _speed = speed;
    }
    public override void Update()
    {
        _t.Translate(_direction * _speed * Time.deltaTime);
    }
}
