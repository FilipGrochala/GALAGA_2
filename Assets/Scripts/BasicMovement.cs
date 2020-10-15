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
  

    float StartY;
    Vector2 TargetVector;
    Rigidbody2D rigidbody;
    
    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        StartY = transform.position.y;
        StartCoroutine(ChangeTarget());
      
      
    }
    void Update()
    {
        RandomMove();
        CheckPosition();
    }


    void RandomMove()
    {
            var FlyDirection = (Vector3)TargetVector - transform.position; 
            var FlyVelocity = FlyDirection.normalized * speed;
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, FlyVelocity, Time.deltaTime/2f);
            //transform.right = FlyDirection;

    }

    IEnumerator ChangeTarget()
    {
        while (true)
        {
            TargetVector = new Vector2();
            TargetVector.x = Random.Range(-12, 12);
            TargetVector.y = Random.Range(-7, 7);
            
            yield return new WaitForSeconds(Random.Range(3, 6));
            

        }
    }

    void CheckPosition()
    {
        if (transform.position.y < minY)
        {

            transform.position = new Vector2(transform.position.x, minY);

        }

        if (transform.position.y > maxY)
        {

            transform.position = new Vector2(transform.position.x, maxY);

        }

        if (transform.position.x < minX)
        {
            rigidbody.position = new Vector2(minX, transform.position.y);
           
        }

        if (transform.position.x > maxX)
        {
            rigidbody.position = new Vector2(maxX, transform.position.y);
            
        }


    }
}
