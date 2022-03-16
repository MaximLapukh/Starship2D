using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : ObjectBehaviour, IObjectScreen, IDamagable
{
    [Header("Base")]
    [SerializeField] MoveData _moveData;

    [Header("Weapons")]
    [SerializeField] Transform _firePoint;
    [SerializeField] float _fireRate;
    [Header("Gun")]
    [SerializeField] WeaponData _gunData;
    [SerializeField] int _startCountBulletGun;

    private MoveInDirection _moveinDirection;
    private CallbackOverTime _callback;
    private IWeapon<IBullet> _gun;

    protected override void InitActivities()
    {
        _moveinDirection = new MoveInDirection(transform);
        _activities.Add(_moveinDirection);

        _callback = new CallbackTimeInfinite(transform, _fireRate, Fire);
        _activities.Add(_callback);

        var gun = new Gun(transform, _firePoint, _gunData);
        _activities.Add(gun);
        _gun = gun;
    }

    public void Init(ScreenCoordinator2D screenCoordinator)
    {
        if (transform.position.x >= screenCoordinator.Center.x)
        {
            _moveinDirection.SetDirection(Vector3.left);

        }
        else if(transform.position.x < screenCoordinator.Center.x)
        {
            _moveinDirection.SetDirection(Vector3.right);

        }
    }

    protected override void Start()
    {
        _moveinDirection.SetSpeed(_moveData.Speed);
        _moveinDirection.SetAcceleration(_moveData.Acceleration);

        _gun.SetMaxCountBullets(_startCountBulletGun);

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
        //other logic about Destroy
        Destroy(gameObject);
    }
}
