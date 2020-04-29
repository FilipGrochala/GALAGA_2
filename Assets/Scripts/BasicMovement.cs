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

    Vector2 TargetVector;

    Rigidbody2D rigidbody;
    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        StartCoroutine(ChangeTarget());
      
      
    }

    void   Update()
    {
        RandomMove();
    }

    void RandomMove()
    {
            var FlyDirection = (Vector3)TargetVector - transform.position; 
            FlyDirection = FlyDirection.normalized;
            FlyDirection *= speed;

            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, FlyDirection, Time.deltaTime * 4);

            CheckPosition(FlyDirection);
        
        
    }

    IEnumerator ChangeTarget()
    {
        while (true)
        {
            TargetVector = new Vector2();
            TargetVector.x = Random.Range(-12, 12);
            TargetVector.y = Random.Range(-8, -10);
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
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
