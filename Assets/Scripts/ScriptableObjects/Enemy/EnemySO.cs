using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Enemy Type", fileName = "new Enemy Type")]

public class EnemySO : ScriptableObject
{
    [SerializeField] private string typeName;
    [SerializeField] private float maxHp;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private int exp;
    public string TypeName()
    {
        return typeName;
    }
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
    public int Exp()
    {
        return exp;
    }
}
