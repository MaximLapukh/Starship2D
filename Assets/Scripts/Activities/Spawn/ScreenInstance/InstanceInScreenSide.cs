using UnityEngine;

internal class InstanceInScreenSide<TOBject> where TOBject : MonoBehaviour, IObjectScreen
{
    private ScreenCoordinator2D _screenCoordinator;
    internal InstanceInScreenSide(Camera camera)
    {
        _screenCoordinator = new ScreenCoordinator2D(camera);
    }
    internal TOBject Create(TOBject obj, Side side)
    {
        Vector3 position = GetPositionFromSide(side, _screenCoordinator);

        var screenObj = GameObject.Instantiate(obj.gameObject, position, Quaternion.Euler(Vector3.zero))
            .GetComponent<TOBject>();
        screenObj.Init(_screenCoordinator);

        return screenObj;
    }
    private Vector3 GetPositionFromSide(Side side, ScreenCoordinator2D screenCoordinator)
    {
        var position = Vector3.zero;

        switch (side)
        {
            case Side.left:
                position = new Vector3(screenCoordinator.LeftX,
                    Random.Range(screenCoordinator.DownY, screenCoordinator.UpY));
                break;
            case Side.right:
                position = new Vector3(screenCoordinator.RightX,
                    Random.Range(screenCoordinator.DownY, screenCoordinator.UpY));
                break;
            case Side.up:
                position = new Vector3(Random.Range(screenCoordinator.LeftX, screenCoordinator.RightX),
                    screenCoordinator.UpY);
                break;
            case Side.down:
                position = new Vector3(Random.Range(screenCoordinator.LeftX, screenCoordinator.RightX),
                  screenCoordinator.DownY);
                break;
            default:
                position = Vector3.zero;
                break;
        }
        return position;
    }
}
public enum Side
{
    left,
    right,
    up,
    down
}

