using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int value = 1;

    public int Value 
    { 
        get => value; 
        set => this.value = value; 
    
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
