using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private PlayerSO playerso;
    private float hp;
    private float maxHp;

    private Rigidbody2D rb;
    private BasicMovement bm;

    private bool invulnerable = false;

    private HealthBar healthBar;
    void Start()
    {
        playerso = GetComponent<ChooseSOForTheWholeThing>().GetPlayerSO(0);
        hp = playerso.Hp();
        maxHp = playerso.MaxHp();
        bm = GetComponent<BasicMovement>();
        rb = GetComponent<Rigidbody2D>();
        if (GetComponent<HealthBar>())
        {
            healthBar = GetComponent<HealthBar>();
        }
    }

    public void GetHit(float _Dmg, Vector2 _knockbakDirection, float _force)
    {
        if (!invulnerable)
        {
            invulnerable = true;
            hp -= _Dmg;
            bm.enabled = false;
            rb.velocity = ((Vector2)gameObject.transform.position - _knockbakDirection).normalized * _force;
            StartCoroutine(InvulnerabilityFrames());
            StartCoroutine(ToggleMovement());
            if (GetComponent<HealthBar>())
            {
                healthBar.TakeDamage(_Dmg);
            }
            //Add red color to player to make it more clear they took damage
        }
    }

    IEnumerator InvulnerabilityFrames()
    {
        yield return new WaitForSeconds(1f);
        invulnerable = false;
    }
    IEnumerator ToggleMovement()
    {
        yield return new WaitForSeconds(0.5f);
        bm.enabled = true;
    }
}
