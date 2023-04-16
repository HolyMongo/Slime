using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    private PlayerSO playerSo;
    private PlayerLvl playerLvl;
    [SerializeField] private Slider slider;

    [SerializeField] TextMeshProUGUI barText;
    [SerializeField] TextMeshProUGUI textAboveTheBar;

    [SerializeField] private TypeOfBar typeOfBar;

    enum TypeOfBar
    {
        Health,
        Lvl
    }

    void Start()
    {
        playerSo = GetComponent<ChooseSOForTheWholeThing>().GetPlayerSO(0);
        if (typeOfBar == TypeOfBar.Health)
        {
            slider.maxValue = playerSo.MaxHp();
            slider.value = playerSo.Hp();
        }
        barText.text = slider.value + "/" + slider.maxValue;
    }

    public void TakeDamage(float _damage)
    {
        slider.value -= _damage;
        barText.text = slider.value + "/" + slider.maxValue;
    }

    public void AddXpOrHealth(int _value)
    {
        slider.value += _value;
        barText.text = slider.value + "/" + slider.maxValue;
    }

    public void SetValue(float _value)
    {
        slider.value = _value;
        barText.text = slider.value + "/" + slider.maxValue;
    }

    public void SetMaxValue(float _maxValue)
    {
        slider.maxValue = _maxValue;
        barText.text = slider.value + "/" + slider.maxValue;
    }

    public void AdjustTextAboveBar(string _newText)
    {
        textAboveTheBar.text = _newText;
    }
}
