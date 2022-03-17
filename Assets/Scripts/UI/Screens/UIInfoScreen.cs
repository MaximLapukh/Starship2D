using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInfoScreen : UIScreenController
{
    [Header("Links")]
    [SerializeField] TextMeshProUGUI _textHealth;
    [SerializeField] TextMeshProUGUI _textScore;
    [SerializeField] TextMeshProUGUI _textPosition;
    [SerializeField] TextMeshProUGUI _textZAngle;
    [SerializeField] TextMeshProUGUI _textSpeed;
    [SerializeField] TextMeshProUGUI _textCountLazer;
    [SerializeField] TextMeshProUGUI _textReloadLazer; 
    [SerializeField] TextMeshProUGUI _textRollbackLazer; 
    public override string GetId()
    {
        return "Info";
    }
    public override void Show(IPropertyScreen property)
    {
        var infoProperty = (InfoProperty)property;
        _textHealth.text = infoProperty.Health.ToString();
        _textScore.text = infoProperty.Score.ToString();
        _textPosition.text = infoProperty.Position.ToString();
        _textZAngle.text = ((int)infoProperty.ZAngle).ToString();
        _textSpeed.text = Mathf.Ceil(infoProperty.Speed).ToString();
        _textCountLazer.text = infoProperty.CountLazers.ToString();
        _textReloadLazer.text = Mathf.Ceil(infoProperty.ReloadLaser).ToString();
        _textRollbackLazer.text = Mathf.Ceil(infoProperty.RollbackLaser).ToString();

        base.Show();
    }
  
}
