using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : ObjectBehaviour, IObjectScreen, IFollowable, IDamagable
{
    [Header("Base")]
    [SerializeField] MoveData _moveData;

    [Header("Weapons")]
    [SerializeField] Transform _firePoint;
    [SerializeField] float _fireRate;
    [SerializeField] WeaponData _gunData;

    private MoveInTarget _moveInTarget;
    private CallbackOverTime _callback;
    private IWeapon<IBullet> _gun;

    protected override void InitActivities()
    {
        _moveInTarget = new MoveInTarget(transform,  new Vector3(0, 1, 0));
        _activities.Add(_moveInTarget);

        _callback = new CallbackTimeInfinite(transform, _fireRate, Fire);
        _activities.Add(_callback);

        var gun = new Gun(transform, _firePoint, _gunData);
        _activities.Add(gun);
        _gun = gun;
    }

    //used to change direction
    public void Init(ScreenCoordinator2D screenCoordinator)
    {
    }

    protected override void Start()
    {
        _moveInTarget.SetSpeed(_moveData.Speed);

        base.Start();
    }

    private void Fire()
    {
        _firePoint.localRotation = ScreenCoordinator2D.GetRndAngels(0, 359, new Vector3(0, 0, 1));
        _gun.Fire();
    }
    public void Hit()
    {
        Destroy();
    }
    public void Crash(GameObject obj)
    {
        if (obj.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.Hit();
            Destroy();
        }
    }
    public void Destroy()
    {
        //execute logic about Destroy
        Destroy(gameObject);
    }

    public void SetTarget(Transform target)
    {
        _moveInTarget.SetTarget(target);
    }
}
