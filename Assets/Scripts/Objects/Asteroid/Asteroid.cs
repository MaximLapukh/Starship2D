using System.Collections.Generic;
using UnityEngine;

public class Asteroid : ObjectBehaviour, IDamagable, IObjectScreen
{
    [Header("Base")]
    [SerializeField] MoveData _moveData;

    [Header("Decay")]
    [SerializeField] List<GameObject> _decayObjects;

    private MoveInDirection _moveinDirection;
    private Decay _decay;

    private AsteroidLogic _asteroidLogic;
    //bad look
    private new void Awake()
    {
        base.Awake();
        _asteroidLogic = new AsteroidLogic();
        _asteroidLogic.SetRotation(transform);
    }
    protected override void InitActivities()
    {
        _moveinDirection = new MoveInDirection(transform);
        _activities.Add(_moveinDirection);

        _decay = new Decay(transform, _decayObjects);
        _activities.Add(_decay);
    }

    public void Init(ScreenCoordinator2D screenCoordinator)
    {
        _asteroidLogic.Init(transform, screenCoordinator);
    }
    protected override void Start()
    {
        _moveinDirection.SetDirection(Vector3.up);
        _moveinDirection.SetSpeed(_moveData.Speed);
        _moveinDirection.SetAcceleration(_moveData.Acceleration);

        base.Start();
    }
    public void Hit(GameObject obj)
    {
        _asteroidLogic.Hit(obj, _decay, Destroy);    
    }
    public void Crash(GameObject obj)
    {
        _asteroidLogic.Crash(obj, gameObject, Destroy);
    }
    public void Destroy()
    {
        //execute logic about Destroy
        Destroy(gameObject);
    }
}
