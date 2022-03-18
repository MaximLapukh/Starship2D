using UnityEngine;

public class MoveInDirScreen : MoveInDirection
{
    private ScreenCoordinator2D _screenCoordinator;
    public MoveInDirScreen(Transform transform, Camera camera) : base(transform)
    {
        _screenCoordinator = new ScreenCoordinator2D(camera);
    }

    public override void Update()
    {
        base.Update();
        _screenCoordinator.KeepInScreen(_t);
    }
}
