using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    private EnemySO enemySo;

    public void ChangeEnemySo(EnemySO _enemySo)
    {
        enemySo = _enemySo;
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

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<TakeDamage>().GetHit(enemySo.Damage(), gameObject.transform.position, 2);
            Destroy(gameObject);
        }
    }
}
