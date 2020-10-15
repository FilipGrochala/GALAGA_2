using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int price = 1;
    [SerializeField]
    int speed=10;

    bool canShoot = false;

    public event Action onShoot;

    public int Speed { get => speed; set => speed = value; }

    public int Price 
    { 
        get => price; 
        set => this.price = value; 
    
    }
    
    public bool CanShoot
    {
        get
        {
            return canShoot;
        }
        set
        {
            canShoot = value;


            if (value == true && onShoot != null)
            {
                
                onShoot.Invoke();
                canShoot = false;
            }

        }
    }

    void Start()
    {
        GetComponent<Entity>().OnKilled += () =>
        {
            DeleteFromList();
            Destroy(gameObject,0.5f);
    
        };
    }

    void DeleteFromList()
    {
        transform.GetComponentInParent<Formation>().enemies.Remove(this);
    }

   
   
}
