using TMPro;
using UnityEngine;

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
