using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeAndDealDamage : MonoBehaviour
{
    [SerializeField] EnemySO enemyso;
    float speed;
    float damage;
    float hp;
    float maxHp;
    void Start()
    {
        speed = enemyso.Speed();
        damage = enemyso.Damage();
        maxHp = enemyso.MaxHp();
        hp = maxHp;
    }

    public void TakeDamage(float _dmg)
    {
        hp -= _dmg;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<TakeDamage>().GetHit(damage);
        }
    }
    void Update()
    {
        
    }
}
