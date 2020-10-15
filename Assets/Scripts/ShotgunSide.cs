using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunSide : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 1)
        {
            transform.eulerAngles = new Vector3(0,180,-50);
        }

        if (transform.position.x < -1)
        {
            transform.eulerAngles = new Vector3(0, 0, -50);
        }

        if(transform.position.x > -1 && transform.position.x < 1)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }


    }
}
