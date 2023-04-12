using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLvl : MonoBehaviour
{
    private PlayerSO playerSo;

    private int currentLvl;
    private int expToLvlUp = 100;
    private int currentExp;
    private float lvlScaling = 1.05f;

    void Start()
    {
        playerSo = GetComponent<ChooseSOForTheWholeThing>().GetPlayerSO(0);
        currentLvl = playerSo.Lvl();
        expToLvlUp *= Mathf.FloorToInt(Mathf.Pow(lvlScaling, currentLvl));
    }

    public void AddExp(int _exp)
    {
        if (currentExp + _exp < expToLvlUp)
        {
            currentExp += _exp;
            Debug.Log("not enough exp to lvl up so we just add it");
        }
        else
        {
            Debug.Log("exp will be wasted if we just lvl up so we do thing");
            Debug.Log("current exp (before while): " + currentExp);
            while (currentExp + _exp >= expToLvlUp)
            {
                Debug.Log("iteration start");
                Debug.Log("exp to lvl up: " + expToLvlUp);
                Debug.Log("current exp: " + currentExp);
                _exp -= expToLvlUp - currentExp;
                Debug.Log("exp to lvl up: " + (expToLvlUp - currentExp));
                currentLvl++;
                Debug.Log("Reset current exp");
                currentExp = 0;
                Debug.Log("we add a lvl");
                Debug.Log("exp required to lvl up went from " + expToLvlUp + " to " + Mathf.FloorToInt(expToLvlUp * lvlScaling));
                expToLvlUp = Mathf.FloorToInt(expToLvlUp * lvlScaling);
                Debug.Log("iteration finnish");
            }
            Debug.Log("added exess exp");
            currentExp += _exp;
        }

    }


    public int GetLvl()
    {
        return currentLvl;
    }


}
