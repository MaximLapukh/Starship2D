using UnityEngine;
using UnityEngine.Events;

//must have Sprite or Render component
public class OutScreen : MonoBehaviour
{
    [Header("Event")]
    public UnityEvent HadOut;

    private void OnBecameInvisible()
    {
        HadOut.Invoke();
    }

}
