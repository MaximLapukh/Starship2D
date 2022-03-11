using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Ship")]
public class ShipData : ScriptableObject
{
    public float Speed;
    public float Acceleration;
    public float SpeedRotation;
}
