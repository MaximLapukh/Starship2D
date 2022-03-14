using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallbackTimeInfinite : CallbackOverTime
{
    public CallbackTimeInfinite(Transform t) : base(t)
    {
    }
    public CallbackTimeInfinite(Transform t, float duration, Action callback) : base(t, duration, callback)
    {
    }

    public override void Update()
    {
        base.Update();

        if (_timer <= 0) _timer = _duration;
    }
}
