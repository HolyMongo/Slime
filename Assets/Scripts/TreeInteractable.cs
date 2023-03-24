using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteractable : MonoBehaviour
{
    public int damage = 1;
    public int health = 5;
    public GameObject prefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Collision");
            TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking Damage");
        this.health -= damage;

        if (health <= 0)
        {
            Instantiate(prefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
