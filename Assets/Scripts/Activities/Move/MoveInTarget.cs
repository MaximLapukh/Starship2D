using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//without acceleration and inertia
public class MoveInTarget : ActivityBase<Transform>, IFollowable
{
    private Vector3 _axesOffset;

    private Transform _target; 
    private Vector3 _offset;
    private float _speed;
    private Vector3 _velocity;
  
    public MoveInTarget(Transform t, Vector3 axesOffset) : base(t)
    {
        _axesOffset = axesOffset;
    }

    public void SetTarget(Transform target)
    {
        _target = target; 
        var offset = _t.position - _target.position;

        _offset = new Vector3(offset.x * _axesOffset.x, offset.y * _axesOffset.y, offset.z * _axesOffset.z);
    }
    public void SetSpeed(in float speed)
    {
        _speed = speed;
    }
    public override void Update()
    {
        if (_target == null) return;

        var delta = Vector3.SmoothDamp(_t.position, _target.position + _offset, ref _velocity, 0.1f, _speed);
        _t.position = delta;
    }
}
