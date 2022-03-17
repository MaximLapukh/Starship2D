using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : ActivityBase<Transform>
{
    private Vector3 _direciton;
    private Vector3 _velocity;
    private Vector3 _desierdVelocity;
    private float _speed;
    private float _acceleration;
    public MoveInDirection(Transform transform) : base(transform)
    {
        _velocity = Vector3.zero;
        _speed = 1;
    }
    public void SetDirection(in Vector3 direction)
    {
        _direciton = direction.normalized;
        UpdateDesiredVelocity();
    }
    private void UpdateDesiredVelocity()
    {
        _desierdVelocity = _direciton * _speed;
    }
    public float GetSpeed()
    {
        return _velocity.magnitude;
    }
    public void SetSpeed(in float speed)
    {
        _speed = speed;
        UpdateDesiredVelocity();
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
