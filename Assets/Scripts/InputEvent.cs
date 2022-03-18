using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputEvent : MonoBehaviour
{
    [Header("Action")]
    [SerializeField] InputAction _inputAction;
    [Header("Event")]
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
