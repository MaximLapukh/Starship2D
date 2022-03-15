using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreScreen : UIScreenController
{
    [SerializeField] TextMeshProUGUI _textScore;
    private void Awake()
    {
        _id = "Score";
    }
    public override void Show(IPropertyScreen property)
    {
        var scoreProperty = (ScoreProperty)property;
        _textScore.text = scoreProperty.Score.ToString();

        base.Show();
    }
}
