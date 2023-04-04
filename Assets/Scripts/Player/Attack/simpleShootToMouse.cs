using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleShootToMouse : MonoBehaviour
{
    [SerializeField] PlayerSO playerso;
    [SerializeField] GameObject bullet;
    [SerializeField][Range(1,50)] float speed = 10f;

    Camera playerCam;

    float coldown;

    Vector3 mousePosition;
    Vector3 dir;
    void Start()
    {
        playerso = GetComponent<ChooseSOForTheWholeThing>().GetPlayerSO(0);
        playerCam = GameObject.Find("Player Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        coldown -= Time.deltaTime;
        mousePosition = playerCam.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition = Input.mousePosition;

        if (Input.GetMouseButton(0) && coldown <= 0)
        {
            coldown = playerso.Attackspeed();
            dir = mousePosition - transform.localPosition;
            GameObject bulletClone = Object.Instantiate(bullet, transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x, dir.y).normalized * speed;
            bulletClone.GetComponent<PlayerBullet>().ChangeSO(playerso);
        }
    }
}
