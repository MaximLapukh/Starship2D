using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Layers")]
    [SerializeField] UILayerController<UIScreenController> _panel;

    [Header("Screens")]
    [SerializeField] UIScreenController _infoScreen;

    public void ShowInfo(InfoProperty info)
    {
        _panel.ShowScreen<InfoProperty>(_infoScreen, info);
    }

}
