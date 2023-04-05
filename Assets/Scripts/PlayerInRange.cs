using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRange : MonoBehaviour
{
    CircleCollider2D Range;

    private AIPathController pathController;
    void Start()
    {
        Range = GetComponent<CircleCollider2D>();
        pathController = GetComponent<AIPathController>();
        pathController.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Range.radius = 20;
            pathController.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Range.radius = 15;
            pathController.enabled = false;
        }
    }


    void Update()
    {
        
    }
}
