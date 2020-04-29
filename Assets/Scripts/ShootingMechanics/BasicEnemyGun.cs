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
        transform.GetComponentInParent<Enemy>().onShoot += () =>
        {
            StartCoroutine(ShootByTime());
        };
    }

    IEnumerator ShootByTime()
    {
        System.Random random = new System.Random();
        float time = (float)(random.NextDouble() * (maxDuration - minDuration) + minDuration);
        yield return new WaitForSeconds(time);
        ShootBullet();
        
        


    }
    
}
