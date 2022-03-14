using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDamagable, IObjectScreen
{
    [Header("Base")]
    [SerializeField] MoveData _moveData;

    [Header("Decay")]
    [SerializeField] List<GameObject> _decayObjects;

    private List<ActivityBase<Transform>> _activities;
    private MoveInDirection _moveinDirection;
    private Decay _decay;

    private void Awake()
    {
        _activities = new List<ActivityBase<Transform>>();

        _moveinDirection = new MoveInDirection(transform);
        _activities.Add(_moveinDirection);

        _decay = new Decay(transform, _decayObjects);
        _activities.Add(_decay);

        //bad look
        transform.rotation = ScreenCoordinator2D.GetRndAngels(0, 359, new Vector3(0, 0, 1));
    }
    public void Init(ScreenCoordinator2D screenCoordinator)
    {
        screenCoordinator.LookToCenter(transform, new Vector3(0, 90, 0));
        transform.rotation *= ScreenCoordinator2D.GetRndAngels(0, 90, new Vector3(0, 0, 1));
    }
    void Start()
    {
        _moveinDirection.SetDirection(Vector3.up);
        _moveinDirection.SetSpeed(_moveData.Speed);
        _moveinDirection.SetAcceleration(_moveData.Acceleration);

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
    public void Hit()
    {
        _decay.DecayOnObjects();
        Destroy(gameObject);        
    }


}
