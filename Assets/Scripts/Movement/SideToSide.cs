using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : BasicMovement
{
    [SerializeField]
    bool goLeft;

    float direction;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        direction = goLeft ? minX : maxX;
    }
  
    // Update is called once per frame
    void Update()
    {
        SideToSideMovement();
    }

    private void SideToSideMovement()
    {
        var FlyDirection = new Vector3(direction, transform.position.y) - transform.position;
        var FlyVelocity = FlyDirection.normalized * speed;
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, FlyVelocity, Time.deltaTime / 2f);
        CheckPosition();
    }

    protected override void CheckPosition()
    {
        if (transform.position.x < minX)
        {
            direction = maxX;
        }

        if (transform.position.x > maxX)
        {
            direction = minX;
        }
    }


}
