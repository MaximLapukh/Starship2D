using UnityEngine;

public class ScoreCounter : ActivityBase<Transform>
{
    private int _score;
    public ScoreCounter(Transform t) : base(t)
    {

    }
    public int GetScore()
    {
        return _score;
    }
    public void AddScore(int score)
    {
        _score += score;
    }

    public override void Update()
    {

    }
}
