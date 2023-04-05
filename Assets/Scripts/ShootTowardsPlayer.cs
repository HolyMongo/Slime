using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsPlayer : MonoBehaviour
{
    private ScriptableObject So;
    [SerializeField] GameObject bullet;
    CircleCollider2D detectionRange;
    [SerializeField] Transform exitPoint;

    Transform player;
    AudioSource aD;

    void Start()
    {
        So = GetComponent<ChooseSOForTheWholeThing>().GetEnemySO(0);
        detectionRange = GetComponent<CircleCollider2D>();
        aD = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
            InvokeRepeating("ShootAtPlayer", 0f, 1f);
            detectionRange.radius = 10;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CancelInvoke("ShootAtPlayer");
            detectionRange.radius = 7;
        }
    }

    private void ShootAtPlayer()
    {
        Vector2 dir = player.position - exitPoint.position;
        GameObject bulletClone = Object.Instantiate(bullet, exitPoint.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
        bulletClone.SetActive(true);
        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x, dir.y).normalized * 5;
        aD.Play();
    }
}
