using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputEvent : MonoBehaviour
{
    [SerializeField] InputAction _inputAction;
    public UnityEvent<CallbackContext> HadAction;
    void Start()
    {
        _inputAction.started += HadAction.Invoke;
        Enable();
    }
    public void Disable()
    {
        _inputAction.Disable();
    }
    public void Enable()
    {
        _inputAction.Enable();
    }
}
