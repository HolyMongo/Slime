using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBoost : MonoBehaviour
{
    private float speedBoostMultiplier = 2;
    private float lifeTime = 20;
    private BasicMovement bm;

    private void Start()
    {
        bm = GetComponent<BasicMovement>();
        bm.SetSpeedBoostTrue(speedBoostMultiplier);
    }

    public void RefreshLifeTime()
    {
        lifeTime = 20;
    }
    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            bm.SetSpeedBoostFalse(speedBoostMultiplier);
            Destroy(this);
        }
    }
}
