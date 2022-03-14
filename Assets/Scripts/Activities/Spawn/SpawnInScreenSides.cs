using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInScreenSides<TObject> : SpawnerBase where TObject : MonoBehaviour, IObjectScreen
{

    private List<Side> _sides;
    private ScreenCoordinator2D _screenCoordinator;
    public SpawnInScreenSides(Transform t, SpawnData spawnData, List<Side> sides, Camera camera) : base(t, spawnData)
    {
        _sides = sides;
        _screenCoordinator = new ScreenCoordinator2D(camera);
    }
    protected override void Spawn()
    {
        Side side = _sides[Random.Range(0, _sides.Count)];
        Vector3 position = GetPositionFromSide(side, _screenCoordinator);

        GameObject prefab = GameObject.Instantiate(_spawnData.Prefab, position, Quaternion.Euler(Vector3.zero));
        prefab.GetComponent<IObjectScreen>().Init(_screenCoordinator);
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
