using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Rocket : Bullet
{
    [SerializeField]
    float startSpeed = 0.5f;

    [SerializeField]
    float targetSpeed = 2.5f;

    [SerializeField]
    float changeTime = 1f;

    [SerializeField]
    float followTime = 2f;

    float currentSpeed;
    bool follow = true;
    Vector2 target;
    Rigidbody2D bulletRigidbody;

    void Start()
    {
        currentSpeed = startSpeed;
        StartCoroutine(changeSpeed());
        StartCoroutine(changeFollow());
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (follow)
        {
          target = FindObjectOfType<Player>().transform.position - transform.position;
        }
        else
        {
            GetComponent<FollowPlayer>().Active = false;
        }

        bulletRigidbody.MovePosition((Vector2)transform.position + (target * currentSpeed * Time.deltaTime));
    }

    IEnumerator changeSpeed()
    {
        yield return new WaitForSeconds(changeTime);
        currentSpeed = targetSpeed;
    }

    IEnumerator changeFollow()
    {
        yield return new WaitForSeconds(followTime);
        follow = false;
    }

}
