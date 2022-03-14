using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCoordinator2D
{
    public readonly float LeftX;
    public readonly float RightX;
    public readonly float UpY;
    public readonly float DownY;
    public readonly Vector2 Center;

    private Camera _camera;

    public ScreenCoordinator2D(Camera camera)
    {
        _camera = camera;

        var zeroPoint = _camera.ScreenToWorldPoint(Vector3.zero);
        LeftX = zeroPoint.x;
        DownY = zeroPoint.y;

        var highPoint = _camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight));
        RightX = highPoint.x;
        UpY = highPoint.y;
        
        Center = _camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2));
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

    public void LookToCenter(Transform transform, Vector3 correctAngels = new Vector3())
    {
        transform.LookAt(Center);
        transform.rotation *= Quaternion.Euler(correctAngels);
    }   
    //mb not should place here
    public static Quaternion GetRndAngels(float minAngle,float maxAngle, Vector3 axis)
    {
        axis.Normalize();
        var angles = Vector3.zero;

        angles.x = Random.Range(minAngle, maxAngle) * axis.x;
        angles.y = Random.Range(minAngle, maxAngle) * axis.y;
        angles.z = Random.Range(minAngle, maxAngle) * axis.z;

        return Quaternion.Euler(angles);
    }
}
