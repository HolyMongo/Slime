using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float lifeTime;
    PlayerSO playerso;

    void Start()
    {
        
    }

    public void ChangeSO(PlayerSO sO)
    {
        playerso = sO;
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyTakeAndDealDamage>().TakeDamage(playerso.Damage());
            Destroy(gameObject);
        }
    }
}
