using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SimpleShootAndMele : MonoBehaviour
{
    PlayerSO playerSo;

    [SerializeField] GameObject bullet;
    [SerializeField] [Range(1, 50)] float speed = 10f;
    [SerializeField] GameObject rotatePoint;
    [SerializeField] GameObject meleOrigin;
    [SerializeField] Transform meleIdlePosition;
    [SerializeField] Transform meleAttackPosition;
    [SerializeField] GameObject sword;

    float meleDamage = 5;
    float RangeDamage = 5;

    float switchColdown; //So that you cant shoot and slash at the same time
    float shootColdown;
    float meleColdown;

    private BoxCollider2D meleRange;
    [SerializeField] private LayerMask enemyMask;

    [SerializeField] Camera playerCam;
    Vector3 mousePosition;
    Vector3 dir;
    Vector3 rot;

    GameObject enemy;

    [SerializeField] List<string> itemList;
    string currentItem;
    int currentIndex = 0;
    [SerializeField] KeyCode nextItem;
    [SerializeField] KeyCode previusItem;

    private void Start()
    {
        currentItem = itemList[0];
        playerSo = GetComponent<ChooseSOForTheWholeThing>().GetPlayerSO(0);
        meleRange = sword.GetComponent<BoxCollider2D>();
        meleOrigin.SetActive(false);
        sword.SetActive(false);
    }

    private void Update()
    {
        switchColdown -= Time.deltaTime;
        meleColdown -= Time.deltaTime;
        shootColdown -= Time.deltaTime;

        mousePosition = playerCam.ScreenToWorldPoint(Input.mousePosition);
        rot = mousePosition - transform.position;
        float rotz = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
        rotatePoint.transform.rotation = Quaternion.Euler(0, 0, rotz);

        if (Input.GetKeyDown(nextItem))
        {
            if (currentIndex < itemList.Count - 1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
            currentItem = itemList[currentIndex];
            if (currentItem == "Sword")
            {
                sword.SetActive(true);
            }
            else
            {
                sword.SetActive(false);
            }
        }

        if (Input.GetKeyDown(previusItem))
        {
            if (currentIndex != 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = itemList.Count - 1;
            }
            currentItem = itemList[currentIndex];
            if (currentItem == "Sword")
            {
                sword.SetActive(true);
            }
            else
            {
                sword.SetActive(false);
            }
        }



        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (sword.activeSelf && meleColdown <= 0)
            {
                sword.transform.position = meleAttackPosition.position;
                AttackMele();
            }
            else if(!sword.activeSelf && shootColdown <= 0)
            {
                shootColdown = playerSo.Attackspeed();
                switchColdown = 0.1f;
                Shoot();
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            sword.transform.position = meleIdlePosition.position;        
        }

        //if (Input.GetKey(KeyCode.Mouse0) && shootColdown < 0 && switchColdown < 0)
        //{
        //    shootColdown = playerSo.Attackspeed();
        //    switchColdown = 0.1f;
        //    Shoot();
        //}

        //if (Input.GetKey(KeyCode.Mouse1))
        //{
        //    meleColdown = playerSo.Attackspeed();
        //    switchColdown = 0.1f;
        //    Mele();
        //}


        //if (Input.GetKey(KeyCode.Mouse1) && meleColdown < 0 && switchColdown < 0)
        //{
        //    meleColdown = playerSo.Attackspeed();
        //    switchColdown = 0.1f;
        //    Mele(); 
        //}
    }

    private void Shoot()
    {
        mousePosition = playerCam.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePosition - transform.position;
        GameObject bulletClone = GameObject.Instantiate(bullet, transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x, dir.y).normalized * speed;
        bulletClone.GetComponent<PlayerBullet>().ChangeSO(playerSo);
    }
    private void AttackMele()
    {
        meleColdown = 1;
        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(sword.transform.position.x, sword.transform.position.y), new Vector2(meleRange.bounds.extents.x, meleRange.bounds.extents.y), 0, Vector2.down, 1, enemyMask);
        if (hit != false)
        {
            enemy = hit.transform.gameObject;
            if (enemy != null)
            {
                Debug.Log(enemy);
                enemy.GetComponentInParent<EnemyTakeAndDealDamage>().TakeDamage(meleDamage);
                Debug.Log("Hit Enemy");
            }
        }
    }
    /*
    private void Mele()
    {
        mousePosition = playerCam.ScreenToWorldPoint(Input.mousePosition);
        rot = mousePosition - transform.position;
        float rotz = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;

       

       
        if (transform.localScale.x >= 0)
        {
            rotatePoint.transform.rotation = Quaternion.Euler(0, 0, rotz);
        }
        else
        {
            rotatePoint.transform.rotation = Quaternion.Euler(-1, 0, rotz);
        }
       

        meleOrigin.SetActive(true);
        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(meleOrigin.transform.position.x, meleOrigin.transform.position.y), new Vector2(meleRange.bounds.extents.x, meleRange.bounds.extents.y), 0, Vector2.down, 1, enemyMask);
        if (hit != false)
        {
            enemy = hit.transform.gameObject;
            if (enemy != null)
            {
                Debug.Log(enemy);
                enemy.GetComponent<EnemyTakeAndDealDamage>().TakeDamage(meleDamage);
                Debug.Log("Hit Enemy");
            }
        }
      //  StartCoroutine(waiter());
    }
    */
    IEnumerator waiter(float coldown)
    {
        yield return new WaitForSeconds(coldown - 0.5f);
       
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        collision.GetComponent<EnemyTakeAndDealDamage>().TakeDamage(meleDamage);
    //        Debug.Log("Hit Enemy!");
    //    }
    //}
}
