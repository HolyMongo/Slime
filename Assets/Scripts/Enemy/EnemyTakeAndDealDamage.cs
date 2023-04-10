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

    [SerializeField] float attackRange;
    [SerializeField] LayerMask attackLayer;
    void Start()
    {
        enemySo = GetComponent<ChooseSOForTheWholeThing>().GetEnemySO(0);
        damage = enemySo.Damage();
        maxHp = enemySo.MaxHp();
        hp = maxHp;
        InvokeRepeating("CheckAndAttack", 0f, 1f);
    }

    private void CheckAndAttack()
    {
        RaycastHit2D hit = Physics2D.CircleCast(new Vector2(transform.position.x, transform.position.y), attackRange, Vector2.down, 1f, attackLayer);
        if (hit != false)
        {
            GameObject player = hit.transform.gameObject;
            Vector2 attackDirection = gameObject.transform.position - player.transform.position;

            player.GetComponent<TakeDamage>().GetHit(damage);
            Debug.Log("Hit player!");
        }
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        collision.collider.GetComponent<TakeDamage>().GetHit(damage);
    //    }
    //}
    void Update()
    {
        
    }
}
