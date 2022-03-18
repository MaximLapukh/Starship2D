using System;
using UnityEngine;

internal class PlayerLogic
{
    internal void Hit(GameObject obj, HealthCounter healthCounter)
    {
        healthCounter.LessHealth(1);
    }

    internal void ChangeDirection(Vector2 direction, RegularRotate regularRotate)
    {
        var directionValid = new Vector3(0, 0, direction.x * -1);
        regularRotate.SetDirection(directionValid);
    }

    internal void AddScore(GameObject obj, ScoreCounter scoreCounter)
    {
        scoreCounter.AddScore(1);
    }

    internal void Dead(Player player)
    {
        player.StopAllActivities();
    }
}
