using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyGun : Gun
{
    System.Random random = new System.Random();

    void Start()
    {
        StartCoroutine(ShootByTime());
    }

    IEnumerator ShootByTime()
    {
        while (true)
        {
            float time = (float)(random.NextDouble() * (2 - 0.3) + 0.3);
            ShootBullet();
            yield return new WaitForSeconds(time);
        }


    }
    
}
