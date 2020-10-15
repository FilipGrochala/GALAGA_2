using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BasicEnemyGun
{
    [SerializeField]
    int numberOfBullets = 4;

    [SerializeField]
    int angle = 120;

    protected override void ShootBullet()
    {
        float current_angle = (-1) * (angle / 2);
        float difference = angle / numberOfBullets;

        for(int i = 0; i < numberOfBullets; i++)
        {
            var bullet = Instantiate(BulletPrefab); //tworzymy pocisk
            bullet.transform.position = transform.position; //+ (Vector3)GunPosition; //początkowa pozycja
            

            transform.localEulerAngles = new Vector3(
                transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z + current_angle);

            bullet.transform.rotation = transform.rotation;
            current_angle += difference;

            bullet.GetComponent<Rigidbody2D>().velocity=transform.right *  BulletSpeed;
        }

        transform.localEulerAngles = new Vector3(
               transform.rotation.x,
               transform.rotation.y,
               0);
    }
}
