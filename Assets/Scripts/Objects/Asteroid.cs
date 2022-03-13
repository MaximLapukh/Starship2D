using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDamagable
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
    }
    void Start()
    {
        var randomDirection = Vector3.zero;

        _moveinDirection.SetDirection(randomDirection);
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
