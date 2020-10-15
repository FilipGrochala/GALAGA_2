using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Sprite normal_point;

    [SerializeField]
    Sprite critical_point;

    void Start()
    {
        FullBar();
    }

  

    void FullBar()
    {
        double position = -0.4;

        while (position <= -0.4)
        {
            Debug.Log("Pasek");
            Instantiate(normal_point,
                new Vector3(transform.position.x + (float)position,transform.position.y,-1),
                new Quaternion(0,0,0,0));
            position += 0.35;
        }
    }
}
