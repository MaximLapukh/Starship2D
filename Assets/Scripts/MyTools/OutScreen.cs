using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//must have Sprite or Render component
public class OutScreen : MonoBehaviour
{
    public UnityEvent HadOut;

    private void OnBecameInvisible()
    {
        HadOut.Invoke();
    }

}