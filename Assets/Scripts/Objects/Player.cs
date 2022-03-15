using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : ObjectBehaviour, IDamagable
{
    [Header("Base")]
    [SerializeField] MoveData _moveData;
    [SerializeField] int _maxHealth;

    [Header("Links")]
    [SerializeField] Camera _camera;
    [SerializeField] UIManager _uiManager;


    [Header("Weapons")]
    [SerializeField] Transform _firePoint;
    [Header("Gun")]
    [SerializeField] WeaponData _gunData;
    [SerializeField] int _startCountBulletGun;
    [Header("Laser")]
    [SerializeField] WeaponData _laserData;
    [SerializeField] int _startCountBulletLaser;

    [Header("Event")]
    public UnityEvent HadDead;

    private MoveInDirection _moveinDirection;
    private RegularRotate _regularRotate;
    private HealthCounter _healthCounter;
    private ScoreCounter _scoreCounter;

    private IWeapon<IBullet> _gun;
    private IWeapon<IBullet> _laser;

    protected override void InitActivities()
    {
        _moveinDirection = new MoveInDirScreen(transform, _camera);
        _activities.Add(_moveinDirection);

        _regularRotate = new RegularRotate(transform);
        _activities.Add(_regularRotate);

        _healthCounter = new HealthCounter(transform, _maxHealth);
        _activities.Add(_healthCounter);
        _healthCounter.HadZeroHealth += Dead;

        _scoreCounter = new ScoreCounter(transform);
        _activities.Add(_scoreCounter);

        var gun = new Gun(transform, _firePoint, _gunData);
        _activities.Add(gun);
        _gun = gun;

        var laser = new Gun(transform, _firePoint, _laserData);
        _activities.Add(laser);
        _laser = laser;
    }
    protected override void Start()
    {
        HadDead.AddListener(StopAllActivities);
        _gun.HadHit += AddScore;
        _laser.HadHit += AddScore;

        _moveinDirection.SetSpeed(_moveData.Speed);
        _moveinDirection.SetAcceleration(_moveData.Acceleration);
        _regularRotate.SetSpeed(_moveData.SpeedRotation);

        _gun.SetCountBullets(_startCountBulletGun);
        _laser.SetCountBullets(_startCountBulletLaser);

        base.Start();
    }
    protected override void Update()
    {
        UpdateInfo();
        base.Update();
    }

    private void AddScore(GameObject hitObj)
    {
        //idea: add different score depends at hitObj in pattern like factory
        _scoreCounter.AddScore(1);
    }

    public void Hit()
    {
        _healthCounter.LessHealth(1);
    }
    private void Dead()
    {
        HadDead.Invoke();
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
    public void Fire2(CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                _laser.Fire();
                break;
        }
    }
    private void UpdateInfo()
    {
        var infoProperty = new InfoProperty();
        infoProperty.Health = _healthCounter.GetHealth();
        infoProperty.Score = _scoreCounter.GetScore();
        infoProperty.Position = transform.position;
        infoProperty.ZAngle = transform.localEulerAngles.z;
        infoProperty.Speed = 0;
        infoProperty.CountLazers = _laser.GetCountBullets();
        infoProperty.ReloadLaser = _laser.GetReloadTime();
        _uiManager.ShowInfo(infoProperty);
    }
}
