using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicMovement : MonoBehaviour
{
    [SerializeField]
    float maxX;
    [SerializeField]
    float maxY;
    [SerializeField]
    float minX;
    [SerializeField]
    float minY;
    [SerializeField]
    float speed;

    Rigidbody2D rigidbody;

    int Seed;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        Seed = (int)transform.position.x;
    }

    void   Update()
    {
        RandomMove();
    }

    void RandomMove()
    {
            System.Random random = new System.Random(Seed);

            var FlyDirection = Vector3.zero;
            float x = (float)(random.NextDouble() * (maxX - minX) + minX);
            float y = (float)(random.NextDouble() * (maxY - minY) + minY);

            FlyDirection += Vector3.up * y;
            FlyDirection += Vector3.right * x;
            FlyDirection = FlyDirection.normalized;
            FlyDirection *= speed;

            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, FlyDirection, Time.deltaTime * 4);

            CheckPosition(FlyDirection);
        
        
    }

   
    void CheckPosition(Vector3 currentDirection)
    {
        if (transform.position.y < -8)
        {

            transform.position = new Vector2(transform.position.x, 10);

        }
   
        if (transform.position.x < -12)
        {
            rigidbody.position = new Vector2(12, transform.position.y);
           
        }

        if (transform.position.x > 12)
        {
            rigidbody.position = new Vector2(-12, transform.position.y);
            
        }


    }
}
