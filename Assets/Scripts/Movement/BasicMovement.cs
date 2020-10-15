using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicMovement : MonoBehaviour
{
    [SerializeField] // ograniczenia ruchu w osi x i y
    protected float maxX;
    [SerializeField]
    protected float maxY;
    [SerializeField]
    protected float minX;
    [SerializeField]
    protected float minY;
    [SerializeField] 
    protected float speed;
  
    
    protected Rigidbody2D rigidbody;
    
    // sprawdza czy dany ruch jest dozwolony
    protected virtual void CheckPosition()
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
