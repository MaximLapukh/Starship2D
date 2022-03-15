using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIScreenController : MonoBehaviour, IScreenController<IPropertyScreen>
{
    [SerializeField]
    protected GameObject _window;
    protected string _id;
    protected bool _active;
    public bool GetActive()
    {
        return _active;
    }

    public string GetId()
    {
        return _id;
    }
    public virtual void Show()
    {
        _active = true;
        _window.SetActive(_active);
    }
    public abstract void Show(IPropertyScreen property);
    public virtual void Hide()
    {
        _active = false;
        _window.SetActive(_active);
    }


}
