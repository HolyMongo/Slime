using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSOForTheWholeThing : MonoBehaviour
{
   [SerializeField] private List<EnemySO> enemySO;
   [SerializeField] private List<PlayerSO> playerSO;
    [Header("Ignore this one")]
   [SerializeField] private List<ScriptableObject> SO;

    public EnemySO GetEnemySO(int _index)
    {
        return enemySO[_index];
    }
    public PlayerSO GetPlayerSO(int _index)
    {
        return playerSO[_index];
    }
    
    public ScriptableObject GetSO(int _index)
    {
        return SO[_index];
    }
}
