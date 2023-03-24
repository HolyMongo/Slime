using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] EnemySO enemySo;
    GameObject player;
    Rigidbody2D rb;

    float dir;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        enemySo = GetComponent<ChooseSOForTheWholeThing>().GetEnemySO(0);
    }

    
    void FixedUpdate()
    {
        dir = player.transform.position.x - transform.position.x;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySo.Speed());
    }
}
