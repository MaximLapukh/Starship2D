using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIOverScreen : UIScreenController
{
    [Header("Links")]
    [SerializeField] TextMeshProUGUI _textScore;
    public override string GetId()
    {
        return "Over";
    }
    public override void Show(IPropertyScreen property)
    {
        var scoreProperty = (ScoreProperty)property;
        _textScore.text = scoreProperty.Score.ToString();

        base.Show();
    }
 
}
