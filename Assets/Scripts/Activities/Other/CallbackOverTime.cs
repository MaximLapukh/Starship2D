using System;
using UnityEngine;

public class CallbackOverTime : ActivityBase<Transform>
{
    protected float _duration;
    protected float _timer;
    private bool _isProcessing;

    protected Action _callback;

    public CallbackOverTime(Transform t) : base(t)
    {

    }
    public CallbackOverTime(Transform t, float duration, Action callback): base (t)
    {
        _duration = duration;
        _timer = _duration;
        _callback = callback;
    }
    public void InvokeCallback(float duration, Action callback)
    {
        _duration = duration;
        _timer = _duration;
        _callback = callback;
        _isProcessing = true;
    }
    public bool GetIsProcessing()
    {
        return _isProcessing;
    }
    public override void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;

        }
        
        if (_timer < 0)
        {
            _isProcessing = false;
            _callback.Invoke();
            _timer = 0;
        }
    }
}
