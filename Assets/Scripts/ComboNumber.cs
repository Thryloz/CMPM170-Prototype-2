using System;
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
    }

    private void OnDisable()
    {
        Target.OnTargetDestroy -= UpdateCombo;
    }

    private void UpdateCombo()
    {
        comboCount++;
        text.SetText(comboCount.ToString());
    }


}
    