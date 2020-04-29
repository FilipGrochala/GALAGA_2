using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    protected GameObject BulletPrefab; //posick jaki będzie wystrzelony

    [SerializeField]
    protected float BulletSpeed = 2f;

    [SerializeField]
    protected Vector2 GunPosition;

    [SerializeField]
    protected bool shootDown;

    protected void ShootBullet()
    {
        int direction = shootDown ? -1 : 1;
        var bullet = Instantiate(BulletPrefab); //tworzymy pocisk
        bullet.transform.position = transform.position + (Vector3)GunPosition; //początkowa pozycja
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>(); //pobranie "ciała" pocisku
        bulletRigidbody.velocity = new Vector2(0, direction) * BulletSpeed; //nadanie prędkości
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
