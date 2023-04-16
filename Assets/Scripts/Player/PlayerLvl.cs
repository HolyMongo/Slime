using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLvl : MonoBehaviour, IDataPersistence
{
    private PlayerSO playerSo;
    [SerializeField] HealthBar lvlHealthbar;

    private int currentLvl;
    private int expToLvlUp = 100;
    private int currentExp;
    private float lvlScaling = 1.12f;

    void Start()
    {
        playerSo = GetComponent<ChooseSOForTheWholeThing>().GetPlayerSO(0);
        currentLvl = playerSo.Lvl();
        expToLvlUp *= Mathf.FloorToInt(Mathf.Pow(lvlScaling, currentLvl));
        currentExp = playerSo.CurrentExp();
        lvlHealthbar.SetMaxValue(expToLvlUp);
        lvlHealthbar.SetValue(currentExp);
        lvlHealthbar.AdjustTextAboveBar("LVL:v " + currentLvl);
    }

    public void AddExp(int _exp)
    {
        if (currentExp + _exp < expToLvlUp)
        {
            currentExp += _exp;
        }
        else
        {
            while (currentExp + _exp >= expToLvlUp)
            {
                _exp -= expToLvlUp - currentExp;
                currentLvl++;
                currentExp = 0;
                expToLvlUp = Mathf.FloorToInt(expToLvlUp * lvlScaling);
            }
            currentExp += _exp;
        }
        playerSo.SetCurrentExp(currentExp);
        playerSo.SetCurrentLvl(currentLvl);
        lvlHealthbar.SetValue(currentExp);
        lvlHealthbar.SetMaxValue(expToLvlUp);
        lvlHealthbar.AdjustTextAboveBar("LVL:v " + currentLvl);
        DataPersistenceManager.Instance.SaveGame();
    }

    public int GetCurrentExp()
    {
        return currentExp;
    }

    public int GetExpRequired()
    {
        return expToLvlUp;
    }
    public int GetLvl()
    {
        return currentLvl;
    }

    public void LoadData(GameData data) 
    {
        this.currentLvl = data.currentLvl;
        this.currentExp = data.currentExp;
    }
    public void SaveData(ref GameData data)
    {
        data.currentLvl = this.currentLvl;
        data.currentExp = this.currentExp;
    }
}
