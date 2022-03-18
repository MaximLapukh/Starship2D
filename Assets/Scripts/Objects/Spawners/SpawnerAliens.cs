using UnityEngine;

public class SpawnerAliens : ObjectBehaviour
{
    [Header("Base")]
    [SerializeField] SpawnData _spawnData;
    
    [Header("Links")]
    [SerializeField] Transform _target;
    [SerializeField] Camera _camera;

    private SpawnFollower<Alien> _spawner;
    protected override void InitActivities()
    {
        _spawner = new SpawnFollower<Alien>(transform, _spawnData, _target, _camera);
        _activities.Add(_spawner);
    }
}
