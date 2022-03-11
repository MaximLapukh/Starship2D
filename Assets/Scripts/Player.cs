using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    [SerializeField] ShipData _shipData;
    private List<Activity<Transform>> _activities;

    private MoveInDirection _moveinDirection;
    private RegularRotate _regularRotate;
    private void Awake()
    {
        _activities = new List<Activity<Transform>>();

        _moveinDirection = new MoveInDirection(transform);
        _activities.Add(_moveinDirection);

        _regularRotate = new RegularRotate(transform);
        _activities.Add(_regularRotate);

    }
    void Start()
    {
        _moveinDirection.SetSpeed(_shipData.Speed);
        _moveinDirection.SetAcceleration(_shipData.Acceleration);
        _regularRotate.SetSpeed(_shipData.SpeedRotation);

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
}
