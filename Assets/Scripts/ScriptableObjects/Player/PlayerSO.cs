using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/player stats", fileName = "new player stats")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] float maxHp;
    [SerializeField] float hp;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] float damage;
    [SerializeField] float attackspeed;

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
    public void TakeDamage(float _Damage)
    {
        hp -= _Damage;
    }
}
