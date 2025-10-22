using TMPro;
using UnityEngine;

public class ComboNumber : MonoBehaviour
{
    public TextMeshProUGUI text;

    private int comboCount = 0;

    private void Start()
    {
        comboCount = 0;
        text.SetText("0");
    }

    private void OnEnable()
    {
        Target.OnTargetDestroy += UpdateCombo;
        Car.OnCarMiss += ResetCombo;
    }

    private void OnDisable()
    {
        Target.OnTargetDestroy -= UpdateCombo;
        Car.OnCarMiss -= ResetCombo;
    }

    private void UpdateCombo()
    {
        comboCount++;
        text.SetText(comboCount.ToString());
    }

    private void ResetCombo()
    {
        comboCount = 0;
        text.SetText(comboCount.ToString());
    }


}
    