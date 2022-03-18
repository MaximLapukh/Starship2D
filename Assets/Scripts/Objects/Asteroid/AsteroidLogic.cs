using System;
using UnityEngine;

internal class AsteroidLogic
{
    internal void Init(Transform transform, ScreenCoordinator2D screenCoordinator)
    {
        screenCoordinator.LookToCenter(transform, new Vector3(0, 90, 0));
        transform.rotation *= ScreenCoordinator2D.GetRndAngels(0, 90, new Vector3(0, 0, 1));
    }
    internal void Hit(GameObject obj, Decay decay, Action destroy)
    {
        if (!obj.TryGetComponent<LazerBullet>(out var lazer))
            decay.DecayOnObjects();

        destroy();
    }

    internal void SetRotation(Transform transform)
    {
        transform.rotation = ScreenCoordinator2D.GetRndAngels(0, 359, new Vector3(0, 0, 1));
    }

    internal void Crash(GameObject obj, GameObject gameObject, Action destroy)
    {
        if (obj.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.Hit(gameObject);
            destroy();
        }
    }
}
