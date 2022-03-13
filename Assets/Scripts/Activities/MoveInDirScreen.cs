using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirScreen : MoveInDirection
{
    private ScreenCoordinator _screenCoordinator;
    public MoveInDirScreen(Transform transform, Camera camera) : base(transform)
    {
        _screenCoordinator = new ScreenCoordinator(camera);
    }

    public override void Update()
    {
        base.Update();
        _screenCoordinator.KeepInScreen(_t);
    }
}
