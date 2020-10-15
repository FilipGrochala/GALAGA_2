using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyGun : Gun
{
    [SerializeField]
    protected float minDuration = 1;
    [SerializeField]
    protected float maxDuration = 5;


    void Awake()
    {
        transform.GetComponentInParent<Enemy>().onShoot += () =>
        {
            StartCoroutine(ShootByTime());
        };
    }


    protected virtual IEnumerator ShootByTime()
    {
        float time = Random.Range(minDuration, maxDuration);
        yield return new WaitForSeconds(time);
        ShootBullet();
        GetComponentInParent<Enemy>().GetComponentInParent<Formation>().WhoCanShoot();
    }
    
}
