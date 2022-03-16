using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UILayerController<TScreen> : MonoBehaviour where TScreen : IScreenController<IPropertyScreen>
{
    protected Dictionary<string, TScreen> _screenControllers = new Dictionary<string, TScreen>();
    public abstract void ShowScreen(TScreen screen);
    public abstract void ShowScreen<P>(TScreen screen, P properties) where P : IPropertyScreen;
    public abstract void HideScreen(TScreen screen);
    public virtual void HideAllScreens()
    {
        foreach (var screen in _screenControllers.Values)
        {
            screen.Hide();
        }
    }
}
