using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] PlayerSO playerso;
    float hp;
    float maxHp;
    void Start()
    {
        playerso = GetComponent<ChooseSOForTheWholeThing>().GetPlayerSO(0);
        hp = playerso.Hp();
        maxHp = playerso.MaxHp();
    }

    public void GetHit(float _Dmg)
    {
        hp -= _Dmg;
    }
    void Update()
    {
        
    }
}
