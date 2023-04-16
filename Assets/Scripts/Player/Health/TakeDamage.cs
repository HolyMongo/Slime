using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private PlayerSO playerso;
    private float hp;
    private float maxHp;
  //  public static int deathCount = 0;
    private Rigidbody2D rb;
    private BasicMovement bm;

    private bool invulnerable = false;

    [SerializeField] private HealthBar healthBar;
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
            healthBar.SetMaxValue(maxHp);
            healthBar.SetValue(hp);
        }
    }

    public void Heal(float _hp)
    {
        hp += _hp;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        healthBar.SetMaxValue(maxHp);
        healthBar.SetValue(hp);
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

            //When health reaches 0
            if(hp <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);                        
               // PlayerStatsController.Instance.UpdateHealthText();

            }
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
