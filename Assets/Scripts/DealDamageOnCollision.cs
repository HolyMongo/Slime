using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<TakeDamage>().GetHit(5, transform.position, 4);
        }
    }
}
