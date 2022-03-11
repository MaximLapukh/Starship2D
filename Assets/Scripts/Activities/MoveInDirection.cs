using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : Activity<Transform>
{
    private Vector3 _velocity;
    private Vector3 _desierdVelocity;
    private float _speed;
    private float _acceleration;
    public MoveInDirection(Transform transform) : base(transform)
    {
        _velocity = Vector3.zero;
        _speed = 0;
    }
    public void SetDirection(in Vector3 direction)
    {
        _desierdVelocity = direction * _speed;
    }
    public void SetSpeed(in float speed)
    {
        _speed = speed;
    }
    public void SetAcceleration(in float acceleration)
    {
        _acceleration = acceleration;
    }
    public override void Update()
    {
        if(_velocity != _desierdVelocity)
        {
            var t = _acceleration * Time.deltaTime / (_desierdVelocity - _velocity).magnitude;
            _velocity = Vector3.Lerp(_velocity, _desierdVelocity, t);
           
        }
        _t.Translate(_velocity * Time.deltaTime);
    }
}
