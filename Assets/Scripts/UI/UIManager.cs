using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Layers")]
    [SerializeField] UILayerController<UIScreenController> _panel;
    [SerializeField] UILayerController<UIScreenController> _windows;

    [Header("Screens")]
    [SerializeField] UIScreenController _infoScreen;
    [SerializeField] UIScreenController _startScreen;
    [SerializeField] UIScreenController _overScreen;

    public void ShowInfo(InfoProperty info)
    {
        _panel.ShowScreen<InfoProperty>(_infoScreen, info);
    }

    public void ShowOver(ScoreProperty score)
    {
        _windows.ShowScreen<ScoreProperty>(_overScreen, score);
    }
    public void ShowStart()
    {
        _windows.ShowScreen(_startScreen);
    }
    public void HideStart()
    {
        _windows.HideScreen(_startScreen);
    }
    public void HideAllWindows()
    {
        _windows.HideAllScreens();
    }
}
