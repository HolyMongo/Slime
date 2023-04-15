using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingEnemy : MonoBehaviour
{
    private EnemySO enemySo;

    [SerializeField] private bool IsMele;

    private float damage;
    private float health;

    private float bulletSpeed = 5f;
    private float decendingSpeed = 15f;

    private GameObject player;
    [SerializeField] private GameObject bullet;

    [SerializeField] Transform startPosition;
    [SerializeField] Transform endPosition;

    [SerializeField] private GameObject GFXAndAttack;
    [SerializeField] private GameObject bulletExitAndDirection;

    private bool inRange = false;
    private bool isBackInStartPosition;

    private void Start()
    {
        enemySo = GetComponent<ChooseSOForTheWholeThing>().GetEnemySO(0);
        damage = enemySo.Damage();
        health = enemySo.MaxHp();
        Debug.Log("Startded");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
            player = collision.gameObject;
            if (IsMele)
            {
                //Dont use mele...for now
                /*
                //GFXAndAttack.GetComponent<Rigidbody2D>().MovePosition(player.transform.position);
                InvokeRepeating("MoveUpAndDown", 0f, 5f);
                GFXAndAttack.transform.position = Vector2.MoveTowards(GFXAndAttack.transform.position, endPosition.position, Vector2.Distance(startPosition.position, endPosition.position)).normalized * decendingSpeed;
                */
            }
            else if (!IsMele)
            {
                GameObject bulletClone = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
                bulletClone.GetComponent<EnemyBullet>().ChangeEnemySo(enemySo);
                bulletClone.SetActive(true);
                bulletClone.GetComponent<Rigidbody2D>().velocity = bulletExitAndDirection.transform.forward.normalized * bulletSpeed;

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
