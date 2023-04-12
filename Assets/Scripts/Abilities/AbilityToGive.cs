using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityToGive : WhatAbility
{
    [SerializeField] ability abilityToGive;
    [SerializeField] Canvas canvas;
    [SerializeField] ContactFilter2D contactFilter;
    [SerializeField] List<Collider2D> collidedObjects = new List<Collider2D>(1);
    BoxCollider2D collider2d;
    [SerializeField] LayerMask layermask;

    private GameObject player;
    private bool isColliding;

    private void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isColliding = true;
            player = collision.collider.gameObject;
            canvas.enabled = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
        canvas.enabled = false;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(collider2d.bounds.extents.x, collider2d.bounds.extents.y), 0, Vector2.down, 1f, layermask);
        //collider2d.OverlapCollider(contactFilter, collidedObjects);
        //foreach (var o in collidedObjects)
        //{
        //    Debug.Log("Fork");
        //    OnCollided(o.gameObject);
        //}
        Debug.Log("HELLO");
        if (hit)
        {
            Debug.Log("THERE");
            OnCollided(hit.transform.gameObject);
        }
       
    }

    private void OnCollided(GameObject _collidedObject)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (abilityToGive == ability.dubbleJump)
            {
                if (_collidedObject.GetComponent<BasicMovement>())
                {
                    _collidedObject.GetComponent<BasicMovement>().SetDubbleJumpTrue();
                }
            }
            else if (abilityToGive == ability.speedBoost)
            {
                if (_collidedObject.GetComponent<BasicMovement>())
                {
                    if (!_collidedObject.GetComponent<speedBoost>())
                    {
                        _collidedObject.AddComponent<speedBoost>();
                    }
                    else
                    {
                        _collidedObject.GetComponent<speedBoost>().RefreshLifeTime();
                    }
                }
            }
            Destroy(this.gameObject);
        }
    }
}
