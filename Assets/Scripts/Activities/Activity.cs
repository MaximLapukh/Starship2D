using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activity<T>
{
    protected T _t;
    public Activity(T t)
    {
        _t = t;
    }
    public void Start() { }
    public abstract void Update();
}
