using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivityBase<T>
{
    protected T _t;
    public ActivityBase(T t)
    {
        _t = t;
    }
    public void Start() { }
    public abstract void Update();
    public void Stop() { }
}
