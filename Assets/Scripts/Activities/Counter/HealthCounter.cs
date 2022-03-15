using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : ActivityBase<Transform>
{
    public event Action HadZeroHealth = delegate { };

    private int _maxHealth;
    private int _health;
    public HealthCounter(Transform t, int maxHealth) : base(t)
    {
        _maxHealth = maxHealth;
        _health = _maxHealth;
    }
    public int GetHealth()
    {
        return _health;
    }
    public void LessHealth(int num)
    {
        _health -= num;

        if (_health <= 0)
        {
            _health = 0;
            HadZeroHealth.Invoke();
        }
    }
    public override void Update()
    {
    }
}
