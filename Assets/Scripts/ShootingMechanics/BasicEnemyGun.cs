using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyGun : Gun
{
    [SerializeField]
    float minDuration = 1;
    [SerializeField]
    float maxDuration = 5;
    

    

    void Start()
    {
        StartCoroutine(ShootByTime());
    }

    IEnumerator ShootByTime()
    {
        System.Random random = new System.Random();

        while (true)
        {
            float time = (float)(random.NextDouble() * (maxDuration - minDuration) + minDuration);
            ShootBullet();
            yield return new WaitForSeconds(time);
        }


    }
    
}
