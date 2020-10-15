using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : BasicEnemyGun
{
      
    protected override void ShootBullet()
    {
        var bullet = Instantiate(BulletPrefab);
        bullet.transform.position = transform.position;
       

    }
}
