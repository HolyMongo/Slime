using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] PlayerSO playerso;
    GameObject player;
    Rigidbody2D rb;

    float dir;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void FixedUpdate()
    {
        dir = player.transform.position.x - transform.position.x;
        rb.velocity = new Vector2(dir, rb.velocity.y) * playerso.Speed();
    }
}
