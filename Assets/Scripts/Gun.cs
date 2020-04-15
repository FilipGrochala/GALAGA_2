using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPrefab;

    [SerializeField]
    float BulletSpeed = 2f;

    [SerializeField]
    Vector2 GunPosition;

    [SerializeField]
    int Limit=30;

    [SerializeField]
    float StandardDuration=3f;


    [SerializeField]
    float OverheatedDuration=6f;

    private int heat;
    public int Heat
    {
        get
        {
            return heat;
        }
        private set
        {
            heat = value;

            
            if (OnHeatChanged != null)
                OnHeatChanged.Invoke(Heat);

        }
    }

    public event System.Action<int> OnHeatChanged;
    


    void Start()
    {
        Heat = Limit;
        StartCoroutine(HeatCooldown());
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if(Heat!=0)
                ShootBullet();
    }

    private void ShootBullet()
    {
        var bullet = Instantiate(BulletPrefab);
        bullet.transform.position = transform.position + (Vector3)GunPosition;
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity =new Vector2(0,1) * BulletSpeed;
        Heat--;
    }

    IEnumerator HeatCooldown()
    {   while (true)
        {
            if (Heat == Limit)
            {
                yield return new WaitForSeconds(1f);
            }
            else if (Heat == 0)
            {
                yield return new WaitForSeconds(OverheatedDuration);
                Heat += 5;
            }
            else
            {
                Heat++;
                yield return new WaitForSeconds(StandardDuration);
            }
        }
    }



}
