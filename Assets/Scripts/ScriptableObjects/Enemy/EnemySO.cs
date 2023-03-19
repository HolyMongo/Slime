using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Enemy Type", fileName = "new Enemy Type")]

public class EnemySO : ScriptableObject
{
    [SerializeField] string typeName;
    [SerializeField] float maxHp;
    [SerializeField] float speed;
    [SerializeField] float damage;

    public float MaxHp()
    {
        return maxHp;
    }
    public float Speed()
    {
        return speed;
    }
    public float Damage()
    {
        return damage;
    }
}
