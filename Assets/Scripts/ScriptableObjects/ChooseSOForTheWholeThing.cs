using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSOForTheWholeThing : MonoBehaviour
{
   [SerializeField] List<EnemySO> enemySO;
   [SerializeField] List<PlayerSO> playerSO;
    [Header("Ignore this one")]
   [SerializeField] List<ScriptableObject> SO;

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
