using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //private Renderer material;
    //bool isDissolving = false;
    //float fade = 1f;
    //[SerializeField] private float speed = 0.001f;
    //void Start()
    //{
    //   fade = 1f;
    //    material = GetComponent<Renderer>();
    //}
    //private void Update()
    //{
    //    isDissolving = true;
    //    if (isDissolving)
    //    {
    //        fade -= speed * Time.deltaTime;

    //        if (fade <= 0f)
    //        {
    //            fade = 1f;
    //            isDissolving = false;
    //            Destroy(gameObject);
    //        }
    //        material.material.SetFloat("_Fade", fade);
    //    }
    //}

    //Will use later when we fix an inventory system
    public Items item;

    public Items GiveItem()
    {
        Destroy(gameObject);
        return item;
    }
}
