using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleGun : BasicEnemyGun
{
    
    [SerializeField]
    int angle = 30;

 
    protected override void ShootBullet()
    {
        
        int startAngle = (angle / 2) * -1;
        int endAngle = (angle / 2);
        int rotation = 0;
        for (int i = 0; i < 3; i++)
        {
            var bullet = Instantiate(BulletPrefab); //tworzymy pocisk
            bullet.transform.position = transform.position; //początkowa pozycja

            switch (i)
            {
                case 0:
                    rotation = startAngle;
                    break;
                case 1:
                    rotation = 0;
                    break;
                case 2:
                    rotation = endAngle;
                    break;
            }

            bullet.transform.position = transform.position; //początkowa pozycja
            transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rotation);
            var bulletRigidbody = bullet.GetComponent<Rigidbody2D>(); //pobranie "ciała" pocisku
            bulletRigidbody.velocity = transform.right * BulletSpeed; //nadanie prędkości
        }

            transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 90);
            
    }
}
