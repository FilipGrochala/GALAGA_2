using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class HorizontalMovement:MonoBehaviour
    {
        [SerializeField]
        bool goLeft = true;

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
            if (goLeft)
            {
                TargetVector = new Vector3(-30, transform.position.y);
            }
            else
            {
                TargetVector = new Vector3(30, transform.position.y);
            }
        }

        void Update()
        {
            HorizontalMove();
        }

        void HorizontalMove()
        {
           var FlyDirection = TargetVector - transform.position;
           var FlyVelocity = FlyDirection.normalized * speed;
           rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, FlyVelocity, Time.deltaTime / 2f);

          
           if (transform.position.x < -25 && goLeft)
              Destroy(gameObject);

           if (transform.position.x > 20 && !goLeft)
                Destroy(gameObject);
        }
    }
}
