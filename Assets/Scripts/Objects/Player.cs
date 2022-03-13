using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] MoveData _moveData;
    [SerializeField] Camera _camera;

    [Header("Weapons")]
    [SerializeField] Transform _firePoint;
    [Header("Gun")]
    [SerializeField] WeaponData _gunData;
    [SerializeField] int _startCountBulletGun;
    [Header("Laser")]
    [SerializeField] WeaponData _laserData;
    [SerializeField] int _startCountBulletLaser;


    private List<ActivityBase<Transform>> _activities;
    private MoveInDirection _moveinDirection;
    private RegularRotate _regularRotate;

    private IWeapon _gun;
    private IWeapon _laser;
    private void Awake()
    {
        _activities = new List<ActivityBase<Transform>>();

        _moveinDirection = new MoveInDirScreen(transform, _camera);
        _activities.Add(_moveinDirection);

        _regularRotate = new RegularRotate(transform);
        _activities.Add(_regularRotate);

        var gun = new Weapon(transform, _firePoint, _gunData);
        _activities.Add(gun);
        _gun = gun;

        var laser = new Weapon(transform, _firePoint, _laserData);
        _activities.Add(laser);
        _laser = laser;

    }
    void Start()
    {
        _moveinDirection.SetSpeed(_moveData.Speed);
        _moveinDirection.SetAcceleration(_moveData.Acceleration);
        _regularRotate.SetSpeed(_moveData.SpeedRotation);

        _gun.SetCountBullets(_startCountBulletGun);
        _laser.SetCountBullets(_startCountBulletLaser);

        foreach (var item in _activities)
        {
            item.Start();
        }
    }

    void Update()
    {
        foreach (var item in _activities)
        {
            item.Update();
        }
    }
    public void ChangeDirection(CallbackContext context)
    {
        var temp = context.ReadValue<Vector2>();
        var direction = new Vector3(0, 0, temp.x * -1);
        _regularRotate.SetDirection(direction);
    }
    public void MoveForward(CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                _moveinDirection.SetDirection(Vector3.up);
                break;
            case InputActionPhase.Canceled:
                _moveinDirection.SetDirection(Vector3.zero);
                break;
        }
    }
    public void Fire(CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                _gun.Fire();
                break;
        }
    }
}
