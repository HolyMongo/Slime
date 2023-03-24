using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeAndDealDamage : MonoBehaviour
{
    [SerializeField] EnemySO enemySo;
    float damage;
    float hp;
    float maxHp;
    public GameObject prefab;
    public GameObject points;
    void Start()
    {
        enemySo = GetComponent<ChooseSOForTheWholeThing>().GetEnemySO(0);
        damage = enemySo.Damage();
        maxHp = enemySo.MaxHp();
        hp = maxHp;
    }

    public void TakeDamage(float _dmg)
    {
        hp -= _dmg;
        if (hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(prefab, transform.position, Quaternion.identity);
            Instantiate(points, transform.position, Quaternion.identity);
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
