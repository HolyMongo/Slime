using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthBar : MonoBehaviour
{
    private EnemySO enemySo;
    private EnemyTakeAndDealDamage enemyHealth;

    [SerializeField] private Slider slider;

    [SerializeField] TextMeshProUGUI barText;
    [SerializeField] TextMeshProUGUI textAboveTheBar;

    private void Start()
    {
        enemySo = GetComponent<ChooseSOForTheWholeThing>().GetEnemySO(0);
        enemyHealth = GetComponent<EnemyTakeAndDealDamage>();

        slider.maxValue = enemySo.MaxHp();
        slider.value = slider.maxValue;
        barText.text = slider.value + "/" + slider.maxValue;
        textAboveTheBar.text = enemySo.TypeName();
    }

    public void TakeDamage(float _damage)
    {
        slider.value -= _damage;
        barText.text = slider.value + "/" + slider.maxValue;
    }
}
