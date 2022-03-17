using System.Collections;
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

    //bad look
    private new void Awake()
    {
        base.Awake();
        
        transform.rotation = ScreenCoordinator2D.GetRndAngels(0, 359, new Vector3(0, 0, 1));
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
        screenCoordinator.LookToCenter(transform, new Vector3(0, 90, 0));
        transform.rotation *= ScreenCoordinator2D.GetRndAngels(0, 90, new Vector3(0, 0, 1));
    }
    protected override void Start()
    {
        _moveinDirection.SetDirection(Vector3.up);
        _moveinDirection.SetSpeed(_moveData.Speed);
        _moveinDirection.SetAcceleration(_moveData.Acceleration);

        base.Start();
    }
    public void Hit()
    {
        _decay.DecayOnObjects();
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
}
