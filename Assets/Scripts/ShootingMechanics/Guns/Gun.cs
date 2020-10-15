using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    protected GameObject BulletPrefab; //posick jaki będzie wystrzelony

    [SerializeField]
    protected float BulletSpeed = 2f; // prędkość z jaką porusza się pocisk

    [SerializeField]
    bool shotDown = true;

    private int direction;

    void Start()
    {
       
        direction = shotDown ? -1 : 1;

    }

    protected virtual void ShootBullet()
    {
        var bullet = Instantiate(BulletPrefab); //tworzymy pocisk
        bullet.transform.position = transform.position; 
        bullet.transform.rotation = transform.rotation; // początkowa rotacja
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>(); //pobranie "ciała" pocisku
        bulletRigidbody.velocity= transform.right * BulletSpeed; //nadanie prędkości
    }
}
