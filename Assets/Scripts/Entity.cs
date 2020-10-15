using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{ 
    // klasa związana z "HP" każdy obiekt posiadający "życie" musi posiadać te klase
    [SerializeField]
    int InitialHealth = 10;

    Animator animator;

    private int health;
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            if (animator != null)
            {
                if (animator.HasState(0, Animator.StringToHash("hit")))
                {
                    animator.SetBool("Damage", true);
                    animator.SetBool("Damage",false);
                }
            }

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
        animator = GetComponent<Animator>();
        Health = InitialHealth;
    }
}
