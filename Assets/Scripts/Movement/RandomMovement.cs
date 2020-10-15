 using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    class RandomMovement:BasicMovement
    {
        float StartY; // startowa wysokość
        Vector2 TargetVector; // cel lotu 

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
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, FlyVelocity, Time.deltaTime / 2f);
            //transform.right = FlyDirection
        }

        // zmienia cel 
        IEnumerator ChangeTarget()
        {
            while (true)
            {
                TargetVector = new Vector2();
                TargetVector.x = UnityEngine.Random.Range(-12, 12);
                TargetVector.y = UnityEngine.Random.Range(-7, 7);

                yield return new WaitForSeconds(UnityEngine.Random.Range(3, 6));
            }
        }
    }



}
