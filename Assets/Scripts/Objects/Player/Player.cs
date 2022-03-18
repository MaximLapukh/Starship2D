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

    [Header("Weapons")]
    [SerializeField] Transform _firePoint;
    [SerializeField] WeaponData _gunData;
    [SerializeField] LazerData _laserData;

    [Header("Events")]
    // thinks: disable input should place here
    public UnityEvent<InfoProperty> HadDead; 
    public UnityEvent<InfoProperty> HadUpdateInfo;

    private MoveInDirection _moveinDirection;
    private RegularRotate _regularRotate;
    private HealthCounter _healthCounter;
    private ScoreCounter _scoreCounter;

    private IWeapon<IBullet> _gun;
    private IWeapon<IBullet> _laser;

    private PlayerLogic _playerLogic;

    private new void Awake()
    {
        base.Awake();
        _playerLogic = new PlayerLogic();
    }
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

        var laser = new Lazer(transform, _firePoint, _laserData);
        _activities.Add(laser);
        _laser = laser;
    }
    protected override void Start()
    {
        _gun.HadBulletHit += AddScore;
        _laser.HadBulletHit += AddScore;

        _moveinDirection.SetSpeed(_moveData.Speed);
        _moveinDirection.SetAcceleration(_moveData.Acceleration);
        _regularRotate.SetSpeed(_moveData.SpeedRotation);

        base.Start();
    }
    protected override void Update()
    {
        HadUpdateInfo.Invoke(CollectProperties());
        base.Update();
    }

    private void AddScore(GameObject obj)
    {
        _playerLogic.AddScore(obj, _scoreCounter);
    }

    public void Hit(GameObject obj)
    {
        _playerLogic.Hit(obj, _healthCounter);
    }
    private void Dead()
    {
        _playerLogic.Dead(this);
        HadDead.Invoke(CollectProperties());
    }

    public void ChangeDirection(CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _playerLogic.ChangeDirection(direction, _regularRotate);
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
    //thinks: create class in every frame is bad solve
    private InfoProperty CollectProperties()
    {
        var infoProperty = new InfoProperty();
        infoProperty.Health = _healthCounter.GetHealth();
        infoProperty.Score = _scoreCounter.GetScore();
        infoProperty.Position = transform.position;
        infoProperty.ZAngle = transform.localEulerAngles.z;
        infoProperty.Speed = _moveinDirection.GetSpeed();
        infoProperty.CountLazers = _laser.GetCountBullets();
        infoProperty.ReloadLaser = _laser.GetReloadTime();
        infoProperty.RollbackLaser = ((Lazer)_laser).GetRollback();
        return infoProperty;
    }
}
