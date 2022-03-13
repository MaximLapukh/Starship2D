using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInScreenSides : SpawnerBase
{
    [SerializeField]
    protected Camera _camera;

    [Header("Sides")]
    [SerializeField] bool _leftSide;
    [SerializeField] bool _rightSide;
    [SerializeField] bool _upSide;
    [SerializeField] bool _downSide;

    private ScreenCoordinator2D _screenCoordinator;
    private void Awake()
    {
        _screenCoordinator = new ScreenCoordinator2D(_camera);
    }
    protected override void Spawn()
    {
        var sides = new List<Side>();
        AddSides(ref sides);

        Side side = sides[Random.Range(0, sides.Count - 1)];
        Vector3 position = GetPositionFromSide(side, _screenCoordinator);

        GameObject.Instantiate(_spawnerData.Prefab, position, Quaternion.Euler(Vector3.zero));
    }
    private void AddSides(ref List<Side> sides)
    {
        if (_leftSide) sides.Add(Side.left);
        if (_rightSide) sides.Add(Side.right);
        if (_upSide) sides.Add(Side.up);
        if (_downSide) sides.Add(Side.down);
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
enum Side
{
    left,
    right,
    up,
    down
}
