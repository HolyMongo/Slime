using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introLittleSlimeForce : MonoBehaviour
{
    public float Force = 5f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Force * Time.deltaTime, 0, 0);
        if(transform.position.x > 15)
        {
            transform.position = new Vector2(-15, transform.position.y);
        }
    }
}
