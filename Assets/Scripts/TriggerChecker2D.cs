using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CollectionBase))]
public class TriggerChecker2D : MonoBehaviour
{
    public UnityEvent<IDamagable> HadDamagable;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            HadDamagable.Invoke(damagable);

        }
    }
}
