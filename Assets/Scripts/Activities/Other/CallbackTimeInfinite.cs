using System;
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
        if (_timer <= 0) InvokeCallback(_duration, _callback); 
        base.Update();
    }
}
