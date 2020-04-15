using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Entity))]
public class Player : MonoBehaviour
{
    [SerializeField]
    float Speed = 3f;

    Rigidbody2D rigidbody;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GetComponent<Entity>().OnKilled += () =>
        {
            Destroy(gameObject);
        };

    }

    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        var FlyDirection = Vector3.zero;

        FlyDirection += Vector3.up * Input.GetAxis("Vertical");
        FlyDirection += Vector3.right * Input.GetAxis("Horizontal");

        FlyDirection = FlyDirection.normalized;
        FlyDirection *= Speed;

        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, FlyDirection, Time.deltaTime * 4);

        CheckPosition();

    }

    void CheckPosition()
    {
        if (transform.position.y < -4)
            rigidbody.position = new Vector2(transform.position.x, -4);

        if (transform.position.y > 4)
            rigidbody.position = new Vector2(transform.position.x, 4);


    }
   
}
