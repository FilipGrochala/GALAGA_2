﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    int damage=1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null || collision.GetComponent<Enemy>() != null)
            collision.GetComponent<Entity>().Health -= damage; //trafiono gracza lub przeciwnika
        Destroy(gameObject,0.2f);
    }
}