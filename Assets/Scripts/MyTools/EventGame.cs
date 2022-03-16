using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventGame : MonoBehaviour
{
    public UnityEvent HadAwake;
    public UnityEvent HadStart;
    public UnityEvent HadOver;
    public UnityEvent HadRestart;
    void Start()
    {
        HadAwake.Invoke();
    }
    [ContextMenu("Play")]
    public void StartPlay()
    {
        HadStart.Invoke();
    }
    [ContextMenu("Over")]
    public void OverPlay()
    {
        HadOver.Invoke();
    } 
    [ContextMenu("Restart")]
    public void RestartPlay()
    {
        HadRestart.Invoke();
    }
}
