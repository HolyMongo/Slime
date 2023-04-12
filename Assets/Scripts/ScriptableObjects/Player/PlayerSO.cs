using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/player stats", fileName = "new player stats")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] private float maxHp;
    [SerializeField] private float hp;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float damage;
    [SerializeField] private float attackspeed;
    [SerializeField] private int lvl;

    public float MaxHp()
    {
        return maxHp;
    }
    public float Hp()
    {
        return hp;
    }
    public float Speed()
    {
        return speed;
    }
    public float Damage()
    {
        return damage;
    }
    public float Attackspeed()
    {
        return attackspeed;
    }
    public float JumpPower()
    {
        return jumpPower;
    }

    public int Lvl()
    {
        return lvl;
    }
    public void TakeDamage(float _Damage)
    {
        hp -= _Damage;
    }
}
