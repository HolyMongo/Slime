using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownOfAbility : MonoBehaviour
{
    private PlayerSO playerSo;
    private SimpleShootAndMele shootAndMele;

    [SerializeField] TextMeshProUGUI cooldownTimerText;



    void Start()
    {
        playerSo = GetComponent<ChooseSOForTheWholeThing>().GetPlayerSO(0);
        shootAndMele = GetComponent<SimpleShootAndMele>();
    }

    private void Update()
    {
        if (shootAndMele.GetShootColdown() <= 0)
        {
            cooldownTimerText.text = "Ready";
            cooldownTimerText.color = Color.green;
        }
        else
        {
            cooldownTimerText.text = (Mathf.Round(shootAndMele.GetShootColdown()* 100.0f) * 0.01f).ToString();
            cooldownTimerText.color = Color.red;
        }
    }
}
