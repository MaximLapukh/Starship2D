using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCoordinator
{
    public readonly float LeftX;
    public readonly float RightX;
    public readonly float UpY;
    public readonly float DownY;

    private Camera _camera;

    public ScreenCoordinator(Camera camera)
    {
        _camera = camera;

        var zeroPoint = _camera.ScreenToWorldPoint(Vector3.zero);
        LeftX = zeroPoint.x;
        DownY = zeroPoint.y;

        var highPoint = _camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight));
        RightX = highPoint.x;
        UpY = highPoint.y;
    }
    public void KeepInScreen(Transform transform)
    {
        var position = transform.position;
        if(transform.position.x < LeftX)
        {
            position.x = (RightX * 2) - Mathf.Abs(position.x);
        }
        if(transform.position.x > RightX)
        {
            position.x = Mathf.Abs(position.x) - (RightX * 2);
        }

        if (transform.position.y < DownY)
        {
            position.y = (UpY * 2) - Mathf.Abs(position.y);
        }
        if (transform.position.y > UpY)
        {
            position.y = Mathf.Abs(position.y) - (UpY * 2);
        }

        transform.position = position;
    }
}
