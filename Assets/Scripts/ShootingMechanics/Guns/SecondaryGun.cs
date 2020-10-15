using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryGun : BasicEnemyGun
{
    float time;
    System.Random random;


    void Start()
    {

        random = new System.Random();
        StartCoroutine(ShootByTime());  
    }

    protected override IEnumerator ShootByTime()
    {

        while (true)
        {
            time = Random.Range(minDuration, maxDuration);
            yield return new WaitForSeconds(time);
            ShootBullet();
        }
    }
}
