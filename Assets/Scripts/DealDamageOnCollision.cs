using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnCollision : MonoBehaviour
{

    private GameObject player;
    private bool isColliding = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player = collision.collider.gameObject;
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    private void FixedUpdate()
    {
        if (isColliding)
        {
            player.GetComponent<TakeDamage>().GetHit(5, transform.position, 0);
        }
    }

    
}
