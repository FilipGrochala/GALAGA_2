using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UprightMovement : MonoBehaviour
{
    [SerializeField]
    bool goDown = true;

    [SerializeField]
    float speed;

    Vector3 TargetVector;
    Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // start position
        if (goDown)
        {
            TargetVector = new Vector3(transform.position.x,-10);
        }
        else
        {
            TargetVector = new Vector3(transform.position.x, 10);
        }
    }

    void Update()
    {
        UprightMove();
    }

    void UprightMove()
    {
        var FlyDirection = TargetVector - transform.position;
        var FlyVelocity = FlyDirection.normalized * speed;
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, FlyVelocity, Time.deltaTime / 2f);


        if (transform.position.y < -8 && goDown)
            Destroy(gameObject);

        if (transform.position.y > 8 && !goDown)
            Destroy(gameObject);
    }
}
