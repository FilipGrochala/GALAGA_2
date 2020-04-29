using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int value = 1;

    bool canShoot;

    public event Action onShoot;

    public int Value 
    { 
        get => value; 
        set => this.value = value; 
    
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
                onShoot.Invoke();

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
