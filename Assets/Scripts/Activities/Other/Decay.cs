using System.Collections.Generic;
using UnityEngine;

public class Decay : ActivityBase<Transform>
{
    private List<GameObject> _decayObjects;
    public Decay(Transform t, List<GameObject> decayObjects) : base(t)
    {
        _decayObjects = decayObjects;
    }
    public void DecayOnObjects()
    {
        foreach (var item in _decayObjects)
        {
            GameObject.Instantiate(item, _t.position, _t.rotation);
        }
    }
    public override void Update() { }
}
