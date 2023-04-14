using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    private PlayerSO playerSo;
    [SerializeField] private Slider slider;

    [SerializeField] TextMeshProUGUI hpText;


    void Start()
    {
        playerSo = GetComponent<ChooseSOForTheWholeThing>().GetPlayerSO(0);
        slider.maxValue = playerSo.MaxHp();
        slider.value = playerSo.Hp();
        hpText.text = slider.value + "/" + slider.maxValue;
    }

    public void TakeDamage(float _damage)
    {
        slider.value -= _damage;
        hpText.text = slider.value + "/" + slider.maxValue;
    }

    public void SetMaxHealth(float _maxHealth)
    {
        slider.maxValue = _maxHealth;
        hpText.text = slider.value + "/" + slider.maxValue;
    }
}
