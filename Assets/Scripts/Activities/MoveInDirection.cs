using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : Activity<Transform>
{
    private Vector2 _direction;
    private float _speed;
    public MoveInDirection(Transform transform, in Vector2 direction, in float speed) : base(transform)
    {
        SetDirection(direction);
        SetSpeed(speed);
    }
    public void SetDirection(in Vector2 direction)
    {
        _direction = direction;
    }
    public void SetSpeed(in float speed)
    {
        _speed = speed;
    }
    public override void Update()
    {
        Debug.Log(_direction);
        _t.Translate(_direction * _speed * Time.deltaTime);
    }
}
