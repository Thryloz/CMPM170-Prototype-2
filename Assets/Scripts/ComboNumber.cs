using TMPro;
using UnityEngine;

public class ComboNumber : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI highestComboText;

    private int comboCount = 0;

    private int highestCombo = 0;
    private void Start()
    {
        comboCount = 0;
        text.SetText("0");
    }

    private void OnEnable()
    {
        MovingTarget.OnTargetHit += UpdateCombo;
        Car.OnCarMiss += ResetCombo;
    }

    private void OnDisable()
    {
        MovingTarget.OnTargetHit -= UpdateCombo;
        Car.OnCarMiss -= ResetCombo;
    }

    private void UpdateCombo()
    {
        comboCount++;
        text.SetText(comboCount.ToString());

        if (comboCount > highestCombo)
        {
            highestCombo = comboCount;
            highestComboText.SetText(highestCombo.ToString());
        }
    }

    private void ResetCombo()
    {
        comboCount = 0;
        text.SetText(comboCount.ToString());
    }


}
