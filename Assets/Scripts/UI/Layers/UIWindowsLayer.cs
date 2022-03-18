using UnityEngine;

public class UIWindowsLayer : UILayerController<UIScreenController>
{
    [Header("Screens")]
    [SerializeField] UIScreenController _startScreen;
    [SerializeField] UIScreenController _overScreen;

    private void Awake()
    {
        _screenControllers.Add(_startScreen.GetId(), _startScreen);
        _screenControllers.Add(_overScreen.GetId(), _overScreen);
    }

    //use windows hierarchy in future
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
