using UnityEngine;

public abstract class SpawnerBase : ActivityBase<Transform>
{
    [Header("Base")]
    [SerializeField]
    protected SpawnData _spawnData;

    private float _timer;

    protected SpawnerBase(Transform t, SpawnData spawnData) : base(t)
    {
        _spawnData = spawnData;
    }

    public override void Update()
    {
        if (_timer <= 0)
        {
            Spawn();
            _timer = _spawnData.Rate;
        }
        else if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
    }
    protected abstract void Spawn();
}
