using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelLayer : UILayerController<UIScreenController>
{
    [Header("Screens")]
    [SerializeField] UIScreenController _infoScreen;
    private void Start()
    {
        _screenControllers.Add(_infoScreen.GetId(), _infoScreen);
    }
    public override void HideScreen(UIScreenController screen)
    {
        _screenControllers[screen.GetId()].Hide();
    }

    public override void ShowScreen(UIScreenController screen)
    {
        _screenControllers[screen.GetId()].Show();
    }

    public override void ShowScreen<P>(UIScreenController screen, P properties)
    {
        _screenControllers[screen.GetId()].Show(properties);
    }
}
