using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CollectionBase))]
public class TriggerChecker2D : MonoBehaviour
{
    [Header("Event")]
    public UnityEvent<GameObject> HadEnter;

    public void OnTriggerEnter2D(Collider2D other)
    {
        HadEnter.Invoke(other.gameObject);
    }
}
