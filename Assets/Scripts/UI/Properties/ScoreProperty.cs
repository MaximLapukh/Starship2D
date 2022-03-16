using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreProperty : IPropertyScreen
{
    public int Score;
    public ScoreProperty()
    {

    }
    public ScoreProperty(int score)
    {
        Score = score;
    }
}
