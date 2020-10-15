using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{ 
    // klasa związana z "HP" każdy obiekt posiadający "życie" musi posiadać te klase
    [SerializeField]
    int InitialHealth = 10;


    private int health;
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;

            if (health <= 0)
                health = 0;

            if (OnHealthChanged != null)
                OnHealthChanged.Invoke(health);

            if (health == 0)
            {
                if (OnKilled != null)
                    OnKilled.Invoke();

                Destroy(gameObject);
            }
        }
    }

    public event Action<int>OnHealthChanged;
    public event Action OnKilled;
    
    void Start()
    {
        Health = InitialHealth;
    }
}
