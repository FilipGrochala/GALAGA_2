using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null && collision.GetComponent<Enemy>() == null)
            collision.GetComponent<Entity>().Health -= damage; //trafiono gracza 
        Destroy(gameObject, 0.2f);
    }
}
