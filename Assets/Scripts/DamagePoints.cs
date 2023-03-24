using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePoints : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        transform.Translate(0, _speed * Time.deltaTime, 0);
    }

}
