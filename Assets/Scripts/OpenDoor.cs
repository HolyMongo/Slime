using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public Animator anim;
    public TMP_Text text;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.text = "Unlocked Door";

            anim.enabled = true;
            anim.Play("ButtonDoorPress");
            door.SetActive(false);
        }
    }
}
