using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularRotate : Activity<Transform>
{
    private Vector3 _direction;
    private float _angle;
    public RegularRotate(Transform t) : base(t)
    {
        _direction = Vector3.zero;
        _angle = 0;
    }
    public void SetDirection(in Vector3 direction)
    {
        _direction = direction;
    }
    public void SetSpeed(in float angle)
    {
        _angle = angle;
    }
    public override void Update()
    {
        _t.Rotate(_direction, _angle * Time.deltaTime);
    }
}
