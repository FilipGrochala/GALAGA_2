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
            Debug.Log("Utworzono event");
            StartCoroutine(ShootByTime());
        };
    }


    protected virtual IEnumerator ShootByTime()
    {
        Debug.Log("Gotowy do strzału: " + GetComponentInParent<Enemy>().name);
        float time = Random.Range(minDuration, maxDuration);
        yield return new WaitForSeconds(time);
        ShootBullet();
        GetComponentInParent<Enemy>().GetComponentInParent<Formation>().WhoCanShoot();
    }
    
}
