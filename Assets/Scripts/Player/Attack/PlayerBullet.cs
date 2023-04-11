using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    private PlayerSO playerso;


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
            collision.GetComponentInParent<EnemyTakeAndDealDamage>().TakeDamage(playerso.Damage());
            Destroy(gameObject);
        }
    }
}
