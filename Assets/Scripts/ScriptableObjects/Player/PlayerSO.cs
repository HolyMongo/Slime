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
    [SerializeField] private int currentExp;
    [SerializeField] private bool canDubbleJump;

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

    public int CurrentExp()
    {
        return currentExp;
    }

    public bool CanDubbleJump()
    {
        return canDubbleJump;
    }

    public void ChangeCanDubbleJump(bool _value)
    {
        canDubbleJump = _value;
    }
    public void TakeDamage(float _Damage)
    {
        hp -= _Damage;
    }

    public void SetCurrentLvl(int _lvl)
    {
        lvl = _lvl;
    }

    public void SetCurrentExp(int _Exp)
    {
        currentExp = _Exp;
    }
}
