using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    Player target;
    bool active = true;

    public bool Active { get => active; set => active = value; }

    void Start()
    {
        target = FindObjectOfType<Player>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            Vector3 direction = target.transform.position - transform.position;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.GetComponent<Rigidbody2D>().rotation = angle - 90;
        }
        
    }
}
