using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]

public class Enemy : MonoBehaviour
{
    void Start()
    {
        GetComponent<Entity>().OnKilled += () =>
        {
            Destroy(gameObject,0.5f);
        };
    }

    
   
}
