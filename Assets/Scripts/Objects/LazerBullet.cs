using System;
using UnityEngine;

//I'm not adding the logic class here because this class is simple(<40 strings of code)
public class LazerBullet : ObjectBehaviour, IBullet
{
    public event Action<GameObject> HadHit = delegate { };

    private CallbackOverTime _callback;

    protected override void InitActivities()
    {
        _callback = new CallbackOverTime(transform);
        _activities.Add(_callback);
    }
    public void Init(Transform firePoint)
    {
        transform.SetParent(firePoint);
    }

    protected override void Start()
    {
        _callback.InvokeCallback(0.1f, Destroy);
        base.Start();
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    public void Crash(GameObject obj)
    {
        if (obj.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.Hit(gameObject);
            HadHit.Invoke(obj);
        }
    }
}
