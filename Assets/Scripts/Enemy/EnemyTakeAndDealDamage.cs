using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeAndDealDamage : MonoBehaviour
{
    [SerializeField] private EnemySO enemySo;
    private float damage;
    private float hp;
    private float maxHp;
    private int exp;
    public GameObject prefab;
    public GameObject points;

    private Renderer material;
    private bool isDissolving = false;
    private float fade = 1f;

    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask attackLayer;
    void Start()
    {
        material = GetComponentInChildren<Renderer>();
        enemySo = GetComponent<ChooseSOForTheWholeThing>().GetEnemySO(0);
        damage = enemySo.Damage();
        maxHp = enemySo.MaxHp();
        hp = maxHp;
        exp = enemySo.Exp();
        InvokeRepeating("CheckAndAttack", 0f, 1f);
    }

    private void CheckAndAttack()
    {
        RaycastHit2D hit = Physics2D.CircleCast(new Vector2(transform.position.x, transform.position.y), attackRange, Vector2.down, 1f, attackLayer);
        if (hit != false)
        {
            GameObject player = hit.transform.gameObject;
            Vector2 attackDirection = gameObject.transform.position - player.transform.position;

            player.GetComponent<TakeDamage>().GetHit(damage, gameObject.transform.position, 4);
            Debug.Log("Hit player!");
        }
    }
    public void TakeDamage(float _dmg, PlayerLvl _playerlvl)
    {
        hp -= _dmg;
        if (hp <= 0)
        {
            isDissolving = true;                
            _playerlvl.AddExp(exp);
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
        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
                Instantiate(prefab, transform.position, Quaternion.identity);
                Instantiate(points, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }

            material.material.SetFloat("_Fade", fade);
        }
    }
}
