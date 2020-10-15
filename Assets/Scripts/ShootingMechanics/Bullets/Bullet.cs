using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    int damage = 1;
    [SerializeField]
    float deley = 4f;
    [SerializeField]
    bool isEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool condition = isEnemy ? (collision.GetComponent<Player>() != null || collision.GetComponent<Enemy>() == null) : //pocisk przeciwnika reaguje tylko na gracza
            (collision.GetComponent<Player>() == null || collision.GetComponent<Enemy>() != null); //pocisk gracza reaguje tylko na przeciwnika

        if (condition)
        {
            if (collision.GetComponent<Entity>() != null)
            {
                collision.GetComponent<Entity>().Health -= damage; //trafiono gracza lub przeciwnika
                Destroy(gameObject);
            }
        }

        Destroy(gameObject, deley);
    }
}
